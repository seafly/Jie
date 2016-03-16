using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cabio.DLL.Base
{
    public class BaseDll<T> : DbContext where T:class
    {
        public BaseDll() : base("name=connectionStr") { }
        public BaseDll(string connectionStr) : base(connectionStr) { }

        public DbSet<T> Models { get; set; }
    }
}