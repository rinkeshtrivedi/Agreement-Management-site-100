using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LIB.BL.Interface;
using LIB.BL.Repository;
using LIB.Models.Agreement;

namespace Web.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Agreement")]
    public class AgreementController : ApiController
    {
        private IAgreementRequest _agreementRequest;

        public AgreementController()
        {
            this._agreementRequest = new AgreementRequest();
        }

        [HttpPost]
        [Route("Get_old")]
        public IHttpActionResult Get_old(SearchModel model)
        {
            return Ok(_agreementRequest.Get_old(model));
        }

        [HttpPost]
        [Route("Get")]
        public IHttpActionResult Get(SearchModel model)
        {
            return Ok(_agreementRequest.Get(model));
        }

        [HttpGet]
        [Route("Detail")]
        public IHttpActionResult Detail(long? id = null)
        {
            return Ok(_agreementRequest.Detail(id));
        }

        [HttpGet]
        [Route("GetProductList")]
        public IHttpActionResult GetProductList(long? GroupId = null)
        {
            return Ok(_agreementRequest.GetProductList(GroupId));
        }

        [HttpPost]
        [Route("CreateUpdate")]
        public IHttpActionResult CreateUpdate(AgreementBindingModel model)
        {
            return Ok(_agreementRequest.CreateUpdate(model));
        }

        [Route("Delete")]
        public IHttpActionResult Delete(long? id = null)
        {
            return Ok(_agreementRequest.Delete(id));
        }

    }
}
