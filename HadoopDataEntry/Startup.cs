using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HadoopDataEntry.Startup))]
namespace HadoopDataEntry
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
