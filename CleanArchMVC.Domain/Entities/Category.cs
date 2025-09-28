using CleanArchMVC.BuildingBlocks.Core.DomainObjects;
using CleanArchMVC.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Category : Entity
    {
        #region Propriedades
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        #endregion

        #region Construtores

        public Category()
        {
            
        }
        public Category(string name)
        {
            ValidateDomain(name);
        }
        #endregion

        #region Metodos
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome Invalido. Digite o nome");
            DomainExceptionValidation.When(name.Length<=3, "Nome Invalido. o Nome precisa ter mais que 3 caracteres");
            
            Name = name;
        }

        public void Alterar(string name)
        {
            ValidateDomain(name);
        }
        #endregion


    }
}
