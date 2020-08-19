using System;
using System.Collections.Generic;
using System.Text;

using Projeto.Infra.Data.Enums;

namespace Projeto.Infra.Data.Dtos
{
    public class ResumoCategoriaDto
    {
        public Categoria Categoria { get; set; }
        public int Quantidade { get; set; }
    }
}
