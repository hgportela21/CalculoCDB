using CalculoCDB.Application.Interfaces;
using CalculoCDB.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CdbController : ControllerBase
	{
		private readonly ICalculoCdbAppService _calculoCdbAppService;

		private readonly ILogger<CdbController> _logger;

		public CdbController(ILogger<CdbController> logger, ICalculoCdbAppService calculadoraCdbAppService)
		{
			_logger = logger;
			_calculoCdbAppService = calculadoraCdbAppService;
		}

		[HttpGet("Calcular")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseCdb))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Post(decimal valor, int meses)
		{
			_logger.LogInformation($@"Cálculo do rendimento CDB para o Valor {valor} e para {meses} Meses.");

			if (valor <= 0)
				return BadRequest("Valor deve ser maior que zero");

			if(meses <= 1)
				return BadRequest("A Quantidade de Meses deve ser maior que 1");

			var result = _calculoCdbAppService.Calcular(valor, meses);
			return Ok(result);
		}
	}
}