using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarCenter.Domain.DTOs;
using CarCenter.Domain.Models;
using CarCenter.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarCenter.Repository.EFImplementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CarCenterContext _context;
        private readonly IMapper _mapper;

        public ClienteRepository(CarCenterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CrearCliente(ClienteDTO entidad)
        {
            Personas persona = _mapper.Map<Personas>(entidad);
            Clientes cliente = _mapper.Map<Clientes>(entidad);

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            cliente.PersonaId = persona.PersonaId;
            cliente.Persona = null;
            _context.Clientes.Add(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditarCliente(ClienteDTO entidad)
        {
            Personas persona = _mapper.Map<Personas>(entidad);
            Clientes cliente = _mapper.Map<Clientes>(entidad);

            _context.Entry(persona).State = EntityState.Modified;
            _context.Entry(cliente).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarCliente(ClienteDTO entidad)
        {
            Clientes cliente = _mapper.Map<Clientes>(entidad);

            _context.Entry(cliente).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ClienteDTO> ObtenerClientePorId(int id)
        {
            Clientes cliente = await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.ClienteId == id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> ObtenerClientes()
        {
            IEnumerable<Clientes> clientes = await _context.Clientes.Include("Persona").ToListAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }
    }
}
