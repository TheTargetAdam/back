using rewriter.Settings.Interface;
using rewriter.Settings.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Settings.Settings
{
    internal class DbSettings : IDbSettings
    {
        private readonly ISettingSource source;
        public DbSettings(ISettingSource source) => this.source = source;
        public string ConnectionString => source.GetConnectionString("MainDbContext");
    }
}
