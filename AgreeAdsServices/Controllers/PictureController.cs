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
    public class PictureController : BaseController<Picture>
    {
        public PictureController() :base()
        {
        }
        [HttpPost]
        public override HttpResponseMessage AddEntity([FromBody] Picture entity)
        {
            entity.TimeCreated = DateTime.Now;
            entity.TimeUpdated = DateTime.Now;
            HttpResponseMessage response = base.AddEntity(entity);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (entity.PictureID).ToString());
            return response;
        }
        [HttpPost]
        protected override HttpResponseMessage UpdateEntity([FromBody] Picture entity)
        {
            HttpResponseMessage response = base.UpdateEntity(entity);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (entity.PictureID).ToString());
            return response;
        }
    }
}
