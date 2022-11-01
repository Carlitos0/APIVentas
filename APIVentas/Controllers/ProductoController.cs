using APIVentas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVentas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> getProductos()
        {
            return await context.Productos.Include(x => x.Categoria).ToListAsync();
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Producto>> getProductoById([FromRoute]string codigo)
        {
            var producto = await context.Productos.FindAsync(codigo);
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> saveProducto([FromBody] Producto producto)
        {
            var existe = await context.Productos.AnyAsync(x => x.Id == producto.Id);
            if (!existe)
            {
                context.Add(producto);
                await context.SaveChangesAsync();
                string message = "Producto agregado correctamente";
                return Ok(new
                {
                    message,
                    producto
                });
            }
            return BadRequest("El codigo ya está en uso");
        }

        [HttpPatch("{codigo}")]
        public async Task<ActionResult> updateProducto([FromBody] Producto producto, int codigo)
        {
            var existe = await context.Productos.AnyAsync(x => x.Id == codigo);
            if(producto.Id != codigo)
            {
                return BadRequest($"El codigo {codigo} de la url no coincide con la de los registros");
            }
            if (!existe)
            {
                return NotFound("No existe el registro especficado");
            }
            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> deleteProducto([FromRoute] int codigo)
        {
            var existe = await context.Productos.AnyAsync(x => x.Id == codigo);
            if (!existe)
            {
                return BadRequest("No existe el registro especficado");
            }
            context.Remove(new Producto() { Id = codigo });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
