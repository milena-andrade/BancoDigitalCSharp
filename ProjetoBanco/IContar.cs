using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco
{
    public interface IContar
    {
        void Deposita(double valor);

        bool Saca(double valor);

        double ConsultaSaldo();

        string GetCodigoBanco();

        string GetNumAgencia();

        string GetNumConta();

        List<Extra> Extra();
    }
}
