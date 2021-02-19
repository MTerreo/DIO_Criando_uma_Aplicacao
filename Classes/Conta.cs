using System;

namespace MIO.Bank

{
    public class Conta
    {
        // Atributos
        private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
        private string Nome { get; set; } 

        // Métodos
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}

        public bool Sacar(double valorSaque)
		{
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            
            /* outra forma de fazer esta linha:
            this.Saldo = this.Saldo - valorSaque;
            */

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            // o  {0} é o this.Nome e o {1} é o this.Saldo !!!

            return true;
		}

        public void Depositar(double valorDeposito)
		{
            Console.WriteLine("Saldo da conta de {0} é {1}", this.Nome, this.Saldo);
            Console.WriteLine("Valor do depósito na conta de {0} é {1}", this.Nome, valorDeposito);
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

        public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}

    }
}