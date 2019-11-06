using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace PruebaTecnicaDitech.Data
{
    public partial class Entities 
    {
        public static new Entities Create()
        {
            return new Entities();
        }

    
    }
}
