using System;
using XTLab.MvcApp.Data.Entities;

namespace XTLab.MvcApp.Application.Services;

  public class ProductService : List<Product>
    {
        public ProductService()
        {
            this.AddRange(new Product[] {
                new Product() { Id = 1, Name = "Iphone X", Price = 1000},
                new Product() { Id = 2, Name = "Samsung Abc", Price = 500},
                new Product() { Id = 3, Name = "Sony XYZ", Price = 800},
                new Product() { Id = 4, Name = "Nokia BCD", Price = 100},
            });
        }
    }
