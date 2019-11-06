using PruebaTecnicaDitech.Data;
using PruebaTecnicaDitech.Model;
using PruebaTecnicaDitech.Model.GenericResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaTecnicaDitech.API.Controllers
{
    //[EnableCors(origins: "", headers: "", methods: "*")]
    [RoutePrefix("api/ciudad")]
    public class CiudadController : ApiController
    {
        [HttpGet]
        [Route("ciudades")]
        public GenericResponse GetCiudades()
        {
            GenericResponse result = null;
            try
            {
                List<Ciudad> ciudades = new List<Ciudad>();
                using (var context = new MyContext())
                {
                    ciudades = context.Ciudad.ToList();

                }

                if (ciudades != null)
                {
                    result = new GenericResponse() { Process = "Éxito", Ciudades = ciudades, Message = "Se obtuvieron todas las ciudades." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponse() { Process = "Advertencia", Ciudades = null, Message = "No se pudieron obtener todas las ciudades." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponse() { Process = "Error", Ciudades = null, Message = ex.ToString() };
            }
            return result;
        }
        [HttpGet]
        public GenericResponse GetCiudadById(int Id)
        {
            GenericResponse result = null;
            try
            {
                Ciudad ciudad = new Ciudad();
                using (var context = new MyContext())
                {
                    ciudad = context.Ciudad.Where(x => x.Codigo.Equals(Id)).FirstOrDefault();

                }

                if (ciudad != null)
                {
                    result = new GenericResponse() { Process = "Éxito", Ciudad = ciudad, Message = "Se obtuvo la ciudad correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponse() { Process = "Advertencia", Ciudades = null, Message = "No se pudo obtener la ciudad." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponse() { Process = "Error", Ciudades = null, Message = ex.ToString() };
            }
            return result;
        } 
        [HttpGet]
        [Route("ciudadnombre")]
        public GenericResponse GetCiudadByNombre(string nombre)
        {
            GenericResponse result = null;
            try
            {
                Ciudad ciudad = new Ciudad();
                using (var context = new MyContext())
                {
                    ciudad = context.Ciudad.Where(x => x.Descripcion.Equals(nombre)).FirstOrDefault();

                }

                if (ciudad != null)
                {
                    result = new GenericResponse() { Process = "Éxito", Ciudad = ciudad, Message = "Se obtuvo la ciudad correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponse() { Process = "Advertencia", Ciudades = null, Message = "No se pudo obtener la ciudad." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponse() { Process = "Error", Ciudades = null, Message = ex.ToString() };
            }
            return result;
        }
        [HttpPost]
        public GenericResponse AddCiudad(ViewModelCiudad model)
        {
            GenericResponse result = null;
            try
            {
                Ciudad ciudad = new Ciudad()
                {
                    Descripcion = model.Descripcion
                };
                using (var context = new MyContext())
                {
                    ciudad = context.Ciudad.Add(ciudad);
                    context.SaveChanges();
                }

                if (ciudad != null)
                {
                    result = new GenericResponse() { Process = "Exito", Ciudades = null, Message = "Se agrego la ciudad correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponse() { Process = "Advertencia", Ciudades = null, Message = "No se pudo agregar la ciudad." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponse() { Process = "Error", Ciudades = null, Message = ex.ToString() };
            }
            return result;
        }
        [HttpPost]
        [Route("ActualizarCiudad")]
        public GenericResponse UpdateCiudad(ViewModelCiudad model)
        {
            GenericResponse result = null;
            try
            {
                Ciudad ciudad = new Ciudad();
                using (var context = new MyContext())
                {
                    ciudad = context.Ciudad.Where(x=>x.Codigo.Equals(model.Codigo)).FirstOrDefault();
                }

                if (ciudad != null)
                {
                    ciudad.Descripcion = model.Descripcion;
                    using (var context = new MyContext())
                    {
                        context.Entry(ciudad).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();

                    }
                    result = new GenericResponse() { Process = "Éxito", Ciudades = null, Message = "Se actualizo la ciudad correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponse() { Process = "Advertencia", Ciudades = null, Message = "No se pudo obtener la ciudad." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponse() { Process = "Error", Ciudades = null, Message = ex.ToString() };
            }
            return result;
        }
        [HttpGet]
        [Route("EliminarCiudad")]
        public GenericResponse DeleteCiudad(int Id)
        {
            GenericResponse result = null;
            try
            {
                Ciudad ciudad = new Ciudad();
                using (var context = new MyContext())
                {
                    ciudad = context.Ciudad.Where(x=>x.Codigo.Equals(Id)).FirstOrDefault();
                }

                if (ciudad != null)
                {
                    using (var context = new MyContext())
                    {
                        context.Entry(ciudad).State = System.Data.Entity.EntityState.Deleted;
                        context.SaveChanges();
                    }
                    result = new GenericResponse() { Process = "Exito", Ciudades = null, Message = "Se elimino la ciudad correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponse() { Process = "Advertencia", Ciudades = null, Message = "No se pudo obtener la ciudad." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponse() { Process = "Error", Ciudades = null, Message = ex.ToString() };
            }
            return result;
        }
    }
}
