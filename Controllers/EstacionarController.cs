using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstacionamentoWeb.Models;
using EstacionamentoWeb.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace EstacionamentoWeb.Controllers
{
    public class EstacionarController : Controller
    {
        private readonly Context _context;
        private readonly UsuarioDAO _usuarioDAO;
        private readonly UsuarioCNPJDAO _usuarioCNPJDAO;
        private readonly VeiculoDAO _veiculoDAO;
        private readonly EstacionamentoDAO _estacionamentoDAO;
        private readonly EstacionarDAO _estacionarDAO;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _hosting;

        public EstacionarController(UsuarioCNPJDAO usuarioCNPJDAO, IHttpContextAccessor httpContext, IWebHostEnvironment hosting, Context context, UsuarioDAO usuarioDAO, VeiculoDAO veiculoDAO, EstacionamentoDAO estacionamentoDAO, EstacionarDAO estacionarDAO)
        {
            _context = context;
            _usuarioDAO = usuarioDAO;
            _veiculoDAO = veiculoDAO;
            _estacionamentoDAO = estacionamentoDAO;
            _estacionarDAO = estacionarDAO;
            _hosting = hosting;
            _httpContext = httpContext;
            _usuarioCNPJDAO = usuarioCNPJDAO;
        }

        // GET: Estacionar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estacionados.ToListAsync());
        }
        // GET: Estacionar/Create
        public IActionResult Cadastrar()
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                var name = User.Identity.Name;
                Usuario usuario = _usuarioDAO.BuscarPorEmail(name);
                int usuarioId = usuario.Id;
                UsuarioCNPJ usuarioCNPJ = _usuarioCNPJDAO.BuscarPorEmail(email);
                int usuarioCnpjId = usuarioCNPJ.Id;
                ViewBag.Veiculos = new SelectList(_veiculoDAO.ListarPorUsuario(usuarioId), "Id", "Modelo");
                ViewBag.Estacionamentos = new SelectList(_estacionamentoDAO.ListarPorUsuario(usuarioCnpjId), "Id", "Nome");
                return View();
            }
            return RedirectToAction("Login", "Usuario");
        }
        [HttpPost]
        public IActionResult Cadastrar(Estacionar estacionar)
        {
            var email = User.Identity.Name;
            Usuario usuario = _usuarioDAO.BuscarPorEmail(email);
            estacionar.Veiculo = _veiculoDAO.BuscarPorId(estacionar.QualquerCoisa);
            estacionar.Estacionamento = _estacionamentoDAO.BuscarPorId(estacionar.EstacionamentoId);
            estacionar.Usuario = usuario;
            if (_estacionarDAO.Cadastrar(estacionar))
            {
                return RedirectToAction("Index", "Estacionar");
            }
            return View(estacionar);
        }

        public IActionResult Retirar(int id)
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                Estacionar estacionado = _estacionarDAO.BuscarPorId(id);
                int entrada = estacionado.CriadoEm.Hour;
                int saida = DateTime.Now.Hour;
                int tempo = saida - entrada;
                int est = estacionado.EstacionamentoId;
                Estacionamento estacionamento = _estacionamentoDAO.BuscarPorId(est);
                double valor = estacionamento.Preco;
                if (tempo <= 1)
                {
                    ViewBag.Preco = valor; return View();
                }
                else if (tempo > 1 && tempo <= 5)
                {
                    ViewBag.Preco = valor * 2; return View();
                }
                else if (tempo > 5)
                {
                    ViewBag.Preco = valor * 4;
                }
                ViewBag.PrecoPadrao = valor; return View();
            }
            return RedirectToAction("Login", "Usuario");
        }

    }
}
