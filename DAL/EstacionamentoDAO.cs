using EstacionamentoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.DAL
{
    public class EstacionamentoDAO
    {
        private readonly Context _context;
        public EstacionamentoDAO(Context context) => _context = context;
        public List<Estacionamento> Listar() => _context.Estacionamentos.ToList();
        public Estacionamento BuscarPorId(int id) => _context.Estacionamentos.Find(id);
        public List<Estacionamento> ListarPorUsuario(int id) => _context.Estacionamentos.Where(x => x.UsuarioCnpjId == id).ToList();
        public bool Cadastrar(Estacionamento estacionamento, UsuarioCNPJ usuariocnpj)
        {
            Estacionamento estacionamentoCad = new Estacionamento
            {
                Nome = estacionamento.Nome,
                Logradouro = estacionamento.Logradouro,
                Localidade = estacionamento.Localidade,
                Bairro = estacionamento.Bairro,
                Uf = estacionamento.Uf,
                Preco = estacionamento.Preco,
                Vagas = estacionamento.Vagas,
                UsuarioCnpj = usuariocnpj
            };
            _context.Estacionamentos.Add(estacionamentoCad);
            _context.SaveChanges();
            return true;
        }
        public Estacionamento BuscarPorNome(string nome) => _context.Estacionamentos.FirstOrDefault(x => x.Nome == nome);
        public void Remover(int id)
        {
            _context.Estacionamentos.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Estacionamento estacionamento)
        {
            _context.Estacionamentos.Update(estacionamento);
            _context.SaveChanges();
        }
    }
}
