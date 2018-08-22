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

            IUnitOfWork unitofwork_Video = new UnitOfWork<Video>(new VideoContext<Video>());
            objContextDictionary.Add(typeof(Video), unitofwork_Video);

            IUnitOfWork unitofwork_Picture = new UnitOfWork<Picture>(new PictureContext<Picture>());
            objContextDictionary.Add(typeof(Picture), unitofwork_Picture);

            IUnitOfWork unitofwork_Rating = new UnitOfWork<Rating>(new RatingContext<Rating>());
            objContextDictionary.Add(typeof(Rating), unitofwork_Rating);

            IUnitOfWork unitofwork_EquipmentSpecificationType = new UnitOfWork<EquipmentSpecificationType>(new EquipmentSpecificationTypeContext<EquipmentSpecificationType>());
            objContextDictionary.Add(typeof(EquipmentSpecificationType), unitofwork_EquipmentSpecificationType);

            IUnitOfWork unitofwork_BaseEquipmentSpecification = new UnitOfWork<BaseEquipmentSpecification>(new BaseEquipmentSpecificationContext<BaseEquipmentSpecification>());
            objContextDictionary.Add(typeof(BaseEquipmentSpecification), unitofwork_BaseEquipmentSpecification);


        }
        public static IUnitOfWork CreateContext(Type type)
        {
            return objContextDictionary[type];
        }
    }
}
