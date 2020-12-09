using EstacionamentoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.DAL
{
    public class EstacionarDAO
    {
        private readonly Context _context;
        public EstacionarDAO(Context context) => _context = context;
        public List<Estacionar> Listar() => _context.Estacionados.ToList();
        public Estacionar BuscarPorId(int id) => _context.Estacionados.Find(id);

        public bool Cadastrar(Estacionar estacionar)
        {
            _context.Estacionados.Add(estacionar);
            _context.SaveChanges();
            return true;
        }
    }
}
