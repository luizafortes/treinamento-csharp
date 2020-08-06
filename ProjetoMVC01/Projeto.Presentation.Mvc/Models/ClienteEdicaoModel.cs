using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Mvc.Models
{
    public class ClienteEdicaoModel
    {
        public int IdCliente { get; set; } //campo oculto

        [MinLength(6, ErrorMessage = "Por favor informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por Favor, informe o nome do cliente.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por Favor, informe o email do cliente.")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor preencha 11 dígitos numéricos sem pontos e traços.")]
        [Required(ErrorMessage = "Por Favor, informe o cpf do cliente.")]
        public string Cpf { get; set; }

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Por Favor, informe a data de nascimento.")]
        public DateTime DataNascimento { get; set; }
    }
}
