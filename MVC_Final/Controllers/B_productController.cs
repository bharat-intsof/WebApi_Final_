using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC_Final.Models;

namespace MVC_Final.Controllers
{
    public class B_productController : Controller
    {
        // GET: B_product
        public ActionResult Index()
        {
            IEnumerable<MVC_Product> prodlist;
            HttpResponseMessage response = Global_Class.userClient.GetAsync("B_product").Result;
            prodlist = response.Content.ReadAsAsync<IEnumerable<MVC_Product>>().Result;
            return View(prodlist);
        }

        public ActionResult Edit(int id=0)
        {
            if(id==0)
                return View(new MVC_Product());
            else
            {
                HttpResponseMessage response = Global_Class.userClient.GetAsync("B_product/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVC_Product>().Result);
            }
        }
        [HttpPost]
        public ActionResult Edit(MVC_Product prd)
        {
            if(prd.product_id == 0)
            {
                HttpResponseMessage response = Global_Class.userClient.PostAsJsonAsync("B_product", prd).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = Global_Class.userClient.PutAsJsonAsync("B_product/"+prd.product_id,prd).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Global_Class.userClient.DeleteAsync("B_product/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}