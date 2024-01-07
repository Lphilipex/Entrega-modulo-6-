using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiproject.Models;
using Microsoft.AspNetCore.Cors;
using apiproject.Models;

namespace apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {

        private readonly DestinoDbContext _context;

        public DestinoController(DestinoDbContext context)
        {
            _context = context;
        }


        
        [EnableCors("_myAllowSpecificOrigins")] // NEW - CORS
        [HttpGet]
        public IEnumerable<Destinos> GetDestinos()
        {
            return _context.Destinos;
        }


       
        [HttpGet("{id}")]
        public IActionResult GetDestinoPorId(int id)
        {
            Destinos destino = _context.Destinos.SingleOrDefault(modelo => modelo.DestinoId == id);
            if (destino == null)
            {
                return NotFound();
            }
            return new ObjectResult(destino);
        }


        [HttpPost]
        public IActionResult CriarDestino(Destinos item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Destinos.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

        }


        [HttpPut("{id}")]
        public IActionResult AtualizaDestino(int id, Destinos item)
        {
            if (id != item.DestinoId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaDestino(int id)
        {
            var destino = _context.Destinos.SingleOrDefault(m => m.DestinoId == id);


            if (destino == null)
            {
                return BadRequest();
            }


            _context.Destinos.Remove(destino);
            _context.SaveChanges();
            return Ok(destino);
        }




    }
}
