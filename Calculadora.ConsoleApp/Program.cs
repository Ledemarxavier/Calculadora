using System;

namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] operacoesRealizadas = new string[100];
            int contador = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Calculadora Tabajara 2025");
                Console.WriteLine("-----------------------------------------");

                Console.WriteLine("1 - Somar");
                Console.WriteLine("2 - Subtrair");
                Console.WriteLine("3 - Multiplicar");
                Console.WriteLine("4 - Dividir");
                Console.WriteLine("5 - Tabuada");
                Console.WriteLine("6 - Histórico de Operações");
                Console.WriteLine("S - Sair");
                Console.WriteLine("-----------------------------------------");

                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine()!;

                if (opcao == "S")
                    break;
                else if (opcao == "5")
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Tabuada");
                    Console.WriteLine("-----------------------------------------");

                    try
                    {
                        Console.Write("Digite o número desejado: ");
                        int numeroTabuada = Convert.ToInt32(Console.ReadLine());

                        for (int i = 1; i <= 10; i++)
                            Console.WriteLine($"{numeroTabuada} x {i} = {numeroTabuada * i}");

                        Console.ReadLine();
                        continue;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Por favor, digite um número válido.");
                        Console.ReadLine();
                        continue;
                    }
                }
                else if (opcao == "6")
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Histórico de Operações");
                    Console.WriteLine("-----------------------------------------");

                    for (int i = 0; i < operacoesRealizadas.Length; i++)
                    {
                        if (operacoesRealizadas[i] != null)
                            Console.WriteLine(operacoesRealizadas[i]);
                    }

                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine("-----------------------------------------");

                decimal numero1 = 0;
                decimal numero2 = 0;

                try
                {
                    Console.Write("Digite o primeiro número: ");
                    numero1 = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Digite o segundo número: ");
                    numero2 = Convert.ToDecimal(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, digite números válidos.");
                    Console.ReadLine();
                    continue;
                }

                decimal resultado = 0;

                switch (opcao)
                {
                    case "1":
                        resultado = numero1 + numero2;
                        operacoesRealizadas[contador] = $"{numero1} + {numero2} = {resultado}";
                        break;

                    case "2":
                        resultado = numero1 - numero2;
                        operacoesRealizadas[contador] = $"{numero1} - {numero2} = {resultado}";
                        break;

                    case "3":
                        resultado = numero1 * numero2;
                        operacoesRealizadas[contador] = $"{numero1} x {numero2} = {resultado}";
                        break;

                    case "4":
                        if (numero2 == 0)
                        {
                            Console.WriteLine("Erro: Não é possível dividir por zero!");
                            Console.ReadLine();
                            continue;
                        }
                        resultado = numero1 / numero2;
                        operacoesRealizadas[contador] = $"{numero1} / {numero2} = {resultado}";
                        break;
                }

                if (contador < operacoesRealizadas.Length - 1)
                    contador += 1;

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Resultado: {resultado}");
                Console.WriteLine("-----------------------------------------");

                Console.Write("Deseja continuar? (S/N): ");
                string opcaoContinuar = Console.ReadLine().ToUpper();
                if (opcaoContinuar != "S")
                    break;
            }
        }
    }
}