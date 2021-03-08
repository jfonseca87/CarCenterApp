using AutoMapper;
using DTOs = CarCenter.Domain.DTOs;
using Entidades = CarCenter.Domain.Models;

namespace CarCenter.Repository.Mappers
{
    public class PersonaMapper : Profile
    {
        public PersonaMapper()
        {
            CreateMap<DTOs.ClienteDTO, Entidades.Personas>();
        }
    }
}
