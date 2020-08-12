using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Mvc.Models;

namespace Projeto.Presentation.Mvc.Controllers
{
    public class AccountController : Controller
    {
        //método que abre a página inicial de Login
        public IActionResult Login()
        {
            return View();
        }

        //método que abre a página de Registro
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost] //método executado pelo SUBMIT do formulário
        public IActionResult Login(AccountLoginModel model, [FromServices] UsuarioRepository usuarioRepository)
        {
            //verificar se todos os campos foram validados com sucesso
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        [HttpPost] //método executado pelo SUBMIT do formulário
        public IActionResult Register(AccountRegisterModel model, [FromServices] UsuarioRepository usuarioRepository)
        {
            //verificar se todos os campos foram validados com sucesso
            if (ModelState.IsValid)
            {

            }

            return View();
        }
    }
}
