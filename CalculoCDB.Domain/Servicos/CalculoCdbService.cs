using CalculoCDB.Domain.Interfaces;
using CalculoCDB.Domain.Entidades;

namespace CalculoCDB.Domain.Services
{
    public class CalculoCdbService : ICalculoCdbService
	{
		private const decimal RendimentoBanco = 1.08m;
		private const decimal RendimentoCDI = 0.009m;

		public ResponseCdb Calcular(Cdb cdb)
		{
			decimal valorBruto = CalculaValorBruto(cdb.Valor, cdb.Meses);
			decimal rendimento = valorBruto - cdb.Valor;
			decimal imposto = CalculaImposto(cdb.Meses, rendimento);

			var result = new ResponseCdb
			{
				ValorBruto = Math.Round(valorBruto, 2),
				ValorLiquido = Math.Round(valorBruto - imposto, 2)
			};

			return result;
		}

		private decimal CalculaValorBruto(decimal valorInicial, int numMeses)
		{
			var rendimentoCdiBanco = RendimentoCDI * RendimentoBanco;
			var valorFinal = valorInicial;

			for (int i = 0; i < numMeses; i++)
				valorFinal *= (1 + rendimentoCdiBanco);
			
			return valorFinal;
		}

        public decimal CalculaImposto(int meses, decimal rendimento)
        {
            return meses switch
            {
                <= 6 => (rendimento * 0.225m),
                <= 12 => (rendimento * 0.20m),
                <= 24 => (rendimento * 0.175m),
                _ => (rendimento * 0.15m)
            };
        }
    }
}
