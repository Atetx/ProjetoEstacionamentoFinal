using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EstacionamentoWeb.DAL;
using EstacionamentoWeb.Models;
using EstacionamentoWeb.Utils;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using Intuit.Ipp.Core.Configuration;

namespace EstacionamentoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioDAO _usuarioDAO;
        private readonly VeiculoDAO _veiculoDAO;
        private readonly Sessao _sessao;
        public HomeController(UsuarioDAO usuarioDAO, VeiculoDAO veiculoDAO, Sessao sessao)
        {
            _usuarioDAO = usuarioDAO;
            _veiculoDAO = veiculoDAO;
            _sessao = sessao;
        }
        public IActionResult Index(int id)
        {
            List<Usuario> usuarios = id == 0 ? _usuarioDAO.Listar() : _usuarioDAO.ListarPorNome(id);
            return View(usuarios);
        }
    }
    
}
