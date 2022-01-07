using System;
using System.Text;
namespace DIO.Bank
{
	public class Conta
	{
		public TipoConta TipoConta { get; set; }
		public double Saldo { get; set; }
		public double Credito { get; set; }
		public string Nome { get; set; }

		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}

		public bool Sacar(double valorSaque)
		{
			if (this.Saldo - valorSaque < (this.Credito * -1))
			{
				Console.WriteLine("Saldo insuficiente");
				return false;
			}

			this.Saldo -= valorSaque;
			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

			return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;
			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

		}

		public void Transferir(double valorTransferencia, Conta destino)
		{
			if (this.Sacar(valorTransferencia))
			{
				destino.Depositar(valorTransferencia);
			}
		}

		public override string ToString()
		{
			StringBuilder retorno = new StringBuilder();

			retorno.Append($"TipoConta = {this.TipoConta}{Environment.NewLine}");
			retorno.Append($"Nome = {this.Nome}{Environment.NewLine}");
			retorno.Append($"Saldo = {this.Saldo.ToString("N2")}{Environment.NewLine}");
			retorno.Append($"Crédito = {this.Credito.ToString("N2")}");

			return retorno.ToString();
		}

	}
}