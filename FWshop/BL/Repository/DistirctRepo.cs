using AutoMapper;
using FWshop.BL.Interface;
using FWshop.Data.Database;
using FWshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace FWshop.BL.Repository
{
    public class DistirctRepo : IDistrict
    {
        private readonly DbContainer _context;
        private readonly IMapper _mapper;


        public DistirctRepo(DbContainer context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<DistrictVM> Get()
        {
            var getData = _context.District.Select(a => new DistrictVM
            {
                Id = a.Id,
                DistrictName = a.DistrictName,
                CityId = a.CityId
            }).ToList();
            return _mapper.Map<IEnumerable<DistrictVM>>(getData);
        }

        public DistrictVM GetById(int id)
        {
            var data = _context.District.Where(a => a.Id == id)
                                    .Select(a => new DistrictVM 
                                    { 
                                      Id = a.Id, 
                                      DistrictName = a.DistrictName,
                                      CityId = a.CityId 
                                    }) .FirstOrDefault();
                       return _mapper.Map<DistrictVM>(data);
        }
     
    }
}
