using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DLL.Model;
using DLL.Model.UoW;
using DLL.Repository;
using MediatR;

namespace BLL.Command.ProductCommand
{
    public class CreateProductCommand:  IRequest<Product>
    {
       
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public CreateProductCommand(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }


        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
        {
            private readonly IProductRepository _productRepository;
            private readonly IUnitOfWork _unitOfWork;

            public CreateProductCommandHandler(IProductRepository productRepository,IUnitOfWork unitOfWork)
            {
                _productRepository = productRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price
                };
                await _productRepository.CreateAsync(product);

                await _unitOfWork.Commit();
                return product;


            }
        }
    }
}
