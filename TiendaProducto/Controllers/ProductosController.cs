using ModelsDb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TiendaProducto.Controllers
{
    public class ProductosController : ApiController
    {
        private DbContextMigration dbContext = new DbContextMigration();

        //Visualizar los registro de los productos
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            using (DbContextMigration productoEntities = new DbContextMigration())
            {
                return productoEntities.Producto.ToList();
            }
        }
        //Visualizar solo un registro por id(api/producto/id) 
        [HttpGet]
        public Producto Get(int id)
        {
            using(DbContextMigration productoEntities = new DbContextMigration())
            {
                return productoEntities.Producto.FirstOrDefault(e => e.Id == id);
            }
        }
        //Grabar registros de productos nuevo
        [HttpPost]
        public IHttpActionResult AgregarProducto([FromBody]Producto pro)
        {
            if (ModelState.IsValid)
            {
                dbContext.Producto.Add(pro);
                dbContext.SaveChanges();
                return Ok(pro);
            }
            else
            {
                return BadRequest();
            }
        }
        //Editar registro
        [HttpPut]
        public IHttpActionResult ActualizarProducto(int id, [FromBody]Producto usu)
        {
            if (ModelState.IsValid)
            {
                var productoExiste = dbContext.Producto.Count(c => c.Id == id) > 0;

                if (productoExiste)
                {
                    dbContext.Entry(usu).State = EntityState.Modified;
                    dbContext.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
