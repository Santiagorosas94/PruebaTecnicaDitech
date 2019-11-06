using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaTecnicaDitech.Data
{
    public class Ciudad
    {
        [Key]
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
