using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco
{
    public abstract class Banco
    {
        public Banco()
        {
            //construtor
            this.NomeDoBanco = "CosBan";
            this.CodDoBanco = "027";

        }

        public string NomeDoBanco { get; private set; }
        public string CodDoBanco { get; private set; }

    }
}
