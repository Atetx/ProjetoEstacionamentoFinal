using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using EstacionamentoWeb.DAL;
using EstacionamentoWeb.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace EstacionamentoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UsuarioDAO _usuarioDAO;
        private readonly VeiculoDAO _veiculoDAO;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _hosting;

        public UsuarioController(UsuarioDAO usuarioDAO, IWebHostEnvironment hosting, VeiculoDAO veiculoDAO, Context context, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContext)
        {
            _context = context;
            _usuarioDAO = usuarioDAO;
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
                return View(_usuarioDAO.Listar());
            }
            return RedirectToAction("Login", "Usuario");
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([Bind("Nome,Cpf,Email,Senha,Id,CriadoEm,ConfirmacaoSenha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = usuario.Email,
                    Email = usuario.Email
                };
                IdentityResult resultado = await _userManager.CreateAsync(user, usuario.Senha);
                if (resultado.Succeeded)
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return Redirect(nameof(Index));
                }
                AddErros(resultado);
            }
            return View(usuario);
        }
        public void AddErros(IdentityResult resultado)
        {
            foreach (IdentityError erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind("Email,Senha")] Usuario usuario)
        {
            var logado = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Senha, false, false);
            if (logado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Login ou senha incorretos");
            return View(usuario);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remover(int id)
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                _usuarioDAO.Remover(id);
                return RedirectToAction("Index", "Usuario");
            }
            return RedirectToAction("Login", "Usuario");
        }
        public IActionResult Alterar(int id)
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                return View(_usuarioDAO.BuscarPorId(id));
            }
            return RedirectToAction("Login", "Usuario");
        }
        [HttpPost]
        public IActionResult Alterar(Usuario usuario)
        {
            _usuarioDAO.Alterar(usuario);
            return RedirectToAction("Index", "Usuario");
        }
    }
}