using System;
using PruebaTecnicaDitech.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PruebaTecnicaDitech.Model.GenericResponse
{
    public class GenericResponse
    {
        public enum ResponseType
        {
            Exito = 1,
            Error,
            Advertencia
        }
        public Ciudad Ciudad { get; set; }
        public List<Ciudad> Ciudades { get; set; }
        public string Process { get; set; }
        public string Message { get; set; }
    } 
    
    public class GenericResponseVendedor
    {
        public enum ResponseType
        {
            Exito = 1,
            Error,
            Advertencia
        }
        public Vendedor Vendedor { get; set; }
        public List<Vendedor> Vendedores { get; set; }
        public string Process { get; set; }
        public string Message { get; set; }
    }


}