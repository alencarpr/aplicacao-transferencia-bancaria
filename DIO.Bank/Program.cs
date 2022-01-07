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
				opcaoUsuario = ObterOpcaoUsuario();
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
			Console.WriteLine("3. Realizar um transferência");
			Console.WriteLine("4. Realizar um saque");
			Console.WriteLine("5. Efetuar um depósito");
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
				case "C":
					Console.Clear();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private static void Depositar()
		{
			Console.Write("Informe o número da conta: ");
			int indiceConta = ObtemNumeroConta();

			Console.Write("Informe valor a ser depositado: ");
			double valorDeposito = ObtemValorTransacao();

			contas[indiceConta].Depositar(valorDeposito);
		}

		private static void Sacar()
		{
			Console.Write("Informe o número da conta: ");
			int indiceConta = ObtemNumeroConta();

			Console.Write("Informe valor a ser sacado: ");
			double valorSaque = ObtemValorTransacao();

			contas[indiceConta].Sacar(valorSaque);
		}

		private static void Transferir()
		{
			Console.Write("Informe o número da conta de origem: ");
			int indiceContaOrigem = ObtemNumeroConta();

			Console.Write("Informe o número da conta de destino: ");
			int indiceContaDestino = ObtemNumeroConta();

			Console.Write("Informe valor a ser transferido: ");
			double valorTransferencia = ObtemValorTransacao();

			contas[indiceContaOrigem].Transferir(valorTransferencia, contas[indiceContaDestino]);
		}

		private static void InserirConta()
		{
			Console.WriteLine("Inserir uma nova conta: ");

			Console.WriteLine("Digite: ");
			Console.WriteLine("1. Para conta Pessoa Física: ");
			Console.WriteLine("2. Para conta Pessoa Jurídica: ");
			Console.WriteLine();
			Console.Write("Sua opção: ");
			TipoConta tipoConta = ObtemTipoConta();

			Console.Write("Informe o nome do cliente: ");
			string nomeCliente = Console.ReadLine();

			Console.Write("Informe o valor do saldo inicial: ");
			double saldoInicial = ObtemValorTransacao();

			Console.Write("Informe o valor do limite de crédito: ");
			double limiteCredito = ObtemValorTransacao();

			contas.Add(new Conta(tipoConta, saldoInicial, limiteCredito, nomeCliente));
		}

		private static void ListarContas()
		{
			Console.WriteLine("Listar contas existentes: ");

			if (contas.Count == 0)
			{
				Console.WriteLine("Não existem contas cadastradas!");
				return;
			}

			for (int i = 0; i < contas.Count; i++)
			{
				Console.WriteLine("#{0} - {1}", i, contas[i]);
			}
		}

		private static int ObtemNumeroConta()
		{
			int indiceConta = default(int);

			do
			{
				if (!int.TryParse(Console.ReadLine(), out indiceConta))
				{
					Console.Write("O número da conta é inválido. Tente novamente: ");
				}
				else if (!ExisteNumeroConta(indiceConta))
				{
					Console.Write("O número da conta não existe. Tente novamente: ");
				}
				else
				{
					break;
				}
			} while (true);

			return indiceConta;
		}

		private static double ObtemValorTransacao()
		{
			double valorTransacao = default(double);
			while (!double.TryParse(Console.ReadLine(), out valorTransacao))
			{
				Console.Write("O valor digitado é inválido. Informe corretamente o valor: ");
			}

			return valorTransacao;
		}

		private static TipoConta ObtemTipoConta()
		{
			int tipoConta = default(int);

			while (!(int.TryParse(Console.ReadLine(), out tipoConta) && Enum.IsDefined(typeof(TipoConta), tipoConta)))
			{
				Console.Write("O tipo de conta é inválido! Digite novamente: ");
			}

			return (TipoConta)tipoConta;
		}

		private static bool ExisteNumeroConta(int numeroConta)
		{
			return numeroConta < contas.Count;
		}
	}
}
