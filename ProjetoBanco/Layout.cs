using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoBanco
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;

        public static void TelaPrincipal()
        {

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Clear();


            Console.WriteLine("                                                ");
            Console.WriteLine("                   Digite a Opção Desejada      ");
            Console.WriteLine("                  ------------------------      ");
            Console.WriteLine("                  1) Criar Conta                ");
            Console.WriteLine("                  ------------------------      ");
            Console.WriteLine("                  2) Entrar com CPF e Senha     ");
            Console.WriteLine("                  ------------------------      ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;

                case 2:
                    TelaLogin();
                    break;

                default:
                    Console.WriteLine(" Opção Inválida ");
                    break;


            }

        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("                                                ");
            Console.WriteLine("                  Digite o seu nome:            ");
            string nome = Console.ReadLine();

            Console.WriteLine("                  Digite o seu CPF              ");
            string cpf = Console.ReadLine();

            Console.WriteLine("                  Digite a sua senha            ");
            string senha = Console.ReadLine();

            ///criar uma conta

            ContaCorrente cc = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = cc;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("                  ------------------------      ");
            Console.WriteLine("                 Conta Cadastrada com Sucesso   ");
            Console.WriteLine("                  ------------------------      ");

            //esse codigo espera 1 segundo pra ir pra tela logada
            Thread.Sleep(1000);

            TelaContaLogada(pessoa);

        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("                  Digite o seu CPF:              ");
            string cpf = Console.ReadLine();

            Console.WriteLine("                  Digite a sua senha:           ");
            string senha = Console.ReadLine();
            // criando busca

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if(pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Pessoa não cadastrada");

                Console.WriteLine();
                Console.WriteLine();
            }




        }


        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgTelaBemVindo = $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoBanco()} | Agência: {pessoa.Conta.GetNumAgencia()} | Conta: {pessoa.Conta.GetNumConta()}";
            Console.WriteLine(" ");
            Console.WriteLine($"        Seja bem vindo, {msgTelaBemVindo}");
            Console.WriteLine(" ");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);
            Console.WriteLine("                  Digite a opção desejada        ");
            Console.WriteLine("                  ------------------------       ");
            Console.WriteLine("                  1) Realizar um Deposito        ");
            Console.WriteLine("                  ------------------------       ");
            Console.WriteLine("                  2) Realizar um Saque           ");
            Console.WriteLine("                  ------------------------       ");
            Console.WriteLine("                  3) Consultar Saldo             ");
            Console.WriteLine("                  ------------------------       ");
            Console.WriteLine("                  4) Extrato                     ");
            Console.WriteLine("                  ------------------------       ");
            Console.WriteLine("                  5) Sair                        ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);

                    break;
                case 4:
                TelaExtra(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                  Opção inválida!                        ");
                    break;

            }
        }


        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);


            Console.WriteLine("                      Digite o valor do deposito:                        ") ;
            double valor = double.Parse(Console.ReadLine());
             Console.WriteLine("                      ==========================                        ") ;

            pessoa.Conta.Deposita(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                            ") ;
            Console.WriteLine("                                                                            ") ;
            Console.WriteLine("                           Deposito Realizado com Sucesso                   ") ;
            Console.WriteLine("                           ==========================                       ") ;

            OpcaoVoltarLogado(pessoa);

        }

        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);


            Console.WriteLine("                         Digite o valor do Saque:                        ") ;
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                        ==========================                        ") ;

            bool okSaque = pessoa.Conta.Saca(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                               ") ;
            Console.WriteLine("                                                                               ") ;
            if (okSaque)
            {
                Console.WriteLine("                           Saque Realizado com Sucesso                      ") ;
                Console.WriteLine("                           ==========================                       ") ;
            }
            else
            {
                Console.WriteLine("                           Saldo insuficiente                               ") ;
                Console.WriteLine("                           ==========================                       ") ;
            }


            OpcaoVoltarLogado(pessoa);

        }

        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine($"                          Seu saldo é: {pessoa.Conta.ConsultaSaldo()}              ") ;
            Console.WriteLine("                            ===========================================              ") ;

            OpcaoVoltarLogado(pessoa);

        }

        private static void TelaExtra(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            if(pessoa.Conta.Extra().Any()){
                //mostrar Extrato
                double total = pessoa.Conta.Extra().Sum(x => x.Valor);

            foreach(Extra extrato in pessoa.Conta.Extra()){
            Console.WriteLine("                                                                             ") ;
            Console.WriteLine($"                         Data: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}") ;
            Console.WriteLine($"                         Valor:  {extrato.Valor}                           ") ;
            Console.WriteLine($"                         Tipo de Movimentação {extrato.Descricao}          ") ;
            Console.WriteLine("                          ========================================          ") ;
            }
            Console.WriteLine("                                                                            ") ;
            Console.WriteLine($"                          SUB TOTAL: {total}                               ") ;
            Console.WriteLine("                           ==========================                       ") ;

            }else{
            Console.WriteLine("                           Não há extato a ser exibido                      ") ;
            Console.WriteLine("                           ==========================                       ") ;
            }

            OpcaoVoltarLogado(pessoa);

        }




        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine($"                          Seu saldo é: {pessoa.Conta.ConsultaSaldo()}               ") ;
            Console.WriteLine("                            ===========================================              ") ;
            Console.WriteLine("                                                                                     ") ;

            OpcaoVoltarLogado(pessoa);

        }




        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("                           Entre com uma opção abaixo                       ") ;
            Console.WriteLine("                           ==========================                       ") ;
            Console.WriteLine("                           1) - Voltar para minha conta                     ") ;
            Console.WriteLine("                           ==========================                       ") ;
            Console.WriteLine("                           2) - Sair                                        ") ;

            opcao = int.Parse(Console.ReadLine());

            if(opcao == 1)
            {
                TelaContaLogada(pessoa);
            }
            else
            {
                TelaPrincipal();
            }

        }


        private static void OpcaoVoltarDesLogado()
        {
            Console.WriteLine("                           Entre com uma opção abaixo                       ") ;
            Console.WriteLine("                           ===============================                  ") ;
            Console.WriteLine("                           1) - Voltar para menu principal                  ") ;
            Console.WriteLine("                           ===============================                  ") ;
            Console.WriteLine("                           2) - Sair                                        ") ;

            opcao = int.Parse(Console.ReadLine());

            if(opcao == 1)
            {
               TelaPrincipal();
            }
            else
            {
                Console.WriteLine("                                  Opção Invalida                            ");
                Console.WriteLine("                           ===============================                  ") ;
            }

        }

    }
}
