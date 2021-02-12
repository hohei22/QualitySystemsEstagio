using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualitySystemsEstagio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public long Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
    }

}
