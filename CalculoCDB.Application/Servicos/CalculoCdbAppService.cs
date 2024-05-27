using CalculoCDB.Application.Interfaces;
using CalculoCDB.Domain.Entidades;
using CalculoCDB.Domain.Interfaces;

namespace CalculoCDB.Application.Servicos
{
	public class CalculoCdbAppService : ICalculoCdbAppService
	{
		private readonly ICalculoCdbService _calculoCdbService;

		public CalculoCdbAppService(ICalculoCdbService calculoCdbService)
		{
			_calculoCdbService = calculoCdbService;
		}

		public ResponseCdb Calcular(decimal valor, int meses)
		{
			Cdb cdb = new Cdb { 
				Valor = valor, 
				Meses = meses 
			};

			return _calculoCdbService.Calcular(cdb);
		}
	}
}
