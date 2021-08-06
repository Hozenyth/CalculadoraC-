using System;
using System.Collections.Generic;
using System.Linq;

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

// 1 + 2 * 20 / 10 % 4

        static void Main(string[] args)
        {
            List<double> valuesList = new List<double>();
            List<Operations> operationsList = new List<Operations>();

            valuesList.Add(10);
            valuesList.Add(6);
            valuesList.Add(2);
            operationsList.Add((Operations)int.Parse("1"));
            operationsList.Add((Operations)int.Parse("3"));

            Console.WriteLine(valuesList.ElementAt(0));
            Console.WriteLine(operationsList.ElementAt(0));

            double res = 0;

            if (operationsList.ElementAt(0) == Operations.Sum)
            {
                res = valuesList.ElementAt(0) + valuesList.ElementAt(1);
                Console.WriteLine(res);
            }
            if (operationsList.ElementAt(0) == Operations.Subtract)
            {
                res = valuesList.ElementAt(0) - valuesList.ElementAt(1);
                Console.WriteLine(res);

            }
            if (operationsList.ElementAt(0) == Operations.Multiply)
            {
                res = valuesList.ElementAt(0) * valuesList.ElementAt(1);
                Console.WriteLine(res);

            }
            if (operationsList.ElementAt(0) == Operations.Division)
            {
                res = valuesList.ElementAt(0) / valuesList.ElementAt(1);
                Console.WriteLine(res);

            }
            if (operationsList.ElementAt(0) == Operations.Mod)
            {
                res = valuesList.ElementAt(0) % valuesList.ElementAt(1);
                Console.WriteLine(res);

            }

            Console.WriteLine(res);

            // foreach (var i in valuesList)
            // {
            //     Console.WriteLine(i);
            // }

            //   foreach (var i in operationsList)
            // {
            //     Console.WriteLine(i);
            // }


            // instructions();// 1. apresentar instruções de uso
            // menu1();// 2. apresentar opções
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
                // vamos transformar em um if ternário (????)

            } while (opcao != 1 && opcao != 2);

            switch (opcao)
            {
                case 1:
                    doCalc(); // execução do cálculo
                    break;
                case 2:
                    return; // encerrar programa
            }
        }

        static void doCalc()
        {

            Console.Write("Digite o número de operações: ");
            int qtdOp = Int32.Parse(Console.ReadLine());
            int qtdValores = qtdOp + 1;

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
                Console.WriteLine($"{item}, ");

            }

            Console.WriteLine("Digite as operações que serão realizadas: ");

            List<Operations> operationsList = new List<Operations>();

            for (int i = 0; i < qtdOp; i++)
            {
                Console.WriteLine($"{i + 1}ª Operação: ");
                Operations input = (Operations)int.Parse(Console.ReadLine());

                // double input = Convert.ToDouble(Console.ReadLine());
                // valuesList.Add(input);
            }

            interectLists(valuesList, operationsList);

            //console
            // + somar
            // - subtrair
            // * multiplicar
            // / dividir
            // % mod

            // for (int i = 0; i < qtdValores - 1; i++)
            // {
            //     string input = Convert.Console.ReadLine();
            //     operationsList.Add(input);
            // }
        }

        static double interectLists(List<double> vL, List<Operations> oL)
        {
            List<double> newValuesList = new List<double>();
            List<Operations> newOperationsList = new List<Operations>();

            // interação entre as listas
            // buscar posição do operador com prioridade -> p
            // interagir o elementat(p) e o  elementat(p+1) da lista de valores com o elementat(p+1) da lista de operadores


            if (oL.ElementAt(0) == Operations.Sum)
            {
                double res = vL.ElementAt(0) + vL.ElementAt(1);
            }
            if (oL.ElementAt(0) == Operations.Subtract)
            {
                double res = vL.ElementAt(0) - vL.ElementAt(1);
            }
            if (oL.ElementAt(0) == Operations.Multiply)
            {
                double res = vL.ElementAt(0) * vL.ElementAt(1);
            }
            if (oL.ElementAt(0) == Operations.Division)
            {
                double res = vL.ElementAt(0) / vL.ElementAt(1);
            }
            if (oL.ElementAt(0) == Operations.Mod)
            {
                double res = vL.ElementAt(0) % vL.ElementAt(1);
            }

            // double res = operador(vL.IndexOf(0), vl.IndexOf(1));

            // retorna newValuesList (n) e newOperationsList (n-1)

            if (newValuesList.Count == 1)
                return Convert.ToDouble(newValuesList.IndexOf(0));
            else
                return interectLists(newValuesList, newOperationsList);

        }

        static int searchMinValue(List<Operations> oL)
        {
            // qual o index da operação da primeira operação com multiplicação ou divisão ou resto?
            int minValue = 0;
            if (oL.Contains(Operations.Multiply) || oL.Contains(Operations.Division) || oL.Contains(Operations.Mod))
            {
                // condição caso não existe o operador, pois o retorno é -1
                List<int> lista = new List<int>();
                lista.Add(oL.IndexOf(Operations.Multiply));
                lista.Add(oL.IndexOf(Operations.Division));
                lista.Add(oL.IndexOf(Operations.Mod));

                minValue = lista.Min();
            }
            return minValue;
        }

    }


// a = 2 + 2 * 2 + 1


// novaA = 2 + 4 + 1


// list3 = l11





/* static void testLinq()
{
    int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    IEnumerable<int> numQuery =
        from num in numeros
        where (num % 2) == 0
        select num;

    foreach (int num in numQuery)
    {
        Console.WriteLine($"{num}, ");
    }

} */