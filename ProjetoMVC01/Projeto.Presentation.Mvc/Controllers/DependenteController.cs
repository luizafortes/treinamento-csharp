using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto.Presentation.Mvc.Models;
using Projeto.Repository.Entities;
using Projeto.Repository.Repositories;

namespace Projeto.Presentation.Mvc.Controllers
{
    public class DependenteController : Controller
    {
        //Abrir a página
        public IActionResult Cadastro([FromServices] ClienteRepository clienteRepository)
        {
            var result = GetDependenteCadastroModel(clienteRepository);
            return View(result);
        }


        [HttpPost]
        public IActionResult Cadastro(DependenteCadastroModel model, [FromServices] DependenteRepository dependenteRepository, [FromServices] ClienteRepository clienteRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dependente = new Dependente();
                    dependente.Nome = model.Nome;
                    dependente.DataNascimento = DateTime.Parse(model.DataNascimento);
                    dependente.IdCliente = Convert.ToInt32(model.IdCliente);

                    dependenteRepository.Create(dependente);

                    TempData["MensagemSucesso"] = "Dependente cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }
            }

            var result = GetDependenteCadastroModel(clienteRepository);
            return View(result);          
        }
        
        //método de ação para consultar dependente
        public IActionResult Consulta([FromServices] DependenteRepository dependenteRepository)
        {
            var dependentes = new List<Dependente>();
            
            try
            {
                dependentes = dependenteRepository.GetAll();
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Erro: " + e.Message;
            }

            return View(dependentes);
        }

        //método de ação para excluir dependente
        public IActionResult Exclusao(int id, [FromServices] DependenteRepository dependenteRepository)
        {
            try
            {
                var dependente = dependenteRepository.GetById(id);

                //verificar se o cliente foi obtido no banco de dados
                if (dependente != null)
                {
                    //excluindo o cliente
                    dependenteRepository.Delete(dependente);
                    TempData["MensagemSucesso"] = "Dependente excluído com sucesso.";
                }
                else
                {
                    throw new Exception("Dependente não encontrado.");
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Erro: " + e.Message;
            }

            //redirecionar de volta para a página de consulta.
            return RedirectToAction("Consulta");
        }

        //método de ação para abrir a página de edição de dependente
        public IActionResult Edicao(int id, [FromServices] DependenteRepository dependenteRepository)
        {
            //criando um objeto da classe model
            var model = new DependenteEdicaoModel();

            try
            {
                //buscando o cliente no banco de dados pelo id
                var dependente = dependenteRepository.GetById(id);

                //transferir os dados do cliente para a model
                model.IdDependente = dependente.IdDependente;
                model.Nome = dependente.Nome;
                model.DataNascimento = Convert.ToString(dependente.DataNascimento); 
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return View(model); //abrir uma página
        }

        [HttpPost] //método recebe o SUBMIT do formulário
        public IActionResult Edicao(DependenteEdicaoModel model, [FromServices] DependenteRepository dependenteRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dependente = new Dependente();

                    dependente.IdDependente = model.IdDependente;
                    dependente.Nome = model.Nome;
                    dependente.DataNascimento = DateTime.Parse(model.DataNascimento);
                    dependente.IdCliente = Convert.ToInt32(model.IdCliente);

                    //atualizando no banco de dados
                    dependenteRepository.Update(dependente);
                    TempData["MensagemSucesso"] = "Dependente atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View(); //abrir uma página
        }

        //função que carrega os clientes da página dependente
        private DependenteCadastroModel GetDependenteCadastroModel(ClienteRepository clienteRepository)
        {
            var model = new DependenteCadastroModel();

            try
            {
                //carregar a lista com os clientes (campo de seleção)
                model.ListagemDeClientes = new List<SelectListItem>();
                //percorrer todos os clientes obtidos do banco de dados
                foreach (var item in clienteRepository.GetAll())
                {
                    //criando 1 item do campo de seleção
                    var opcao = new SelectListItem();
                    opcao.Value = item.IdCliente.ToString();
                    opcao.Text = item.Nome;

                    model.ListagemDeClientes.Add(opcao); //adicionando
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Erro: " + e.Message;
            }

            return model;
        }
    }
}
