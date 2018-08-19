using AgreeAdsWebApp.XMLProcesser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgreeAdsWebApp.Controller
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetProduct()
        {
            if(true)
            {
                clsXMLProcesser objprocessor = new clsXMLProcesser();
                return Request.CreateResponse(HttpStatusCode.OK, objprocessor.GetXML(clsXMLProcesser.XMLTypes.Product));
            }
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }

        }
    }
}
