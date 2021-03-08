using System.Collections.Generic;
using System.Threading.Tasks;
using CarCenter.Domain.DTOs;

namespace CarCenter.Services.Interfaces
{
    public interface ICarroBusiness
    {
        Task<IEnumerable<CarroDTO>> ObtenerCarrosPorCliente(int clienteId);
        Task<CarroDTO> ObtenerCarrosPorId(int id);
        Task<bool> CrearCarro(CarroDTO entidad);
        Task<bool> EditarCarro(CarroDTO entidad);
        Task<bool> EliminarCarro(int id);
    }
}
