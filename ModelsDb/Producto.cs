using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace ModelsDb
{
    [Table("Producto")]
    public class Producto
    {
        public int Id { get; set; }  
        public string Nombre { get; set; }
        public string SKU { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }
        public Tienda Tienda { get; set; }

        public static List<Producto> ListarPrud()
        {
            using (var ctx = new DbContextMigration())
            {
                return ctx.Producto.ToList();
            }
        }
    }
}
