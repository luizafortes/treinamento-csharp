using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Mvc.Models
{
    public class DependenteEdicaoModel
    {
        public int IdDependente { get; set; } //campo oculto

        [MinLength(6, ErrorMessage = "Por favor informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por Favor, informe o nome do dependente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por Favor, informe a data de nascimento.")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Por Favor, selecione um cliente.")]
        public int? IdCliente { get; set; }

        //listagem de clientes para exibir no formulário
        public List<SelectListItem> ListagemDeClientes { get; set; }
    }
}
