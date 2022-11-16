using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rewriter.Settings.Interface;
using rewriter.Settings.Source;
namespace rewriter.Settings.Settings
{
    public class GeneralSettings : IGeneralSettings
    {
        private readonly ISettingSource source;
        public GeneralSettings (ISettingSource source)=>this.source = source;

        public bool SwaggerVisible => source.GetAsBool("General:SwaggerVisible");
    }
}
