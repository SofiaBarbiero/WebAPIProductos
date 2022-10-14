using Microsoft.AspNetCore.Mvc;
using WebAPIProductos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private static ProductoController instancia;
        private static readonly List<Producto> lstProductos = new List<Producto>();
        public static ProductoController ObtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new ProductoController();
            }
            return instancia;
        }

        // GET: api/Producto
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lstProductos);
        }

        // GET api/Producto/
        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            foreach(Producto p in lstProductos)
            {
                if(p.Nombre.Equals(nombre))
                {
                    return Ok(p);
                }
            }
            return NotFound("El producto no existe");
        }

        // POST api/Producto
        [HttpPost]
        public IActionResult Post([FromBody] Producto value)
        {
            if(value == null || string.IsNullOrEmpty(value.Nombre))
            {
                return BadRequest("Error, datos incorrectos!");
            }
            lstProductos.Add(value);
            return Ok("Se agrego exitosamente");
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
