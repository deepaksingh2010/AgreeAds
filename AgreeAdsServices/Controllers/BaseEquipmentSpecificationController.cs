using AgreeAdsDataAccessLayer.Data;
using AgreeAdsDataAccessLayer.DataAccess;
using AgreeAdsDataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace AgreeAdsServices.Controllers
{
    public class BaseEquipmentSpecificationController : BaseController<BaseEquipmentSpecification>
    {
        public BaseEquipmentSpecificationController() : base()
        {
        }
        [HttpPost]
        public override HttpResponseMessage AddEntity([FromBody] BaseEquipmentSpecification entity)
        {
            entity.TimeCreated = DateTime.Now;
            entity.TimeUpdated = DateTime.Now;

            

            HttpResponseMessage response = base.AddEntity(entity);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (entity.BaseEquipmentSpecificationID).ToString());
            return response;
        }
        [HttpPost]
        protected override HttpResponseMessage UpdateEntity([FromBody] BaseEquipmentSpecification entity)
        {
            HttpResponseMessage response = base.UpdateEntity(entity);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (entity.BaseEquipmentSpecificationID).ToString());
            return response;             
        }
    }
}
