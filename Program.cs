using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenCoinChallan
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            services.AddTransient<IChallanRepository, ChallanRepository>();
            services.AddTransient<IChallanTallyXMLGenerator, ChallanTallyXMLGenerator>();
            services.AddTransient<IChallanService, ChallanService>();

            ServiceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1(ServiceProvider.GetService<IChallanService>()));
            Application.Run(new Form1());
        }
    }
}
