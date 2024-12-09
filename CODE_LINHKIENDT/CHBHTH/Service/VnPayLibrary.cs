using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CHBHTH.Service
{
    public class VnPayLibrary
    {
        private SortedList<string, string> _requestData = new SortedList<string, string>(new VnPayCompare());
        private SortedList<string, string> _responseData = new SortedList<string, string>(new VnPayCompare());

        public void AddRequestData(string key, string value)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Key hoặc Value không được để trống.");
                }

                if (_requestData.ContainsKey(key))
                {
                    Console.WriteLine($"Cảnh báo: Key '{key}' đã tồn tại trong requestData, sẽ được cập nhật giá trị.");
                    _requestData[key] = value;
                }
                else
                {
                    _requestData.Add(key, value);
                }
            }
            catch (Exception ex)
            {
                LogError("AddRequestData", ex);
            }
        }

        public void AddResponseData(string key, string value)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Key hoặc Value không được để trống.");
                }

                if (_responseData.ContainsKey(key))
                {
                    Console.WriteLine($"Cảnh báo: Key '{key}' đã tồn tại trong responseData, sẽ được cập nhật giá trị.");
                    _responseData[key] = value;
                }
                else
                {
                    _responseData.Add(key, value);
                }
            }
            catch (Exception ex)
            {
                LogError("AddResponseData", ex);
            }
        }

        public string GetResponseData(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("Key không được để trống.");
                }

                if (_responseData.TryGetValue(key, out var value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Không tìm thấy key '{key}' trong responseData.");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError("GetResponseData", ex);
                return string.Empty;
            }
        }

        public string CreateRequestUrl(string baseUrl, string hashSecret)
        {
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in _requestData)
            {
                if (!String.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }
            string queryString = data.ToString();

            baseUrl += "?" + queryString;
            String signData = queryString;
            if (signData.Length > 0)
            {

                signData = signData.Remove(data.Length - 1, 1);
            }
            string vnp_SecureHash = HmacSHA512(hashSecret, signData);
            baseUrl += "vnp_SecureHash=" + vnp_SecureHash;

            return baseUrl;
        }

        public bool ValidateSignature(string inputHash, string hashSecret)
        {
            try
            {
                if (string.IsNullOrEmpty(inputHash) || string.IsNullOrEmpty(hashSecret))
                {
                    throw new ArgumentException("Input Hash hoặc Hash Secret không được để trống.");
                }

                StringBuilder hashData = new StringBuilder();
                foreach (var kvp in _responseData)
                {
                    if (!kvp.Key.Equals("vnp_SecureHash", StringComparison.OrdinalIgnoreCase))
                    {
                        hashData.Append(WebUtility.UrlEncode(kvp.Key) + "=" + WebUtility.UrlEncode(kvp.Value) + "&");
                    }
                }

                string rawHash = hashData.ToString().TrimEnd('&');
                string expectedHash = HmacSHA512(hashSecret, rawHash);

                return expectedHash.Equals(inputHash, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                LogError("ValidateSignature", ex);
                return false;
            }
        }

        private string HmacSHA512(string key, string inputData)
        {
            var hash = new StringBuilder();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }

        private void LogError(string methodName, Exception ex)
        {
            Console.WriteLine($"Lỗi tại {methodName}: {ex.Message}");
            Console.WriteLine($"Chi tiết lỗi: {ex.StackTrace}");
        }
    }

    public class VnPayCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            var vnpCompare = CompareInfo.GetCompareInfo("en-US");
            return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
        }
    }
}
