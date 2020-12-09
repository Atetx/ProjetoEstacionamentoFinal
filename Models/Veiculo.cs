using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.Models
{
    [Table("Veiculo")]
    public class Veiculo : BaseModel
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(7, ErrorMessage = "Favor inserir 7 Caracteres")]
        [MaxLength(7, ErrorMessage = "Favor inserer 7 Caracteres")]
        public string Placa { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

    }
}
