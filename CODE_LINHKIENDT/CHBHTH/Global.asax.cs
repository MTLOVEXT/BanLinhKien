using CHBHTH.Areas.Admin.Repositories;
using CHBHTH.Repositories;
using CHBHTH.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace CHBHTH
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			// Cấu hình Dependency Injection
			var container = ConfigureUnityContainer();
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
		private IUnityContainer ConfigureUnityContainer()
		{
			var container = new UnityContainer();

			// Đăng ký interface với class implementation
			container.RegisterType<IUserRepository, UserRepository>();
			container.RegisterType<ITintucRepository, TinTucRepository>();
			container.RegisterType<ISanPhamRepository, SanPhamRepository>();
			container.RegisterType<IGioHangRepository, GioHangRepository>();
			container.RegisterType<IDonHangRepository, DonHangRepository>();
			container.RegisterType<IDanhMucRepository, DanhMucRepository>();

			//Admin
			container.RegisterType<ISanPhamRepositoryAdmin, SanPhamRepositoryAdmin>();
			container.RegisterType<ITaiKhoanRepositoryAdmin, TaiKhoanRepositoryAdmnin>();
			container.RegisterType<IPhanQuyenRepository, PhanQuyenRepository>();
			container.RegisterType<INhaCungCapRepository, NhaCungCapRepository>();
			container.RegisterType<ILoaiHangRepository, LoaiHangRepository>();
			container.RegisterType<ITinTucRepositoryAdmin, TinTucRepositoryAdmin>();
			container.RegisterType<IThongKeRepository, ThongKeRepository>();
			container.RegisterType<IChiTietDonHangRepositoryAdmin, ChiTietDonHangRepositoryAdmin>();
			container.RegisterType<IDonHangRepositoryAdmin, DonHangRepositoryAdmin>();

			// Đăng ký thêm các dịch vụ khác nếu cần
			container.RegisterType<IVNPayService, VnpayService>();

			return container;
		}
	}
}
