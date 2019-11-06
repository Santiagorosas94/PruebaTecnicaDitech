using PruebaTecnicaDitech.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnicaDitech.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            InicitalizateDB();
            return View();
        }


        private void InicitalizateDB()
        {
            using (var context = new MyContext())
            {
                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method
                //  to avoid creating duplicate seed data.
                context.Set<Ciudad>().AddOrUpdate(
                x => x.Codigo,
                new Ciudad { Codigo = 1, Descripcion = "Bogotá" },
                new Ciudad { Codigo = 2, Descripcion = "Cali" });

                context.Set<Vendedor>().AddOrUpdate(
                    x => x.Codigo,
                    new Vendedor
                    {
                        Codigo = 10,
                        Nombre = "JUAN",
                        Apellido = "POLANCO",
                        Numero_Identificacion = "1111111111",
                        Codigo_Ciudad = 1
                    },
                    new Vendedor
                    {
                        Codigo = 20,
                        Nombre = "PEDRO",
                        Apellido = "REYES",
                        Numero_Identificacion = "2222222222",
                        Codigo_Ciudad = 2
                    },
                   new Vendedor
                   {
                       Codigo = 30,
                       Nombre = "MARIA",
                       Apellido = "PAZ",
                       Numero_Identificacion = "3333333333",
                       Codigo_Ciudad = 1
                   },
                   new Vendedor
                   {
                       Codigo = 40,
                       Nombre = "LUNA",
                       Apellido = "MONROY",
                       Numero_Identificacion = "4444444444",
                       Codigo_Ciudad = 1
                   });

                context.SaveChanges();
            }
        }
    }
}
