using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.Models
{
    [Table("Estacionar")]
    public class Estacionar : BaseModel
    {
        public Usuario Usuario { get; set; }
        public UsuarioCNPJ UsuarioCNPJ { get; set; }
        public Veiculo Veiculo { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public int EstacionamentoId { get; set; }
        public int QualquerCoisa { get; set; }
    }
}