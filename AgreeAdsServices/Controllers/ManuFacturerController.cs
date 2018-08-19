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
    public class ManuFacturerController : ApiController
    {
        private IUnitOfWork unitOfWork;
        private GenericRepository<ManuFacturer> manuFacturerRepository;
        HttpResponseMessage httpResponseMessage = null;
        public ManuFacturerController()
        {
            unitOfWork = ContextFactory.CreateContext(typeof(ManuFacturer));
            manuFacturerRepository = unitOfWork.Repository<ManuFacturer>();
        }
        [HttpGet]
        public HttpResponseMessage GetManuFacturerByID(int id)
        {

            ManuFacturer manuFacturer = manuFacturerRepository.GetById(id);
            if (manuFacturer != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, manuFacturer);
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");

            }
            return httpResponseMessage;
        }
        [HttpGet]
        public HttpResponseMessage GetManuFacturer()
        {

            IEnumerable<ManuFacturer> manuFacturers = manuFacturerRepository.GetAll();
            if (manuFacturers != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, manuFacturers);
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");

            }
            return httpResponseMessage;
        }
        [HttpPost]
        public HttpResponseMessage AddCategory([FromBody]ManuFacturer manuFacturer)
        {
            manuFacturer.TimeCreated = DateTime.Now;
            manuFacturer.TimeUpdated = DateTime.Now;
            ManuFacturer _manuFacturer = manuFacturerRepository.Insert(manuFacturer);
            if (_manuFacturer != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, _manuFacturer);
                httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (_manuFacturer.ManuFacturerID).ToString());
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }
            return httpResponseMessage;
        }
        [HttpPut]
        public HttpResponseMessage UpdateCategory([FromBody]ManuFacturer manuFacturer)
        {
            ManuFacturer _manuFacturer = manuFacturerRepository.Update(manuFacturer);
            if (_manuFacturer != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, _manuFacturer);
                httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (manuFacturer.ManuFacturerID).ToString());
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }
            return httpResponseMessage; ;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteCategory(int id)
        {
            manuFacturerRepository.Delete(id);
            manuFacturerRepository.Save();
            HttpResponseMessage ms = Request.CreateResponse(HttpStatusCode.Accepted);
            return ms;
        }
    }
}
