using System;
using System.Collections.Generic;

namespace DIO.Bank
{
	class Program
	{
		static List<Conta> contas = new List<Conta>();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				TratarOpcaoUsuario(opcaoUsuario);
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços!");
			Console.ReadLine();
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("---------------------------");
			Console.WriteLine("| DIO Bank ao seu dispor! |");
			Console.WriteLine("---------------------------");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1. Listar contas existentes");
			Console.WriteLine("2. Inserir uma nova conta");
			Console.WriteLine("3. Realizar um saque");
			Console.WriteLine("4. Efetuar um depósito");
			Console.WriteLine("C. Limpar a tela");
			Console.WriteLine("X. Sair");
			Console.WriteLine();
			Console.Write("Sua opção: ");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();

			return opcaoUsuario;
		}

		private static void TratarOpcaoUsuario(string opcaoUsuario)
		{
			switch (opcaoUsuario)
			{
				case "1":
					ListarContas();
					break;
				case "2":
					InserirConta();
					break;
				case "3":
					Transferir();
					break;
				case "4":
					Sacar();
					break;
				case "5":
					Depositar();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private static void Depositar()
		{
			Console.Write("Informe o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Informe valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

		}

		private static void Sacar()
		{
			Console.Write("Informe o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

			Console.Write("Informe o número da conta de destino: ");
			int indiceContaDestion = int.Parse(Console.ReadLine());

			Console.Write("Informe valor a ser transferido: ");
			double valorDeposito = double.Parse(Console.ReadLine());
		}

		private static void Transferir()
		{
			throw new NotImplementedException();
		}

		private static void InserirConta()
		{
			Console.WriteLine("Inserir uma nova conta: ");

			Console.WriteLine("Digite: ");
			Console.WriteLine("1. Para conta Pessoa Física: ");
			Console.WriteLine("2. Para conta Pessoa Jurídica: ");
			Console.WriteLine();
			Console.Write("Sua opção: ");
			int tipoConta = int.Parse(Console.ReadLine());

			Console.Write("Informe o nome do cliente: ");
			string nomeCliente = Console.ReadLine();

			Console.Write("Informe valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

		}

		private static void ListarContas()
		{
			throw new NotImplementedException();
		}
	}
}
