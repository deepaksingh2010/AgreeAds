using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Data
{
    class BaseEquipmentSpecificationContext<T> : BaseDBContext<T> where T : class
    {
        public BaseEquipmentSpecificationContext():base()
        {

        }
        public override System.Data.Entity.DbSet<T> dbSet
        {
            get
            {
                return base.dbSet;
            }
        }
        public override void SPMemberShipType(DbModelBuilder modelBuilder)
        {
            base.SPMemberShipType(modelBuilder);
        }
    }
}
