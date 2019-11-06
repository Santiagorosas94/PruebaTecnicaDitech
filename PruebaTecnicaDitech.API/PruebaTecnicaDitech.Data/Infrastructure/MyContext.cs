using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace PruebaTecnicaDitech.Data
{
    public class MyContext : DbContext
    {
        public MyContext() : base(" name = Entities") { }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }
    }
}
