using AutoMapper;
using DTOs = CarCenter.Domain.DTOs;
using Entidades = CarCenter.Domain.Models;

namespace CarCenter.Repository.Mappers
{
    public class CarroMapper : Profile
    {
        public CarroMapper()
        {
            CreateMap<Entidades.Carros, DTOs.CarroDTO>().ReverseMap();
        }
    }
}
