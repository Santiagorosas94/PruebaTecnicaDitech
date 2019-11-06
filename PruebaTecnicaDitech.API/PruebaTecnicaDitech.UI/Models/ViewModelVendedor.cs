using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnicaDitech.UI.Models
{
    public class ViewModelVendedor
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Numero_Identificacion { get; set; }
        public int Codigo_Ciudad { get; set; }
    }
}