using System.ComponentModel.DataAnnotations;

namespace Farmax.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome fantasia")]
        public string Fantasia { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CNPJ")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone")]
        public string Telefone { get; set; }

        public List<Produto> Produtos { get; set; }
        
    }
}
