using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
namespace AgreeAdsWebApp.Controller
{
    public class CategoriesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetIssueTypeByID(int id)
        {
            if (id > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }

        }

    }
}