using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cabio.DLL.Base;
using System.Runtime.InteropServices;

namespace Cabio.BLL.Base
{
    [ComVisible(true)]
    public class BllBase<T> where T:class
    {
        public BaseDll<T> Dao { get; set; }


        public virtual int Save(T entity)
        {
            Dao.Models.Add(entity);
            return Dao.SaveChanges();
        }

        public virtual int Remove(T entity)
        {
            Dao.Models.Remove(entity);
            return Dao.SaveChanges();
        }

        public virtual T First()
        {
            return this.Query().ToList<T>()[0];
        }

        public virtual IQueryable<T> Query()
        {
            return Dao.Set<T>().AsQueryable<T>();
        }
    }
}
