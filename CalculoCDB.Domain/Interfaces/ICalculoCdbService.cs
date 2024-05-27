using CalculoCDB.Domain.Entidades;

namespace CalculoCDB.Domain.Interfaces
{
    public interface ICalculoCdbService
	{
		ResponseCdb Calcular(Cdb cdb);
	}
}
