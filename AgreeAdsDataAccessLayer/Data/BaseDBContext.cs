using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Data
{
    public class BaseDBContext<T> : DbContext where T : class
    {
        private DbSet<T> _dbset;
        public virtual DbSet<T> dbSet { get { return this._dbset; } private set { _dbset = this.Set<T>(); } }
        public BaseDBContext()
            : base("name=AgreeAdsDBContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SPMemberShipType(modelBuilder);
        }
        public virtual void SPMemberShipType(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>();
        }
    }
}
