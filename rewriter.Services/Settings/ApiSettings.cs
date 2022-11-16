using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rewriter.Settings.Interface;
using rewriter.Settings.Source;
namespace rewriter.Settings.Settings
{
    public class ApiSettings:IApiSettings
    {
        private readonly ISettingSource source;
        private readonly IGeneralSettings generalSettings;
        private readonly IDbSettings dbSettings;
        private readonly  IIdentityServerConnectSettings IdentityServerSettings;

        //private readonly IDbSettings dbSettings;
        public ApiSettings(ISettingSource source) => this.source = source;
        public ApiSettings(ISettingSource source, IGeneralSettings generalSettings,IDbSettings dbSettings,IIdentityServerConnectSettings identityServerConnectSettings )
        {
            this.source = source;
            this.generalSettings = generalSettings;
            this.dbSettings = dbSettings;           
            this.IdentityServerSettings = identityServerConnectSettings;
        }
        public IIdentityServerConnectSettings IdentityServer => IdentityServerSettings ?? new IdentityServerSettings(source);
        public IGeneralSettings General => generalSettings ?? new GeneralSettings(source);

        public IDbSettings Db => dbSettings ?? new DbSettings(source);

        
    }
}
