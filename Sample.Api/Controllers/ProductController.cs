using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sample.Api.Entities;
using Sample.Api.Persistence;
using Sample.Api.Requests;
using Sample.Api.Responses;

namespace Sample.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products
                .Include(x => x.Tags)
                .ToListAsync();
            return Ok(_mapper.Map<IList<ProductResponse>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _context.Products
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductResponse>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductRequest request)
        {
            var product = _mapper.Map<Product>(request);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {Id = product.Id}, _mapper.Map<ProductResponse>(product));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductRequest request)
        {
            var exists = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (exists == null)
            {
                return NotFound();
            }

            _mapper.Map(request, exists);
            _context.Products.Update(exists);

            await _context.SaveChangesAsync();
            return AcceptedAtAction(nameof(Get), new {Id = exists.Id}, _mapper.Map<ProductResponse>(exists));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<PatchProductRequest> patchDocument,
            [FromServices] IOptions<ApiBehaviorOptions> apiBehaviorOptions)
        {
            var exists = await _context.Products.Include(x=>x.Tags).FirstOrDefaultAsync(x => x.Id == id);
            if (exists == null)
            {
                return NotFound();
            }

            var productPatchDocument = _mapper.Map<JsonPatchDocument<Product>>(patchDocument);
            productPatchDocument.ApplyTo(exists, ModelState);

            var productValidator = new ProductValidator();
            var validationResult = await productValidator.ValidateAsync(exists);


            if (!ModelState.IsValid || !validationResult.IsValid)
            {
                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState, "");    
                }
                await _context.DisposeAsync();
                return apiBehaviorOptions.Value.InvalidModelStateResponseFactory(ControllerContext);
                // return BadRequest(ModelState);
            }

            _context.Products.Update(exists);

            await _context.SaveChangesAsync();

            return AcceptedAtAction(nameof(Get), new {Id = exists.Id}, _mapper.Map<ProductResponse>(exists));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await _context.Products.AnyAsync(x => x.Id == id)))
            {
                return NotFound();
            }

            _context.Products.Remove(new Product {Id = id});
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}