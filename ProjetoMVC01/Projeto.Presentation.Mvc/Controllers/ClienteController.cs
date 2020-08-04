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
                    //verificar se o cpf do cliente já encontra-se cadastrado
                    if (clienteRepository.GetByCpf(model.Cpf) != null)
                    {
                        throw new Exception("O CPF informado já existe.");
                    }

                    //verificar se o email do cliente já encontra-se cadastrado
                    if (clienteRepository.GetByEmail(model.Email) != null)
                    {
                        throw new Exception("O email informado já encontra-se cadastrado. Informe outro email.");
                    }

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
        public IActionResult Consulta([FromServices] ClienteRepository clienteRepository)
        {
            var clientes = new List<Cliente>();
            try
            {
                clientes = clienteRepository.GetAll();
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Erro: " + e.Message;
            }
            return View(clientes);
        }

        //método de ação
        public IActionResult Exclusao(int id, [FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                var cliente = clienteRepository.GetById(id);

                //verificar se o cliente foi obtido no banco de dados
                if (cliente != null)
                {
                    //excluindo o cliente
                    clienteRepository.Delete(cliente);
                    TempData["MensagemSucesso"] = "Cliente excluído com sucesso.";                    
                }
                else
                {
                    throw new Exception("Cliente não encontrado.");
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Erro: " + e.Message;
            }

            //redirecionar de volta para a página de consulta.
            return RedirectToAction("Consulta");
        }

        public IActionResult Edicao(int id)
        {
            return View(); //abrir uma página
        }
    }
}
