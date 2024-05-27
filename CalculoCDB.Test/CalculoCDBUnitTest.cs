using CalculoCDB.Domain.Entidades;
using CalculoCDB.Domain.Services;

namespace CalculoCDB.Testes
{
	public class CalculoCDBUnitTest
	{
		private readonly CalculoCdbService _calculoCdbService;

		public CalculoCDBUnitTest()
		{
			_calculoCdbService = new CalculoCdbService();
		}

		[Fact]
		public void Calcula6MesesRendimentoCdb()
		{
			var cdb = new Cdb
			{
				Valor = 12000,
				Meses = 6
			};

			var result = _calculoCdbService.Calcular(cdb);

			Assert.NotNull(result);
			Assert.Equal(12717.07m, result.ValorBruto, 4);
			Assert.Equal(12555.73m, result.ValorLiquido, 4);
		}

		[Fact]
		public void Calcula12MesesRendimentoCdb()
		{
			var cdb = new Cdb
			{
				Valor = 1000,
				Meses = 12
			};

			var result = _calculoCdbService.Calcular(cdb);

			Assert.NotNull(result);
			Assert.Equal(1123.08m, result.ValorBruto, 4);
			Assert.Equal(1098.47m, result.ValorLiquido, 4);
		}

		[Fact]
		public void Calcula24MesesRendimentoCdb()
		{
			var cdb = new Cdb
			{
				Valor = 1000,
				Meses = 24
			};

			var result = _calculoCdbService.Calcular(cdb);

			Assert.NotNull(result);
			Assert.Equal(1261.31m, result.ValorBruto, 4);
			Assert.Equal(1215.58m, result.ValorLiquido, 4);
		}

		[Theory]
		[InlineData(6, 500, 112.5)]
		[InlineData(12, 500, 100)]
		[InlineData(24, 500, 87.5)]
		[InlineData(36, 500, 75)]
		public void CalculaImposto(int meses, decimal rendimento, decimal expectedImposto)
		{
			var imposto = _calculoCdbService.CalculaImposto(meses, rendimento);

			Assert.Equal(expectedImposto, imposto);
		}
	}
}