using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            this.NumConta = "00" + Conta.NumerContaSequencial;
        }
    }
}
