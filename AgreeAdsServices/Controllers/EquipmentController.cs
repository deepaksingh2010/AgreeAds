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
    public class EquipmentController :ApiController
    {
        private IUnitOfWork unitOfWork;
        private GenericRepository<Equipment> equipmentRepository;
        HttpResponseMessage httpResponseMessage = null;
        public EquipmentController()
        {
            unitOfWork = ContextFactory.CreateContext(typeof(Equipment));
            equipmentRepository = unitOfWork.Repository<Equipment>();
        }
        [HttpGet]
        public HttpResponseMessage GetManuFacturerByID(int id)
        {

            Equipment equipment = equipmentRepository.GetById(id);
            if (equipment != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, equipment);
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

            IEnumerable<Equipment> equipments = equipmentRepository.GetAll();
            if (equipments != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, equipments);
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");

            }
            return httpResponseMessage;
        }
        [HttpPost]
        public HttpResponseMessage AddCategory([FromBody]Equipment equipment)
        {
            equipment.TimeCreated = DateTime.Now;
            equipment.TimeUpdated = DateTime.Now;
            Equipment _equipment = equipmentRepository.Insert(equipment);
            if (_equipment != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, _equipment);
                httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (_equipment.EquipmentID).ToString());
            }
            else
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            }
            return httpResponseMessage;
        }
        [HttpPut]
        public HttpResponseMessage UpdateCategory([FromBody]Equipment equipment)
        {
            Equipment _equipment = equipmentRepository.Update(equipment);
            if (_equipment != null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, _equipment);
                httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (equipment.EquipmentID).ToString());
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
            equipmentRepository.Delete(id);
            equipmentRepository.Save();
            HttpResponseMessage ms = Request.CreateResponse(HttpStatusCode.Accepted);
            return ms;
        }
    }
}
