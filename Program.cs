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

        static void Main(string[] args)
        {
            instructions();
            menu1();
        }

        static void instructions()
        {
            Console.WriteLine("Instruções de uso...");
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
            } while (opcao != 1 && opcao != 2);

            switch (opcao)
            {
                case 1:
                    doCalc(); // execução do cálculo
                    break;
                case 2:
                    return;
            }
        }

        static List<Double> resultsList = new List<Double>();

        static void doCalc()
        {
            Console.Write("Digite o número de operações: ");
            int qtdOp = Int32.Parse(Console.ReadLine());
            int qtdValores = qtdOp + 1;

            Console.WriteLine("Digite os valores a serem operados: ");
            List<double> valuesList = new List<double>();
            for (int i = 0; i < qtdValores; i++)
            {
                Console.WriteLine($"{i + 1}º Valor: ");
                double input = Convert.ToDouble(Console.ReadLine());
                valuesList.Add(input);
            }

            Console.WriteLine("Digite as operações que serão realizadas: ");

            List<Operations> operationsList = new List<Operations>();

            for (int i = 0; i < qtdOp; i++)
            {
                Console.WriteLine($"{i + 1}ª Operação: ");
                Operations input = (Operations)int.Parse(Console.ReadLine());
                operationsList.Add(input);
            }

            double res = interectLists(valuesList, operationsList);

            Console.WriteLine($"O resultado da operação é {res}");

            resultsList.Add(res); // guarda o resultado em uma lista

            menu2();
        }

        static double interectLists(List<double> vL, List<Operations> oL)
        {
            List<double> newValuesList = new List<double>();

            foreach (var item in vL)
            {
                newValuesList.Add(item);
            }

            /*
            definição do negócio
            5 / 2 + 1,5 -> 2 + 1,5 -> 3,5
            5 / 2 + 1,5 -> 2,5 + 1,5 -> 4 xxxxxxx retorno isso!

            5 / 2 + 1 -> 3,5
            5 / 2 + 1 -> 3 xxxxxx retorno isso!
            */

            // busca de decimais entre no newValuesList
            var decimalList =
            from value in newValuesList
            where Math.Floor(value) != value
            select value;

            // se existir elemento nessa Lista Busca, significa que existe DECIMAL entre os valores
            bool hasDecimals = (decimalList.Count() > 0) ? true : false;

            List<Operations> newOperationsList = new List<Operations>();
            foreach (var item in oL)
            {
                newOperationsList.Add(item);
            }
            double res = 0;

            int indexPriority = searchMinValue(newOperationsList);

            if (newOperationsList.ElementAt(indexPriority) == Operations.Sum)
            {
                res = newValuesList.ElementAt(indexPriority) + newValuesList.ElementAt(indexPriority + 1);
            }
            else if (newOperationsList.ElementAt(indexPriority) == Operations.Subtract)
            {
                res = newValuesList.ElementAt(indexPriority) - newValuesList.ElementAt(indexPriority + 1);
            }
            else if (newOperationsList.ElementAt(indexPriority) == Operations.Multiply)
            {
                res = newValuesList.ElementAt(indexPriority) * newValuesList.ElementAt(indexPriority + 1);
            }
            else if (newOperationsList.ElementAt(indexPriority) == Operations.Division && hasDecimals)
            {
                res = newValuesList.ElementAt(indexPriority) / newValuesList.ElementAt(indexPriority + 1);
            }
            else if (newOperationsList.ElementAt(indexPriority) == Operations.Division && !hasDecimals)
            {
                res = Math.Floor(newValuesList.ElementAt(indexPriority) / newValuesList.ElementAt(indexPriority + 1));
            }
            else
            {
                res = newValuesList.ElementAt(indexPriority) % newValuesList.ElementAt(indexPriority + 1);
            }

            // retorna newValuesList (n) e newOperationsList (n-1)
            newValuesList.RemoveAt(indexPriority);
            newValuesList[indexPriority] = res;
            newOperationsList.RemoveAt(indexPriority);

            if (newValuesList.Count == 1)
                return Convert.ToDouble(newValuesList.ElementAt(0));
            else
                return interectLists(newValuesList, newOperationsList);
        }

        static int searchMinValue(List<Operations> oL)
        {
            // qual o index da primeira operação com multiplicação ou divisão ou resto?
            int minValue = 0;

            if (oL.Contains(Operations.Multiply) || oL.Contains(Operations.Division) || oL.Contains(Operations.Mod))
            {
                List<int> lista = new List<int>();
                if (oL.IndexOf(Operations.Multiply) >= 0) lista.Add(oL.IndexOf(Operations.Multiply));
                if (oL.IndexOf(Operations.Division) >= 0) lista.Add(oL.IndexOf(Operations.Division));
                if (oL.IndexOf(Operations.Mod) >= 0) lista.Add(oL.IndexOf(Operations.Mod));

                minValue = lista.Min();
            }
            else
            {
                List<int> lista = new List<int>();
                if (oL.IndexOf(Operations.Sum) >= 0) lista.Add(oL.IndexOf(Operations.Sum));
                if (oL.IndexOf(Operations.Subtract) >= 0) lista.Add(oL.IndexOf(Operations.Subtract));

                minValue = lista.Min();
            }

            return minValue;
        }

        static void menu2()
        {
            Console.WriteLine("-----");
            Console.WriteLine("Escolha uma das opções abaixo:");
            Console.WriteLine("1 - Realizar cálculo");
            Console.WriteLine("2 - Consultar todos os resultados");
            Console.WriteLine("3 - Sair");

            int opcao;

            do
            {
                Console.Write("Escolha uma das opções: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao != 1 && opcao != 2 && opcao != 3) Console.WriteLine("Opção Invalida, tente novamente!");
            } while (opcao != 1 && opcao != 2 && opcao != 3);

            switch (opcao)
            {
                case 1:
                    doCalc();
                    break;
                case 2:
                    for (int i = 0; i < resultsList.Count(); i++)
                    {
                        Console.WriteLine($"O resultado da {i + 1}ª operação foi {(resultsList.ElementAt(i))}");
                    }
                    menu2();
                    break;
                case 3:
                    return;
            }
        }
    }
}