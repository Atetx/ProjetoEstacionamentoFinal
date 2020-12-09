using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.Models
{
    public class Pagamento : BaseModel
    {
        public int PagamentoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public Estacionamento Valor { get; set; }

    }
}
