using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LIB.Models.DBModels;
using LIB.Models.Agreement;
using Web.Agreement.Helper;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;

namespace Web.Agreement.Controllers
{
    public class AgreementController : Controller
    {
        // GET: Agreement

        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Get_old()
        {
            HttpResponseMessage response = APIRequestManager.webAPiClient.PostAsJsonAsync("Agreement/Get_old", "Afsfg").Result;
            var result = response.Content.ReadAsAsync<ErrorMessage>().Result;
            if (result.Status == 0)
            {
                return Json(new
                {
                    Data = Common.RenderRazorViewToString(ControllerContext, "~/Views/Campaign/Contacts/_ContactsList.cshtml", Newtonsoft.Json.JsonConvert.DeserializeObject<AgreementListViewModel>(result.Data.ToString())),
                    Message = result.Message,
                    Status = result.Status,
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get(SearchModel objSearch)
        {
            HttpResponseMessage response = APIRequestManager.webAPiClient.PostAsJsonAsync("Agreement/Get", objSearch).Result;
            List<GetAgreementList_Result> resultList = response.Content.ReadAsAsync<List<GetAgreementList_Result>>().Result;
            return Json(resultList);
        }

        [HttpGet]
        [Route("Detail")]
        public JsonResult Detail(long? id)
        {
            HttpResponseMessage response = APIRequestManager.webAPiClient.GetAsync("Agreement/Detail?id=" + id).Result;
            var result = response.Content.ReadAsAsync<ErrorMessage>().Result;

            if (result.Status == 0)
            {
                var model = JsonConvert.DeserializeObject<AgreementBindingModel>(result.Data.ToString());
                return Json(new
                {
                    Data = Common.RenderRazorViewToString(ControllerContext, "~/Views/Agreement/_Detail.cshtml", model),
                    Message = result.Message,
                    Status = result.Status,
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetProductList")]
        public JsonResult GetProductList(long? GroupId)
        {
            //List<Product> resultList;
            HttpResponseMessage response = APIRequestManager.webAPiClient.GetAsync("Agreement/GetProductList?GroupId=" + GroupId).Result;
            var resultList = response.Content.ReadAsAsync<List<Product>>().Result;
            //var result = response.Content.ReadAsAsync<List<ProductMaster>>().Result;
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("CreateUpdate")]
        [ValidateAntiForgeryToken]
        public JsonResult CreateUpdate(AgreementBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                //return Json(false, JsonRequestBehavior.AllowGet);
                return Json(new ErrorMessage { Message = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() });
            }
            HttpResponseMessage response = APIRequestManager.webAPiClient.PostAsJsonAsync("Agreement/CreateUpdate", model).Result;
            return Json(response.IsSuccessStatusCode, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("Delete")]
        public JsonResult Delete(long? id)
        {
            HttpResponseMessage response = APIRequestManager.webAPiClient.DeleteAsync("Agreement/Delete?id=" + id).Result;
            return Json(response.IsSuccessStatusCode, JsonRequestBehavior.AllowGet);
        }

    }
}