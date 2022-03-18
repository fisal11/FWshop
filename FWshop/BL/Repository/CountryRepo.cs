using AutoMapper;
using FWshop.BL.Interface;
using FWshop.Data.Database;
using FWshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace FWshop.BL.Repository
{
    public class CountryRepo : ICountry
    {
        private readonly DbContainer _context;
        private readonly IMapper _mapper;


        public CountryRepo(DbContainer context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public IEnumerable<CountryVM> Get()
        {
            var getData = _context.Country.Select(a => new CountryVM
            {
                Id = a.Id,
                CountryName = a.CountryName
            }).ToList();
            return _mapper.Map<IEnumerable<CountryVM>>(getData);
        }

        public CountryVM GetById(int id)
        {
            var data = _context.Emploee.Find(id);
            return _mapper.Map<CountryVM>(data);
        }


 
    }
}
