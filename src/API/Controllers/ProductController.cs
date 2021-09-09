using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Command.ProductCommand;
using BLL.Query.ProductQuery;
using DLL.Model;
using DLL.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

       

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct(Product product)
        {
            return Ok(await Mediator.Send(new CreateProductCommand(product.Name,product.Description,product.Price)));
        }
    }
}
