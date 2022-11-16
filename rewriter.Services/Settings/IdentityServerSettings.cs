using rewriter.Settings.Interface;
using rewriter.Settings.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Settings.Settings
{
    public class IdentityServerSettings: IIdentityServerConnectSettings
    {
        private readonly ISettingSource source;
        public IdentityServerSettings(ISettingSource source) => this.source = source;

        public string Url => source.GetAsString("IdentityServer:Url");
        public string ClientId => source.GetAsString("IdentityServer:ClientId");
        public string ClientSecret => source.GetAsString("IdentityServer:ClientSecret");
        public bool RequireHttps => Url.ToLower().StartsWith("https://");
    }
}
