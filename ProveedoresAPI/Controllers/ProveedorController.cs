using Microsoft.AspNetCore.Mvc;
using ProveedoresAPI.Models;
using ProveedoresAPI.Repositories;


namespace ProveedoresAPI.Controllers
{   [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : Controller
    {
        private IProveedorCollection db = new ProveedorCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProveedors()
        {
            return Ok(await db.GetAllProveedors());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProveedorsDetails(string id)
        {
            return Ok(await db.GetProveedorById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProveedor([FromBody] Proveedor proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest();
            }

            if (proveedor.NIT == string.Empty)
            {
                ModelState.AddModelError("NIT", "El NIT no puede estar vacío");
            }

            await db.InsertProveedor(proveedor);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProveedor([FromBody] Proveedor proveedor, string id)
        {
            if (proveedor == null)
            {
                return BadRequest();
            }

            if (proveedor.NIT == string.Empty)
            {
                ModelState.AddModelError("NIT", "El NIT no puede estar vacío");
            }

            proveedor.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProveedor(proveedor);
            return Created("Created", true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(string id)
        {
            await db.DeleteProveedor(id);
            return NoContent();
        }
    }
}
