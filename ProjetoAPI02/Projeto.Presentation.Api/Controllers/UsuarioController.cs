using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Api.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UsuarioCadastroModel model,
            [FromServices] UsuarioRepository usuarioRepository)
        {
            try
            {
                //verificar se o email informado já existe no banco de dados
                if (usuarioRepository.GetByEmail(model.Email) != null)
                {
                    //HTTP 403 -> Forbidden
                    return StatusCode(403, "O email informado já encontra-se cadastrado.");
                }
                else
                {
                    //cadastrar o usuario
                    var usuario = new Usuario();
                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Senha = Criptografia.MD5Encrypt(model.Senha);
                    usuario.DataCriacao = DateTime.Now;

                    usuarioRepository.Insert(usuario);

                    //HTTP 201 -> Sucesso, Criado!
                    return StatusCode(201, "Usuário cadastrado com sucesso");
                }
            }
            catch (Exception e)
            {
                //HTTP 500 -> Internal Server Error
                return StatusCode(500, e.Message);
            }
        }
    }
}