using AutoMapper;
using FWshop.Data.Entity;
using FWshop.Models;
using FWshop.Models.DTO;

namespace FWshop.Mapper
{
    public class FWShopMapper : Profile
    {
        public FWShopMapper()
        {
            CreateMap<Department, DepartmentVM>().ReverseMap();
            CreateMap<Emploee, EmploeeVM>().ReverseMap();
            CreateMap<Country, CountryVM>().ReverseMap();
            CreateMap<City, CityVM>().ReverseMap();
            CreateMap<District, DistrictVM>().ReverseMap();


        }
    }
}
