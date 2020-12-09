using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamentoWeb.Models
{
    [Table("Estacionamento")]
    public class Estacionamento : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Vagas { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Preco { get; set; }
        public UsuarioCNPJ UsuarioCnpj { get; set; }
        public int UsuarioCnpjId { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Rua")]
        public string Logradouro { get; set; }

        [Display(Name = "Cidade")]
        public string Localidade { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Estado")]
        public string Uf { get; set; }
    }
}
