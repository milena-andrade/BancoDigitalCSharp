using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco
{
    public class Extra
    {
        public Extra(DateTime data, string descricao, double valor)
        {
			this.Data = data;
			this.Descricao = descricao;
			this.Valor = valor;
        }

		public DateTime Data { get; private set; }
		public string Descricao { get; private set; }
		public double Valor { get; private set; }
    }
}