using Newtonsoft.Json;
using PruebaTecnicaDitech.Data;
using PruebaTecnicaDitech.Model.GenericResponse;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PruebaTecnicaDitech.UI.Controllers
{
    public class HomeController : Controller
    {
        public static class StaticItems
        {
            public static string EndPointa = "http://localhost:44305/Api/";
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}