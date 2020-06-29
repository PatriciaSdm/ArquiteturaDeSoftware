using System;
//using SOLID.LSP.Violacao;
using SOLID.OCP.Solucao_Extension_Methods;
using CalculoArea = SOLID.LSP.Solucao.CalculoArea;

namespace SOLID
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine("Escolha a operação");
            Console.WriteLine("1 - OCP");
            Console.WriteLine("2 - LSP");

            var opcao = Console.ReadKey();

            switch (opcao.KeyChar)
            {
                case '1':
                    CaixaEletronico.Operacoes();
                    break;
                case '2':
                    CalculoArea.Calcular();
                    break;
            }
        }
    }
}


//SRP = Uma classe deve ter um, e apenas um, motivo para ser modificada

//OCP = Entidades de software (classes, módulos, funções etc...) devem estar abertas para extensão, mas fechadas para modificação
//      EX: Pode ser usado herança, extension methods etc...

//LSP = Subclasses devem ser substituiveis por suas superclasses
//      Prova real de que a herança foi feita da forma correta ou não

//ISP = Clientes não devem ser forçados a depender de métodos que não usam
//      Muitas interfaces especificas são melhores que uma interface unica

//DIP = Dependa de uma abstração, e não de uma implementação
 //     Uma classe de alto nível não pode depender (instanciar) de outra de baixo nível
