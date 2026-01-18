using CleanArchMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Descricao")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        [DisplayName("Preco")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Stoke is Required")]
        [Range(1,9999)]
        [DisplayName("Estoque")]
        public int Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Imagem")]
        public string Image { get; set; }
        [DisplayName("Desativado")]
        public bool Disable { get; set; }
        public Category Category { get; set; }

        [DisplayName()]
        public Guid CategoryId { get; set; }
    }
}
