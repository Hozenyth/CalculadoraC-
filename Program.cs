using System;
using System.Collections.Generic;

namespace Projeto_CalculadoraC_
{
    class Program
    {
        enum Operations
        {
            Sum = 1,
            Subtract = 2,
            Multiply = 3,
            Division = 4,
            Mod = 5
        }

        static void Main(string[] args)
        {
            instructions();// 1. apresentar instruções de uso
            menu1();// 2. apresentar opções
        }

        static void instructions()
        {
            Console.WriteLine("Instruções");
        }
        static void menu1()
        {

            Console.WriteLine("-----");
            Console.WriteLine("Escolha uma das opções abaixo:");
            Console.WriteLine("1 - Realizar calculo");
            Console.WriteLine("2 - Sair");

            int opcao;

            do
            {
                Console.Write("Escolha uma das opções: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao != 1 && opcao != 2) Console.WriteLine("Opção Invalida, tente novamente!");
                // vamos transformar em um if ternário

            } while (opcao != 1 && opcao != 2);

            switch (opcao)
            {
                case 1:
                    // dados para opcao 1
                    doCalc();
                    break;
                case 2:
                    // dados para opcao 2
                    return;
            }
            // apresentar opções
            // a. realizar cálculo
            // b. encerrar programa
            return;
        }

        static void doCalc()
        {
            Console.Write("Digite o número de operações: ");
            int qtdValores = Int32.Parse(Console.ReadLine());
            int qtdOp = qtdValores - 1;

            Console.WriteLine("Digite os valores a serem operados: ");
            List<double> valuesList = new List<double>();
            // int count = 0;
            // do
            // {
            //     double input = Convert.ToDouble(Console.ReadLine());
            //     valuesList.Add(input);
            //     count++;
            // } while (count < qtdValores);
            for (int i = 0; i < qtdValores; i++)
            {
                double input = Convert.ToDouble(Console.ReadLine());
                valuesList.Add(input);
            }


            foreach (double item in valuesList)
            {
                Console.Write($"{item}, ");

            }

            List<Operations> operationsList = new List<Operations>();


            //console
            // + somar
            // - subtrair
            // * multiplicar
            // / dividir
            // % mod

            for (int i = 0; i < qtdValores - 1; i++)
            {
                string input = Convert.Console.ReadLine();
                operationsList.Add(input);
            }
        }
    }
}