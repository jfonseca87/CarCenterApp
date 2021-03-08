using System.Collections.Generic;
using System.Threading.Tasks;
using CarCenter.Domain.DTOs;

namespace CarCenter.Repository.Interfaces
{
    public interface ICarroRepository
    {
        Task<IEnumerable<CarroDTO>> ObtenerCarrosPorCliente(int clienteId);
        Task<CarroDTO> ObtenerCarrosPorId(int id);
        Task<bool> CrearCarro(CarroDTO entidad);
        Task<bool> EditarCarro(CarroDTO entidad);
        Task<bool> EliminarCarro(CarroDTO entidad);
    }
}
