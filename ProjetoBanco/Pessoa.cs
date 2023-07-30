using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco
{
    public class Pessoa : Conta
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Senha { get; private set; }
        public IContar Conta { get; set; }


        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetCPF(string cpf)
        {
            this.CPF = cpf;
        }

        public void SetSenha(string senha)
        {
            this.Senha = senha;
        }








    }
}
