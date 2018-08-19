using AgreeAdsDataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Data
{
    public class EquipmentContext<T>: BaseDBContext<T> where T : class
    {
        public EquipmentContext() : base()
        {
            this.Database.CreateIfNotExists();
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
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    SPMemberShipType(modelBuilder);
        //}
        //public virtual void SPMemberShipType(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<T>();
        //    // modelBuilder.Entity<T>()
        //    //      .MapToStoredProcedures(p => p.Insert(x => x.HasName("InsertMemberShipType")));
        //    // modelBuilder.Entity<T>()
        //    //     .MapToStoredProcedures(p => p.Update(x => x.HasName("UpdateMemberShipType")));
        //    // modelBuilder.Entity<T>()
        //    //     .MapToStoredProcedures(p => p.Delete(x => x.HasName("DeleteMemberShipType")));
        //}

    }
}
