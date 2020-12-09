using EstacionamentoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.DAL
{
    public class UsuarioCNPJDAO
    {
        private readonly Context _context;
        public UsuarioCNPJDAO(Context context) => _context = context;
        public List<UsuarioCNPJ> Listar() => _context.UsuariosCnpj.ToList();
        public UsuarioCNPJ BuscarPorId(int id) => _context.UsuariosCnpj.Find(id);
        public UsuarioCNPJ BuscarPorEmail(string email) => _context.UsuariosCnpj.FirstOrDefault(x => x.Email == email);

        public bool Cadastrar(UsuarioCNPJ usuario)
        {
            if (BuscarPorEmail(usuario.Email) == null)
            {
                _context.UsuariosCnpj.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        internal List<UsuarioCNPJ> ListarPorNome(int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            _context.UsuariosCnpj.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(UsuarioCNPJ usuario)
        {
            _context.UsuariosCnpj.Update(usuario);
            _context.SaveChanges();
        }
    }
}

