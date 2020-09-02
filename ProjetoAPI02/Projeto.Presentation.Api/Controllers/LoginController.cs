using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Api.Authorization;
using Projeto.Presentation.Api.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UsuarioLoginModel model,
            [FromServices] UsuarioRepository usuarioRepository,
            [FromServices] JwtConfiguration jwtConfiguration)
        {
            try
            {
                //consultar no banco de dados o usuario pelo email e senha
                var usuario = usuarioRepository
                    .GetByEmailAndSenha(model.Email, Criptografia.MD5Encrypt(model.Senha));

                //verificar se o usuario foi encontrado
                if (usuario != null)
                {
                    var result = new //objeto anônimo
                    {
                        userToken = jwtConfiguration.GenerateToken(usuario.Email),
                        userName = usuario.Nome,
                        userEmail = usuario.Email,
                        expires = DateTime.Now.AddDays(1)
                    };

                    return Ok(result);
                }
                else
                {
                    return StatusCode(403, "Acesso Negado. Usuário não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
