using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product with Valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Product Name",
                                              "description valid", 
                                              10.80m, 
                                              1.000m,
                                              "image",
                                              new Category("category name"));
            action.Should()
                  .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with short name")]
        public void CreateProduct_ShortNameValue_ResultExceptionShortName()
        {
            Action action = () => new Product("Pr",
                                  "description valid",
                                  10.80m,
                                  1.000m,
                                  "image",
                                  new Category("category name"));
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Nome Invalido. o Nome precisa ter mais que 3 caracteres");
        }

        [Fact(DisplayName = "Create Product without name")]
        public void CreateProduct_WithOutName_ResultExceptionWithoutName()
        {
            Action action = () => new Product(null,
                                  "description valid",
                                  10.80m,
                                  1.000m,
                                  "image",
                                  new Category("category name"));
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Nome Invalido. Digite o nome");
        }

        [Theory(DisplayName = "Create Product with stoke negative")]
        [InlineData(-5)]
        public void CreateProduct_WithStokeNegative_ResultExceptionWithStokeInvalid(int value)
        {
            Action action = () => new Product("category",
                                  "description valid",
                                  10.80m,
                                  value,
                                  "image",
                                  new Category("category name"));
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Estoque Invalido.O estoque do produto precisa ser maior que 0");
        }

        [Theory(DisplayName = "Create product with out image")]
        [InlineData(null)]
        public void CreateProduct_WithoOutImage_ResultNotException(string image)
        {
            Action action = () => new Product("meia",
                                              "product meia for foot",
                                              8.90m,
                                              7.0m,
                                              image,
                                              new Category("category name"));

            action.Should()
                  .NotThrow<DomainExceptionValidation>();
        }

    }
}
