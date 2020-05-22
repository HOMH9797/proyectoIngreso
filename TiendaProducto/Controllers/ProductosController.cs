using ModelsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TiendaProducto.Controllers
{
    public class ProductosController : ApiController
    {
        private DbContextMigration dbContext = new DbContextMigration();

        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            using (DbContextMigration productoEntities = new DbContextMigration())
            {
                return productoEntities.Producto.ToList();
            }
        }
    }
}
