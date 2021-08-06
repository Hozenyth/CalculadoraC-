using System;

namespace Projeto_CalculadoraC_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Meu Primeiro Projeto - CALCULADORA");
            Console.WriteLine();
            Console.WriteLine("Escolha o número equivalente a operação abaixo: ");
            Console.WriteLine("1) Somar");
            Console.WriteLine("2) Subtrair");
            Console.WriteLine("3) Multiplicar");
            Console.WriteLine("4) Dividir");
            Console.WriteLine("5) Sair");
           
           int opcao = Int32.Parse(Console.ReadLine());
           Console.WriteLine($"A opçao escolhida é {opcao}");
          

           switch (opcao)
            {
                case 1:
                    Console.WriteLine("somar");
                    break;
                case 2:
                    Console.WriteLine("subtrair");
                    break;
                case 3:
                    Console.WriteLine("multiplicar");
                    break;
                case 4:
                    Console.WriteLine("dividir");
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
    }
}
