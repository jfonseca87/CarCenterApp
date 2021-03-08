using AutoMapper;
using DTOs = CarCenter.Domain.DTOs;
using Entidades = CarCenter.Domain.Models;

namespace CarCenter.Repository.Mappers
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<Entidades.Clientes, DTOs.ClienteDTO>()
                .ForMember(dest => dest.PrimerNombre, opt => opt.MapFrom(src => src.Persona.PrimerNombre))
                .ForMember(dest => dest.SegundoNombre, opt => opt.MapFrom(src => src.Persona.SegundoNombre))
                .ForMember(dest => dest.PrimerApellido, opt => opt.MapFrom(src => src.Persona.PrimerApellido))
                .ForMember(dest => dest.SegundoApellido, opt => opt.MapFrom(src => src.Persona.SegundoApellido))
                .ForMember(dest => dest.TipoDocumento, opt => opt.MapFrom(src => src.Persona.TipoDocumento))
                .ForMember(dest => dest.NumeroDocumento, opt => opt.MapFrom(src => src.Persona.NumeroDocumento))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Persona.Celular))
                .ForMember(dest => dest.CorreoElectronico, opt => opt.MapFrom(src => src.Persona.CorreoElectronico))
                .ReverseMap();
        }
    }
}
