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
    public class ManuFacturerController : BaseController<ManuFacturer>
    {
        public ManuFacturerController() : base()
        {
        }
        [HttpPost]
        public override HttpResponseMessage AddEntity([FromBody] ManuFacturer entity)
        {
            entity.TimeCreated = DateTime.Now;
            entity.TimeUpdated = DateTime.Now;
            HttpResponseMessage response = base.AddEntity(entity);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (entity.ManuFacturerID).ToString());
            return response;
        }
        [HttpPost]
        protected override HttpResponseMessage UpdateEntity([FromBody] ManuFacturer entity)
        {
            HttpResponseMessage response = base.UpdateEntity(entity);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (entity.ManuFacturerID).ToString());
            return response;
        }
    }
}
