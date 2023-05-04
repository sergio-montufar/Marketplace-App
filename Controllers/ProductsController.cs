using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using marketplaceapp.Models;

namespace marketplaceapp.Controllers {
    [Route("/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context) {
            _context = context;
        }

        // GET: /Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() {
            if (_context.Products == null) {
              return NotFound();
            }
            return await _context.Products.ToListAsync();
        }

        // GET: /Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id) {
            if (_context.Products == null) {
              return NotFound();
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null) {
                return NotFound();
            }

            return product;
        }

        // PUT: /Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product product) {
            if (id != product.Id) {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!ProductExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: /Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product) {
            if (_context.Products == null) {
              return Problem("Entity set 'ProductContext.Products' is null.");
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE: Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id) {
            if (_context.Products == null) {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null) {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(long id) {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
