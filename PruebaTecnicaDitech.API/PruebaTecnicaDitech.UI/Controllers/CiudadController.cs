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
    public class CiudadController : Controller
    {
        public static class StaticItems
        {
            public static string EndPointa = "https://localhost:44305/Api/Ciudad/";
        }
        // GET: Ciudad
        public ActionResult Index()
        {
            try
            {
                List<Ciudad> ciudades = new List<Ciudad>();
                using (WebClient webClient = new WebClient())
                {

                    string response = string.Concat(StaticItems.EndPointa, "ciudades");
                    var json = webClient.DownloadString(response);
                    var lista = new JavaScriptSerializer().Deserialize<GenericResponse>(json);
                    ciudades = lista.Ciudades;
                }
                return View(ciudades);

            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult New()
        {

            return View();
        }
        [HttpPost]
        public ActionResult New(Ciudad model)
        {
            try
            {
                Ciudad ciudad = new Ciudad();
                using (WebClient webClient = new WebClient())
                {

                    string response = string.Concat(StaticItems.EndPointa, "ciudadnombre?nombre=", model.Descripcion);
                    var json = webClient.DownloadString(response);
                    var lista = new JavaScriptSerializer().Deserialize<GenericResponse>(json);
                    ciudad = lista.Ciudad;
                }

                if (ciudad == null)
                {
                    using (var http = new HttpClient())
                    {
                        var data = new ViewModelCiudad
                        {
                            Descripcion = model.Descripcion
                        };

                        var content = new StringContent(JsonConvert.SerializeObject(data));
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        var request = http.PostAsync("https://localhost:44305/Api/Ciudad/AddCiudad", content);

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
                Ciudad ciudad = new Ciudad();
                using (WebClient webClient = new WebClient())
                {

                    string response = string.Concat(StaticItems.EndPointa, "GetCiudadById?id=", Id);
                    var json = webClient.DownloadString(response);
                    var lista = new JavaScriptSerializer().Deserialize<GenericResponse>(json);
                    ciudad = lista.Ciudad;
                }
                if (ciudad != null)
                    return View(ciudad);
                else
                    return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult Edit(Ciudad model)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var data = new ViewModelCiudad
                    {
                        Codigo = model.Codigo,
                        Descripcion = model.Descripcion
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(data));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var request = http.PostAsync("https://localhost:44305/Api/Ciudad/ActualizarCiudad", content);

                    var response = request.Result.Content.ReadAsStringAsync().Result;

                    var status = new JavaScriptSerializer().Deserialize<GenericResponse>(response);

                    return RedirectToAction("Index");

                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        public ActionResult Delete(int? Id)
        {
            try
            {
                Ciudad ciudad = new Ciudad();
                using (WebClient webClient = new WebClient())
                {

                    string response = string.Concat(StaticItems.EndPointa, "EliminarCiudad?Id=", Id);
                    var json = webClient.DownloadString(response);
                    var lista = new JavaScriptSerializer().Deserialize<GenericResponse>(json);
                    return RedirectToAction("Index");
                }

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

    }
}