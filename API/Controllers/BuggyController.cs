using API.Errors;
using Infrastracture.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("notFound")]
        public IActionResult GetNotFoundRequest()
        {
            var product = _context.Products.Find(2001);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("ServerError")]
        public IActionResult GetServerError()
        {
            var product = _context.Products.Find(2001);
            var productToreturn = product.ToString();
            return Ok(new ApiResponse(500));
        }
        [HttpGet("BadRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("BadRequest/{id}")]
        public IActionResult GetBadRequest(int id)
        {

            return BadRequest(new ApiResponse(400));
        }
    }
}
