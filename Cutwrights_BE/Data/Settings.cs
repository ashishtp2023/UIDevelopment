using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CutwrightsCRUD.Data
{
    public class Settings
    {
        public string  ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
