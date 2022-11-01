using APIVentas.Entities;
using APIVentas.Functions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVentas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext context;

        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> allCategorias()
        {
            return await context.Categorias.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> addCategoria([FromBody] Categoria categoria)
        {
            try
            {
                //categoria.CodigoCategoria =  categoria.CategoriaName.Substring(0,2).ToUpper() + "000";
                context.Add(categoria);
                await context.SaveChangesAsync();
                string message = "Registro guardado con éxito";
                return Ok(new
                {
                    message,
                    categoria
                });
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult> updateCategoria([FromBody] Categoria categoria, [FromRoute] int codigo)
        {
            //try
            //{
                var existe = await context.Categorias.AnyAsync(x => x.Id == codigo);
                if (categoria.Id != codigo)
                {
                    return BadRequest("Los codigos no coinciden");
                }
                if (!existe) return NotFound();
                context.Update(categoria);
                await context.SaveChangesAsync();
                return Ok();
            //}
            //catch(Exception err)
            //{
            //    return BadRequest(err.Message);
            //}   
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> deleteCategoria([FromRoute] int codigo)
        {
            var existe = await context.Categorias.AnyAsync(x => x.Id == codigo);
            if (!existe) return NotFound();
            context.Remove(new Categoria {Id = codigo});
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
