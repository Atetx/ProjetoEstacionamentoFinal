using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstacionamentoWeb.Models;
using Microsoft.AspNetCore.Identity;
using EstacionamentoWeb.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace EstacionamentoWeb.Controllers
{
    public class UsuarioCNPJController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UsuarioCNPJDAO _usuarioCNPJDAO;
        private readonly VeiculoDAO _veiculoDAO;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _hosting;

        public UsuarioCNPJController(UsuarioCNPJDAO usuarioCNPJDAO, IWebHostEnvironment hosting, VeiculoDAO veiculoDAO, Context context, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContext)
        {
            _context = context;
            _usuarioCNPJDAO = usuarioCNPJDAO;
            _veiculoDAO = veiculoDAO;
            _hosting = hosting;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = httpContext;
        }
        public IActionResult Index()
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                ViewBag.Title = "Gerenciamento de Usuarios";
                return View(_usuarioCNPJDAO.Listar());
            }
            return RedirectToAction("Login", "Usuario");
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar([Bind("Tipo,Fantasia,Capital_social,Situacao,Cnpj,Senha,Email,Id,CriadoEm")] UsuarioCNPJ usuarioCNPJ)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = usuarioCNPJ.Email,
                    Email = usuarioCNPJ.Email
                };
                IdentityResult resultado = await _userManager.CreateAsync(user, usuarioCNPJ.Senha);
                if (resultado.Succeeded)
                {
                    _context.Add(usuarioCNPJ);
                    await _context.SaveChangesAsync();
                    return Redirect(nameof(Index));
                }
                AddErros(resultado);
            }
            return View(usuarioCNPJ);
        }
        public void AddErros(IdentityResult resultado)
        {
            foreach (IdentityError erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }
        public IActionResult Edit(int id)
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                return View(_usuarioCNPJDAO.BuscarPorId(id));
            }
            return RedirectToAction("Login", "UsuarioCNPJ");
        }
        [HttpPost]
        public IActionResult Edit(UsuarioCNPJ usuario)
        {
            _usuarioCNPJDAO.Alterar(usuario);
            return RedirectToAction("Index", "UsuarioCNPJ");
        }

        public IActionResult Delete(int id)
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                _usuarioCNPJDAO.Remover(id);
                return RedirectToAction("Index", "UsuarioCNPJ");
            }
            return RedirectToAction("Login", "Usuario");
        }
    }
}
