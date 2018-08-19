
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
    public class CategoryController : ApiController
    {
        private IUnitOfWork unitOfWork;
        private GenericRepository<Category> categoryRepository;
        HttpResponseMessage httpResponseMessage = null;
        public CategoryController()
        {
            unitOfWork = ContextFactory.CreateContext(typeof(Category));
            categoryRepository = unitOfWork.Repository<Category>();
        }

        [HttpGet]
        public HttpResponseMessage GetCategoryByID(int id)
        {

            Category category = categoryRepository.GetById(id);
            if (category != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, category);
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");

            }
            return httpResponseMessage;
        }
        [HttpGet]
        public HttpResponseMessage GetCategories()
        {

            IEnumerable<Category> categories = categoryRepository.GetAll();
            if (categories != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            else{
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");

            }
            return httpResponseMessage;
        }
        [HttpPost]
        public HttpResponseMessage AddCategory([FromBody]Category category)
        {
            category.TimeCreated = DateTime.Now;
            category.TimeUpdated = DateTime.Now;
            Category _category = categoryRepository.Insert(category);
            if (_category != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, _category);
                httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (_category.CategoryID).ToString());
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }
            return httpResponseMessage;
        }
        [HttpPut]
        public HttpResponseMessage UpdateCategory([FromBody]Category category)
        {
            Category _category = categoryRepository.Update(category);
            if (_category != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, _category);
                httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (_category.CategoryID).ToString());
            }
            else{
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }
            return httpResponseMessage; ;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteCategory(int id)
        {
            categoryRepository.Delete(id);
            categoryRepository.Save();
            HttpResponseMessage ms = Request.CreateResponse(HttpStatusCode.Accepted);
            return ms;
        }
    }
}
