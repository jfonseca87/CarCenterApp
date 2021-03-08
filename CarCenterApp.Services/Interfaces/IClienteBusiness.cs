using System.Collections.Generic;
using System.Threading.Tasks;
using CarCenter.Domain.DTOs;

namespace CarCenter.Services.Interfaces
{
    public interface IClienteBusiness
    {
        Task<IEnumerable<ClienteDTO>> ObtenerClientes();
        Task<ClienteDTO> ObtenerClientePorId(int id);
        Task<bool> CrearCliente(ClienteDTO entidad);
        Task<bool> EditarCliente(ClienteDTO entidad);
        Task<bool> EliminarCliente(int id);
    }
}
