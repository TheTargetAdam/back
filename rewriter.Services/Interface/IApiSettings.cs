using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rewriter.Settings.Interface;
namespace rewriter.Settings.Interface;

    public interface IApiSettings
    {
        IDbSettings Db { get; }
        IGeneralSettings General { get; }
        IIdentityServerConnectSettings IdentityServer { get; }
        
    }

