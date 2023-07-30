using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco
{
    public abstract class Conta : Banco, IContar
    {

        public Conta()
        {
            this.NumAgencia = "001";
            Conta.NumerContaSequencial++;
            this.Movimentacoes = new List<Extra>();
        }

        //atributo

        public double Saldo { get; protected set; }

        public string NumAgencia { get; private set; }

        public string NumConta { get; protected set; }

        public static int NumerContaSequencial { get; private set; }

        private List<Extra> Movimentacoes;

        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            DateTime dataAtual =  DateTime.Now;
            this.Movimentacoes.Add(new Extra(dataAtual, "Deposito", valor));
            this.Saldo += valor;
        }

        public bool Saca(double valor)
        {
            if (valor > this.ConsultaSaldo())
            {
                return false;
            }
            DateTime dataAtual =  DateTime.Now;
            this.Movimentacoes.Add(new Extra(dataAtual, "Saque", valor));

            this.Saldo -= valor;
            return true;
        }

        public string GetCodigoBanco()
        {
            return this.CodDoBanco;
        }

        public string GetNumAgencia()
        {
            return this.NumAgencia;
        }

        public string GetNumConta()
        {
            return this.NumConta;
        }

        public List<Extra> Extra()
        {
            return this.Movimentacoes;
        }


    }
}
