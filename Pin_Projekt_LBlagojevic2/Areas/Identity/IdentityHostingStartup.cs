[assembly: HostingStartup(typeof(Pin_Projekt_LBlagojevic2.Areas.Identity.IdentityHostingStartup))]
namespace Pin_Projekt_LBlagojevic2.Areas.Identity


{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
