
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
    public class CategoryController : BaseController<Category>
    {
        public CategoryController() : base()
        {
        }
        [HttpPost]
        public override HttpResponseMessage AddEntity([FromBody] Category entity)
        {
            entity.TimeCreated = DateTime.Now;
            entity.TimeUpdated = DateTime.Now;
            HttpResponseMessage response = base.AddEntity(entity);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (entity.CategoryID).ToString());
            return response;
        }
        [HttpPost]
        protected override HttpResponseMessage UpdateEntity([FromBody] Category entity)
        {
            HttpResponseMessage response = base.UpdateEntity(entity);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (entity.CategoryID).ToString());
            return response;
        }
    }
}
