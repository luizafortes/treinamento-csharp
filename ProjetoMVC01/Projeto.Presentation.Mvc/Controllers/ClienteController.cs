﻿using System;
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

        [HttpPost] //método recebe o SUBMIT
        public IActionResult Consulta(string nome, [FromServices] ClienteRepository clienteRepository)
        {
            var clientes = new List<Cliente>();
            try
            {
                clientes = clienteRepository.GetByNome(nome);
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
                    //verificar se o cliente possui dependentes
                    var qtdDependentes = clienteRepository.CountDependentes(cliente.IdCliente);
                    if (qtdDependentes == 0)
                    {
                        //excluindo o cliente
                        clienteRepository.Delete(cliente);
                        TempData["MensagemSucesso"] = "Cliente excluído com sucesso.";
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Não é possivel excluir o cliente selecionado ."
                                                 + $"pois ele possui {qtdDependentes} dependente(s).";
                    }                                   
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

        public IActionResult Edicao(int id, [FromServices] ClienteRepository clienteRepository)
        {
            //criando um objeto da classe model
            var model = new ClienteEdicaoModel();

            try
            {
                //buscando o cliente no banco de dados pelo id
                var cliente = clienteRepository.GetById(id);

                //transferir os dados do cliente para a model
                model.IdCliente = cliente.IdCliente;
                model.Nome = cliente.Nome;
                model.Email = cliente.Email;
                model.Cpf = cliente.Cpf;
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return View(model); //abrir uma página
        }

        [HttpPost] //método recebe o SUBMIT do formulário
        public IActionResult Edicao(ClienteEdicaoModel model, [FromServices] ClienteRepository clienteRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var cliente = new Cliente();

                    cliente.IdCliente = model.IdCliente;
                    cliente.Nome = model.Nome;
                    cliente.Email = model.Email;
                    cliente.Cpf = model.Cpf;

                    //atualizando no banco de dados
                    clienteRepository.Update(cliente);
                    TempData["MensagemSucesso"] = "Cliente atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            
            return View(); //abrir uma página
        }
    }
}
