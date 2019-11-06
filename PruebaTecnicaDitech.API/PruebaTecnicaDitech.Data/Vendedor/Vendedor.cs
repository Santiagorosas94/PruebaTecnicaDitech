using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaDitech.Data
{
    public class Vendedor
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Numero_Identificacion { get; set; }
        public int Codigo_Ciudad { get; set; }

        public virtual Ciudad Ciudad { get; set; }

    }
}
