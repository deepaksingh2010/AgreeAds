using AgreeAdsDataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Data
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Dispose(bool disposing);
        GenericRepository<T> Repository<T>() where T : class;
        void Save();
    }
}
