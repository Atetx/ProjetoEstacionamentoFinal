using System;
using System.Collections.Generic;
using System.Linq;
using EstacionamentoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoWeb.DAL
{
    public class UsuarioDAO
    {
        private readonly Context _context;
        public UsuarioDAO(Context context) => _context = context;
        public List<Usuario> Listar() => _context.Usuarios.ToList();
        public Usuario BuscarPorId(int id) => _context.Usuarios.Find(id);
        public Usuario BuscarPorEmail(string email) => _context.Usuarios.FirstOrDefault(x => x.Email == email);

        public bool Cadastrar(Usuario usuario)
        {
            if (BuscarPorEmail(usuario.Email) == null)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        internal List<Usuario> ListarPorNome(int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            _context.Usuarios.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
    }
}
