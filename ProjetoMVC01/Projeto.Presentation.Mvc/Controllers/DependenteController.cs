using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto.Presentation.Mvc.Models;
using Projeto.Repository.Repositories;

namespace Projeto.Presentation.Mvc.Controllers
{
    public class DependenteController : Controller
    {
        //Abrir a página
        public IActionResult Cadastro([FromServices] ClienteRepository clienteRepository)
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


            return View(model);
        }

        public IActionResult Consulta()
        {
            return View();
        }
    }
}
