using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarCenter.Domain.DTOs;
using CarCenter.Repository.Interfaces;
using CarCenter.Services.Interfaces;

namespace CarCenter.Services.EFImplementations
{
    public class CarroBusiness : ICarroBusiness
    {
        private readonly ICarroRepository _carroRepository;

        public CarroBusiness(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }
        public async Task<bool> CrearCarro(CarroDTO entidad)
        {
            return await _carroRepository.CrearCarro(entidad);
        }

        public async Task<bool> EditarCarro(CarroDTO entidad)
        {
            return await _carroRepository.EditarCarro(entidad);
        }

        public async Task<bool> EliminarCarro(int id)
        {
            CarroDTO carro = await _carroRepository.ObtenerCarrosPorId(id);

            if (carro is null)
            {
                await Task.FromResult(false);
            }

            return await _carroRepository.EliminarCarro(carro);
        }

        public async Task<IEnumerable<CarroDTO>> ObtenerCarrosPorCliente(int clienteId)
        {
            return await _carroRepository.ObtenerCarrosPorCliente(clienteId);
        }

        public async Task<CarroDTO> ObtenerCarrosPorId(int id)
        {
            return await _carroRepository.ObtenerCarrosPorId(id);
        }
    }
}
