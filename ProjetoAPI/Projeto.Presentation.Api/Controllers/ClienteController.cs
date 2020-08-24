using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Api.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]  
        public IActionResult Post(ClienteCadastroModel model, [FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                //verificar se o cpf informado já está cadastrado
                if (clienteRepository.GetByCpf(model.Cpf) != null )
                {
                    //retornar status 403 (Proibido)
                    return StatusCode(403, "O CPF informado já encontra-se cadastrado.");
                }

                //verificar se o email informado já está cadastrado
                if (clienteRepository.GetByEmail(model.Email) != null)
                {
                    //retornar status 403 (Proibido)
                    return StatusCode(403, "O Email informado já encontra-se cadastrado.");
                }
                //capturando os dados do cliente
                var cliente = new Cliente();
                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Cpf = model.Cpf;

                //gravar o cliente no banco de dados
                clienteRepository.Insert(cliente);

                //retornar status 201 (OK, Criado!)
                return StatusCode(201, "Cliente cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status 500 (Internal Server Error)
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }


        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model,
            [FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                //buscando o cliente na base de dados pelo id
                var cliente = clienteRepository.GetById(model.IdCliente);

                //verificando se o cliente foi encontrado
                if (cliente != null)
                {
                    cliente.Nome = model.Nome;
                    cliente.Cpf = model.Cpf;
                    cliente.Email = model.Email;

                    //atualizando o cliente
                    clienteRepository.Update(cliente);

                    //retornar status 200 (OK)
                    return Ok("Cliente atualizado com sucesso.");
                }
                else
                {
                    //retornar status 422 (Unprocessable Entity)
                    return StatusCode(422, "Cliente inválido. Operação não pôde ser realizada.");
                }
            }
            catch (Exception e)
            {
                //retornar status 500 (Internal Server Error)
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                //buscando o cliente na base de dados pelo id
                var cliente = clienteRepository.GetById(id);

                //verificando se o cliente foi encontrado
                if (cliente != null)
                {
                    //excluindo o cliente
                    clienteRepository.Delete(cliente);

                    //retornar status 200 (OK)
                    return Ok("Cliente excluído com sucesso.");
                }
                else
                {
                    //retornar status 422 (Unprocessable Entity)
                    return StatusCode(422, "Cliente inválido. Operação não pôde ser realizada.");
                }
            }
            catch (Exception e)
            {
                //retornar status 500 (Internal Server Error)
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                //retornando a lista com todos os clientes cadastrados
                return Ok(clienteRepository.GetAll());
            }
            catch (Exception e)
            {
                //retornar status 500 (Internal Server Error)
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }
    }
}
