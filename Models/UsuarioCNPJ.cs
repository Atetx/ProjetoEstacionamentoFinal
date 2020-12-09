using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.Models
{
    public class UsuarioCNPJ : BaseModel
    {
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
        [Display(Name = "Nome")]
        public string Fantasia { get; set; }
        [Display(Name = "Capital")]
        public string Capital_social { get; set; }
        [Display(Name = "Situacao")]
        public string Situacao { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(14, ErrorMessage = "CNPJ deve conter 14 digitos!")]
        [MaxLength(14, ErrorMessage = "CNPJ deve conter 14 digitos!")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "A senha deve conter ao menos 5 caracteres")]
        [MaxLength(15, ErrorMessage = "A senha deve conter no máximo 15 caracteres")]
        public string Senha { get; set; }
        public List<Estacionamento> Estacionamentos { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Email { get; set; }
    }
}
