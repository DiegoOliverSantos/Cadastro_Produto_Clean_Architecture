using CleanArchMVC.BuildingBlocks.Core.DomainObjects;
using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Product : Entity
    {
        #region Propriedades
        public string Name { get; private set; }
        public string Descripion { get; private set; }
        public decimal Price { get; private set; }
        public decimal Stock { get; private set; }
        public string Image { get; private set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        #endregion

        #region Construtores

        public Product()
        {
            
        }
        public Product(string name,
               string descripion,
               decimal price,
               decimal stock,
               string image,
               Category category)
        {
            ValidateDomain(name,descripion, price, stock, image);
            Category = category;
            CategoryId = Category.ID;
        }
        #endregion

        #region Metodos
        private void ValidateDomain(string name, string description, decimal price, decimal stock, string image)
        {
            // name
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Nome Invalido. Digite o nome");
            DomainExceptionValidation.When(name.Length <= 3, 
                "Nome Invalido. o Nome precisa ter mais que 3 caracteres");
            // description
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), 
                "Descrição Invalida. Digite a descrição");
            DomainExceptionValidation.When(description.Length <= 5, 
                "Descrição Invalida. a Descrição precisa ter mais que 5 caracteres");
            // price
            DomainExceptionValidation.When(price < 0, 
                "Preço Invalido.O preço do produto precisa ser maior que 0");
            // stock
            DomainExceptionValidation.When(stock < 0, 
                "Estoque Invalido.O estoque do produto precisa ser maior que 0");
            // image
            DomainExceptionValidation.When(image?.Length > 250, 
                "Imagem Invalida. Quantidade de Caracteres muito grande.Maximo permitido 250 caracteres");
            Name = name;
            Descripion = description; 
            Price = price;
            Stock = stock;
            Image = image;
        }

        public void Alterar(string name, string description, decimal price, decimal stock, string image, Category category)
        {
            ValidateDomain(name, description, price, stock, image);
            Category = category;
            CategoryId = Category.ID;
        }
        #endregion
    }
}
