using AgreeAdsDataAccessLayer.Data;
using AgreeAdsDataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace AgreeAdsServices.Controllers
{
    public class BaseController<T> : ApiController where T : class
    {
        private IUnitOfWork unitOfWork;
        protected GenericRepository<T> Repository;
        protected HttpResponseMessage httpResponseMessage { get; set; }
        public BaseController()
        {
            unitOfWork = ContextFactory.CreateContext(typeof(T));
            Repository = unitOfWork.Repository<T>();
        }
        [HttpDelete]
        public HttpResponseMessage DeleteCategory(int id)
        {
            Repository.Delete(id);
            Repository.Save();
            HttpResponseMessage ms = Request.CreateResponse(HttpStatusCode.Accepted);
            return ms;
        }
        public virtual HttpResponseMessage GetEntitiesByID(int id)
        {

            T objEntity = Repository.GetById(id);
            if (objEntity != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, objEntity);
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }
            return httpResponseMessage;
        }
        public virtual HttpResponseMessage GetEntities()
        {

            IEnumerable<T> Entities = Repository.GetAll();
            if (Entities != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, Entities);
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");

            }
            return httpResponseMessage;
        }


        public virtual HttpResponseMessage AddEntity([FromBody]T entity)
        {
            T _baseEquipmentSpecification = Repository.Insert(entity);
            if (_baseEquipmentSpecification != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, _baseEquipmentSpecification);
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }
            return httpResponseMessage;
        }
        protected virtual HttpResponseMessage UpdateEntity([FromBody]T entity)
        {
            T _entity = Repository.Update(entity);
            if (_entity != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, _entity);
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }
            return httpResponseMessage; ;
        }
    }

}
