using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }

        public string NomeFuncionario { get; set; }

        public string SobrenomeFuncionario { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
