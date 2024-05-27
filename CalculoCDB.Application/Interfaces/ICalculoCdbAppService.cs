using CalculoCDB.Domain.Entidades;

namespace CalculoCDB.Application.Interfaces
{
    public interface ICalculoCdbAppService
	{
		ResponseCdb Calcular(decimal valor, int meses);
	}
}
