using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Models
{
    public class UsuarioCadastroModel
    {
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [Required(ErrorMessage = "Informe o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Confirme a senha.")]
        public string SenhaConfirmacao { get; set; }
    }
}
