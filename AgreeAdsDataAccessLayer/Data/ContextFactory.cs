using AgreeAdsDataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Data
{
    public class ContextFactory
    {
        private readonly static Dictionary<Type, IUnitOfWork> objContextDictionary = new Dictionary<Type, IUnitOfWork>();
        
        static ContextFactory()
        {
            IUnitOfWork unitofwork_Category = new UnitOfWork<Category>(new CategoryContext<Category>());
            objContextDictionary.Add(typeof(Category), unitofwork_Category);

            IUnitOfWork unitofwork_ManuFacturer = new UnitOfWork<ManuFacturer>(new EquipmentContext<ManuFacturer>());
            objContextDictionary.Add(typeof(ManuFacturer), unitofwork_ManuFacturer);

            IUnitOfWork unitofwork_Equipment = new UnitOfWork<Equipment>(new ManuFacturerContext<Equipment>());
            objContextDictionary.Add(typeof(Equipment), unitofwork_Equipment);
        }
        public static IUnitOfWork CreateContext(Type type)
        {
            return objContextDictionary[type];
        }
    }
}
