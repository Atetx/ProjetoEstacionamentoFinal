using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.Models
{
    public class BaseModel
    {
        public BaseModel() => CriadoEm = DateTime.Now;

        [Key]
        public int Id { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
