using System.ComponentModel.DataAnnotations;

namespace Farmax.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade")]
        public string Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preco")]
        public string Preco { get; set; }

        public Fornecedor fornecedor { get; set; }

    }
}
