using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarCenter.Domain.DTOs;
using CarCenter.Domain.Models;
using CarCenter.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarCenter.Repository.EFImplementations
{
    public class CarroRepository : ICarroRepository
    {
        private readonly CarCenterContext _context;
        private readonly IMapper _mapper;

        public CarroRepository(CarCenterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CrearCarro(CarroDTO entidad)
        {
            Carros carro = _mapper.Map<Carros>(entidad);
            
            _context.Add(carro);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditarCarro(CarroDTO entidad)
        {
            Carros carro = _mapper.Map<Carros>(entidad);

            _context.Entry(carro).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public  async Task<bool> EliminarCarro(CarroDTO entidad)
        {
            Carros carro = _mapper.Map<Carros>(entidad);

            _context.Entry(carro).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CarroDTO>> ObtenerCarrosPorCliente(int clienteId)
        {
            IEnumerable<Carros> carrosCliente = await _context.Carros.Where(x => x.ClienteId == clienteId).AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<CarroDTO>>(carrosCliente);
        }

        public async Task<CarroDTO> ObtenerCarrosPorId(int id)
        {
            Carros carro = await _context.Carros.AsNoTracking().FirstOrDefaultAsync(x => x.ClienteId == id);
            return _mapper.Map<CarroDTO>(carro);
        }
    }
}
