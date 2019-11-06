using Newtonsoft.Json;
using PruebaTecnicaDitech.Data;
using PruebaTecnicaDitech.Model.GenericResponse;
using PruebaTecnicaDitech.UI.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace PruebaTecnicaDitech.UI.Controllers
{
    public class VendedorController : Controller
    {
        // GET: Vendedor
        public static class StaticItems
        {
            public static string EndPointa = "https://localhost:44305/Api/Vendedor/";
        }
        // GET: Ciudad
        public ActionResult Index()
        {
            try
            {
                List<Vendedor> vendedores = new List<Vendedor>();
                using (WebClient webClient = new WebClient())
                {

                    string response = string.Concat(StaticItems.EndPointa, "vendedores");
                    var json = webClient.DownloadString(response);
                    var lista = new JavaScriptSerializer().Deserialize<GenericResponseVendedor>(json);
                    vendedores = lista.Vendedores;
                }
                return View(vendedores);

            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult New()
        {
            llenarViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult New(Vendedor model)
        {
            try
            {
                Vendedor vendedor = new Vendedor();
                using (WebClient webClient = new WebClient())
                {

                    string response = string.Concat(StaticItems.EndPointa, "vendedordocumento?nombre=", model.Numero_Identificacion);
                    var json = webClient.DownloadString(response);
                    var lista = new JavaScriptSerializer().Deserialize<GenericResponseVendedor>(json);
                    vendedor = lista.Vendedor;
                }

                if (vendedor == null)
                {
                    using (var http = new HttpClient())
                    {
                        var data = new ViewModelVendedor
                        {
                            Nombre = model.Nombre,
                            Apellido = model.Apellido,
                            Numero_Identificacion = model.Numero_Identificacion,
                            Codigo_Ciudad = model.Codigo_Ciudad
                        };

                        var content = new StringContent(JsonConvert.SerializeObject(data));
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        var request = http.PostAsync("https://localhost:44305/Api/Vendedor/AddVendedor", content);

                        var response = request.Result.Content.ReadAsStringAsync().Result;

                        var status = new JavaScriptSerializer().Deserialize<GenericResponse>(response);
                        if (status.Process == "Exito")
                            return RedirectToAction("Index");
                        else
                            return View(model);
                    }
                }
                else
                    return View(model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            try
            {
                llenarViewBag();
                Vendedor vendedor = new Vendedor();
                using (WebClient webClient = new WebClient())
                {

                    string response = string.Concat(StaticItems.EndPointa, "GetVendedorById?id=", Id);
                    var json = webClient.DownloadString(response);
                    var lista = new JavaScriptSerializer().Deserialize<GenericResponseVendedor>(json);
                    vendedor = lista.Vendedor;
                }
                if (vendedor != null)
                    return View(vendedor);
                else
                    return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult Edit(Vendedor model)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var data = new ViewModelVendedor
                    {
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Apellido = model.Apellido,
                        Numero_Identificacion = model.Numero_Identificacion,
                        Codigo_Ciudad = model.Codigo_Ciudad
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(data));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var request = http.PostAsync("https://localhost:44305/Api/Vendedor/ActualizarVendedor", content);

                    var response = request.Result.Content.ReadAsStringAsync().Result;

                    var status = new JavaScriptSerializer().Deserialize<GenericResponseVendedor>(response);

                    return RedirectToAction("Index");

                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        public string Delete(int? Id)
        {
            try
            {
                if (Id.HasValue)
                {
                    Vendedor vendedor = new Vendedor();
                    using (WebClient webClient = new WebClient())
                    {
                        string response = string.Concat(StaticItems.EndPointa, "EliminarVendedor?Id=", Id);
                        var json = webClient.DownloadString(response);
                        var lista = new JavaScriptSerializer().Deserialize<GenericResponseVendedor>(json);
                        return "Success";
                    }
                }
                else
                    return "Fail";


            }
            catch (System.Exception ex)
            {

                throw;
            }
        }


        public void llenarViewBag()
        {
            List<Ciudad> ciudades = new List<Ciudad>();
            using (WebClient webClient = new WebClient())
            {

                string response = "https://localhost:44305/Api/ciudad/ciudades";
                var json = webClient.DownloadString(response);
                var lista = new JavaScriptSerializer().Deserialize<GenericResponse>(json);
                ciudades = lista.Ciudades;
            }
            ViewBag.Ciudades = ciudades;

        }
    }
}