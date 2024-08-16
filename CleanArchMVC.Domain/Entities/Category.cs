using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Category : Entity
    {
        #region Propriedades
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        #endregion

        #region Construtores
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "é necessario que o id seja maior que 0");
            Id = id;
            ValidateDomain(name);
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
