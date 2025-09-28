using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create Category with Valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category("Category Name");
            action.Should()
                  .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category with short name")]
        public void CreateCategory_ShortNameValue_ResultExceptionShortName()
        {
            Action action = () => new Category("Ca");
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Nome Invalido. o Nome precisa ter mais que 3 caracteres");
        }

        [Fact(DisplayName = "Create Category without name")]
        public void CreateCategory_WithOutName_ResultExceptionWithoutName()
        {
            Action action = () => new Category("");
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Nome Invalido. Digite o nome");
        }


    }
}
