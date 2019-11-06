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
    [RoutePrefix("api/vendedor")]

    public class VendedorController : ApiController
    {
        [HttpGet]
        [Route("vendedores")]
        public GenericResponseVendedor GetVendedor()
        {
            GenericResponseVendedor result = null;
            try
            {
                List<Vendedor> vendedores = new List<Vendedor>();
                using (var context = new MyContext())
                {
                    vendedores = context.Vendedor.ToList();

                }

                if (vendedores != null)
                {
                    result = new GenericResponseVendedor() { Process = "Éxito", Vendedores = vendedores, Message = "Se obtuvieron todas los vendedores." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponseVendedor() { Process = "Advertencia", Vendedores = null, Message = "No se pudieron obtener todas los vendedores." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponseVendedor() { Process = "Error", Vendedores = null, Message = ex.ToString() };
            }
            return result;
        }
        [HttpGet]        
        public GenericResponseVendedor GetVendedorById(int Id)
        {
            GenericResponseVendedor result = null;
            try
            {
                Vendedor vendedor = new Vendedor();
                using (var context = new MyContext())
                {
                    vendedor = context.Vendedor.Where(x => x.Codigo.Equals(Id)).FirstOrDefault();

                }

                if (vendedor != null)
                {
                    result = new GenericResponseVendedor() { Process = "Éxito", Vendedor = vendedor, Message = "Se obtuvo el Vendedor correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponseVendedor() { Process = "Advertencia", Vendedor = null, Message = "No se pudo obtener el Vendedor." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponseVendedor() { Process = "Error", Vendedores = null, Message = ex.ToString() };
            }
            return result;
        }
        [HttpGet]
        [Route("vendedordocumento")]
        public GenericResponseVendedor GetVendedorByNumero(string nombre)
        {
            GenericResponseVendedor result = null;
            try
            {
                Vendedor vendedor = new Vendedor();
                using (var context = new MyContext())
                {
                    vendedor = context.Vendedor.Where(x => x.Numero_Identificacion.Equals(nombre)).FirstOrDefault();

                }

                if (vendedor != null)
                {
                    result = new GenericResponseVendedor() { Process = "Éxito", Vendedor = vendedor, Message = "Se obtuvo el Vendedor correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponseVendedor() { Process = "Advertencia", Vendedor = null, Message = "No se pudo obtener el Vendedor." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponseVendedor() { Process = "Error", Vendedor = null, Message = ex.ToString() };
            }
            return result;
        }
        [HttpPost]
        public GenericResponseVendedor AddVendedor(ViewModelVendedor model)
        {
            GenericResponseVendedor result = null;
            try
            {
                Vendedor vendedor = new Vendedor()
                {
                    Nombre=model.Nombre,
                    Apellido=model.Apellido,
                    Numero_Identificacion=model.Numero_Identificacion,
                    Codigo_Ciudad=model.Codigo_Ciudad
                };
                using (var context = new MyContext())
                {
                    vendedor = context.Vendedor.Add(vendedor);
                    context.SaveChanges();
                }

                if (vendedor != null)
                {
                    result = new GenericResponseVendedor() { Process = "Exito", Vendedor = null, Message = "Se agrego la Vendedor correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponseVendedor() { Process = "Advertencia", Vendedor = null, Message = "No se pudo agregar la Vendedor." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponseVendedor() { Process = "Error", Vendedor = null, Message = ex.ToString() };
            }
            return result;
        }
        [HttpPost]
        [Route("ActualizarVendedor")]
        public GenericResponseVendedor UpdateVendedor(ViewModelVendedor model)
        {
            GenericResponseVendedor result = null;
            try
            {
                Vendedor vendedor = new Vendedor();
         
                using (var context = new MyContext())
                {
                    vendedor = context.Vendedor.Where(x => x.Numero_Identificacion.Equals(model.Numero_Identificacion)).FirstOrDefault();
                }

                if (vendedor != null)
                {
                    vendedor = new Vendedor()
                    {
                        Codigo=model.Codigo,
                        Nombre = model.Nombre,
                        Apellido = model.Apellido,
                        Numero_Identificacion = model.Numero_Identificacion,
                        Codigo_Ciudad = model.Codigo_Ciudad
                    };
                    using (var context = new MyContext())
                    {
                        context.Entry(vendedor).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();

                    }
                    result = new GenericResponseVendedor() { Process = "Éxito", Vendedor = null, Message = "Se actualizo el vendedor correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponseVendedor() { Process = "Advertencia", Vendedor = null, Message = "No se pudo obtener el vendedor." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponseVendedor() { Process = "Error", Vendedor = null, Message = ex.ToString() };
            }
            return result;
        }
        [HttpGet]
        [Route("EliminarVendedor")]
        public GenericResponseVendedor DeleteVendedor(int Id)
        {
            GenericResponseVendedor result = null;
            try
            {
                Vendedor vendedor = new Vendedor();
                using (var context = new MyContext())
                {
                    vendedor = context.Vendedor.Where(x => x.Codigo.Equals(Id)).FirstOrDefault();
                }

                if (vendedor != null)
                {
                    using (var context = new MyContext())
                    {
                        context.Entry(vendedor).State = System.Data.Entity.EntityState.Deleted;
                        context.SaveChanges();
                    }
                    result = new GenericResponseVendedor() { Process = "Exito", Vendedor = null, Message = "Se elimino el vendedor correctamente." };
                }
                else
                {
                    var messageError = string.Join("; ", ModelState.Values
                                               .SelectMany(x => x.Errors)
                                               .Select(x => x.ErrorMessage));
                    result = new GenericResponseVendedor() { Process = "Advertencia", Vendedor = null, Message = "No se pudo obtener el vendedor." };
                }
            }
            catch (Exception ex)
            {
                result = new GenericResponseVendedor() { Process = "Error", Vendedor = null, Message = ex.ToString() };
            }
            return result;
        }

    }
}
