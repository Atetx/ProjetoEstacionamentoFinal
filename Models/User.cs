using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.Models
{
    public class User : IdentityUser
    {
        public User() => CriadoEm = DateTime.Now;
        public DateTime CriadoEm { get; set; }
    }
}
