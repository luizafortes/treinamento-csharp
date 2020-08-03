using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Mvc.Models;
using Projeto.Repository.Entities;
using Projeto.Repository.Repositories;

namespace Projeto.Presentation.Mvc.Controllers
{
    public class ClienteController : Controller
    {
        //Abrir a página
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost] //método recebe o SUBMIT do formulário (envio dos dados)
        public IActionResult Cadastro(ClienteCadastroModel model, [FromServices] ClienteRepository clienteRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //criando um objeto da classe de entidade
                    var cliente = new Cliente();
                    cliente.Nome = model.Nome;
                    cliente.Email = model.Email;
                    cliente.Cpf = model.Cpf;

                    clienteRepository.Create(cliente); //gravando o cliente no banco de dados

                    //exibir mensagem de sucesso
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário
                }
                catch (Exception e)
                {
                    //exibir mensagem de erro
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }

            }
            return View();
        }

        //Abrir a página
        public IActionResult Consulta()
        {
            return View();
        }


    }
}
