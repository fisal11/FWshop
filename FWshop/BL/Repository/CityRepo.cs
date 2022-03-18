using AutoMapper;
using FWshop.BL.Interface;
using FWshop.Data.Database;
using FWshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FWshop.BL.Repository
{
    public class CityRepo : ICity
    {
        private readonly DbContainer _context;
        private readonly IMapper _mapper;


        public CityRepo(DbContainer context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<CityVM> Get()
        {
            var getData = _context.City.Select(a => new CityVM
            {
                Id = a.Id,
                CityName = a.CityName,
                CountryId = a.CountryId
            }).ToList();
            return _mapper.Map<IEnumerable<CityVM>>(getData);
        }

        public CityVM GetById(int id)
        {
            var data = _context.City.Find(id);
            return _mapper.Map<CityVM>(data);
        }

    }
}
