using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace miApiCrud.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ContactoController : ControllerBase
    {

        private readonly AplicationDbContext context;

        public ContactoController(AplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ContactoController>
        [HttpGet]
        public async Task<ActionResult<List<Contacto>>> Get()
        {
            return await context.Contactos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Contacto contacto)
        {
            context.Add(contacto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(Contacto contacto, int Id)
        {
            if (contacto.id != Id)
            {
                return BadRequest("El id del contacto no coincide");
            }

            var existe = await context.Contactos.AnyAsync(Contacto => Contacto.id == Id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(contacto);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete ]

        [Route("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await context.Contactos.AnyAsync(Contacto => Contacto.id == Id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Contacto() { id = Id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }

}




