using System;

namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static string[] operacoesRealizadas = new string[100];
static int contadorHistorico = 0;

static void Main(string[] args)
{
	while (true)
	{
		string opcao = ExibirMenu();

		if (OpcaoSairEscolhida(opcao))
			break;
			
		else if (OpcaoTabuadaescolhida(opcao))
			ExibirTabuada();
		
		else if (OpcaoHistoricoEscolhida(opcao))
			ExibirHistorico();

		else if (OpcaoInvalida(opcao))
			MensagemErro();

		else
			ExibirResultado(RealizarCalculo(opcao));
	}
}

static string ExibirMenu()
{
	Console.Clear();
	Console.WriteLine("--------------------------------");
	Console.WriteLine("Calculadora Tabajara 2025");
	Console.WriteLine("--------------------------------");

	Console.WriteLine("1 - Somar");
	Console.WriteLine("2 - Subtrair");
	Console.WriteLine("3 - Multiplicação");
	Console.WriteLine("4 - Divisão");
	Console.WriteLine("5 - Tabuada");
	Console.WriteLine("6 - Histórico de Operações");
	Console.WriteLine("S - Sair");

	string opcao = Console.ReadLine()!.ToUpper();

	return opcao;
}

static bool OpcaoSairEscolhida(string opcao)
{
	bool opcaoSaidaSelecionada = opcao == "S";

	return opcaoSaidaSelecionada;
}

static bool OpcaoTabuadaEscolhida(string opcao)
{
	return opcao == "5";
}

        static bool OpcaoInvalida(string opcao)
        {
            string[] opcoesValidas = { "1", "2", "3", "4", "5", "6", "S" };
            return !opcoesValidas.Contains(opcao);
        }

        static void MensagemErro()
{
	Console.WriteLine("Erro: Opção inválida ");
	Console.ReadLine();
}

static decimal RealizarCalculo(string opcao)
{
	Console.WriteLine("Digite o primeiro número:");

	decimal primeiroNumero = Convert.ToDecimal(Console.ReadLine());

	Console.WriteLine("Digite o segundo número:");

	decimal segundoNumero = Convert.ToDecimal(Console.ReadLine());

	decimal resultado = 0;

	switch (opcao)
	{
		case "1":
			resultado = primeiroNumero + segundoNumero;
			operacoesRealizadas[contadorHistorico] = $"{primeiroNumero} + {segundoNumero} = {resultado}";
			break;

		case "2":
			resultado = primeiroNumero - segundoNumero;
			operacoesRealizadas[contadorHistorico] = $"{primeiroNumero} - {segundoNumero} = {resultado}";
			break;

		case "3":
			resultado = primeiroNumero * segundoNumero;
            operacoesRealizadas[contadorHistorico] = $"{primeiroNumero} * {segundoNumero} = {resultado}";
			break;

		case "4":
			while (segundoNumero == 0)
			{
				Console.Write("Erro: Não é possível dividir por 0!");

				segundoNumero = Convert.ToDecimal(Console.ReadLine());
			}

			resultado = primeiroNumero / segundoNumero;
            operacoesRealizadas[contadorHistorico] = $"{primeiroNumero} / {segundoNumero} = {resultado}";
			break;
	}
	
	contadorHistorico++;

	return resultado;
}

static void ExibirResultado(decimal resultado)
{
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("O resultado é: " + resultado.ToString("F2"));
            Console.WriteLine("-----------------------------------------");
            
	
	Console.ReadLine();
}

static void ExibirTabuada()
{
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Tabuada");
            Console.WriteLine("-----------------------------------------");

            Console.Write("Digite o número: ");
	int numeroTabuada = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{numeroTabuada} x {i} = {numeroTabuada * i}");
            }

            Console.Write("Aperte ENTER para continuar");
			Console.ReadLine();
}

static void ExibirHistorico()
{
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Histórico de Operações");
            Console.WriteLine("-----------------------------------------");

            for (int contador = 0; contador < operacoesRealizadas.Length; contador++)
	{
	    string valorAtual = operacoesRealizadas[contador];
	
	    if (valorAtual != null)
	        Console.WriteLine(valorAtual);
	}
	
	Console.Write("Aperte ENTER para continuar");
	Console.ReadLine();
}
    }
}