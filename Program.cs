using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Interfaces;
using Data.Interfaces.Categories;
using Data.Interfaces.Systems;
using Data.Repositories;
using Data.Repositories.Categories;
using Data.Repositories.Systems;
using Microsoft.Extensions.DependencyInjection;
using WinApp.DanhMuc;

namespace WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///        

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IMenuBarRepository, MenuBarRepository>();
            services.AddTransient<IFunctionRepository, FunctionRepository>();
            services.AddTransient<IDaiLyRepository, DaiLyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITaskPaneRepository, TaskPaneRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IEmployee, EmployeeRepository> ();
            services.AddTransient<IDepartment, DepartmentRepository>();
            services.AddTransient<IBranch, BranchReopository>();
            services.AddTransient<ITitle, TitleRepository>();
            services.AddTransient<ICustomer, CustomerRepository>();
            services.AddTransient<IAttachFiles, AttachFilesRepository>();
            BaseComponent.AppConfig.ServiceProvider = services.BuildServiceProvider();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new Login());
        }
    }

    class DaiLyView
    {
        public DaiLyView(BaseComponent.baseMain frm, string funcId)
        {
            foreach (System.Windows.Forms.Form fChild in frm.MdiChildren)
            {
                if (fChild.GetType() == typeof(DaiLyList))
                {
                    fChild.Activate();
                    return;
                }
            }
            DaiLyList f = new DaiLyList();
            f.Text = "Danh sách đại lý";
            f.funcId = funcId;
            f.MdiParent = frm;
            f.NameClass = GetType().ToString();
            f.Show();
        }
    }
}
