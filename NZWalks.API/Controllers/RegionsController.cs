using AutoMapper;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDBContext _dbContext;
        private readonly IMapper _mapper;
        public RegionsController(NZWalksDBContext dbContext,IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var regions = new List<Region>
        //    {
        //        new Region
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Atlanta Region",
        //            Code = "ATL",
        //            RegionImageURL = ""
        //        },
        //        new Region
        //        {
        //            Id = Guid.NewGuid(),
        //            Name="Georgia Region",
        //            Code="GRG",
        //            RegionImageURL=""
        //        },
        //        new Region
        //        {
        //            Id = Guid.NewGuid(),
        //            Name="Colmbia Region",
        //            Code="CMB",
        //            RegionImageURL=""
        //        }
        //    };
        //    return Ok(regions);
        //}

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            //get data from database
            var regions = _dbContext.regions.ToList();

            ////map domain models to DTO's
            //var regionsList = new List<RegionDTO>();
            //foreach(var region in regions) 
            //{
            //    regionsList.Add(new RegionDTO()
            //    {
            //        Code = region.Code,
            //        Name = region.Name,
            //    });
            //}
             var regionsList = _mapper.Map<List<RegionDTO>>(regions);
            //var regionsList = regions.Adapt<List<RegionDTO>>();
            return Ok(regionsList);
        }
        [HttpGet]
        [Route("id")]
        public IActionResult GetRegionsById(Guid id)
        {
            var regions = _dbContext.regions.FirstOrDefault(x => x.Id == id);
            //if no data possible with that id
            if(regions == null)
            {
                return NotFound();
            }
            return Ok(regions);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegionDTO regions)
        {
            //Map or convert DTO to domain model
            var regionDomainModel = new Region
            {
                Code = regions.Code,
                Name = regions.Name
            };

            //Use domain model to create Region
            _dbContext.regions.Add(regionDomainModel);
            _dbContext.SaveChanges();

            //map domain model to dto's
            var regiondto = new RegionDTO()
            { Code=regionDomainModel.Code, Name=regionDomainModel.Name, };
            //return CreatedAtAction(nameof(GetAllRegions), new {Name=regionDomainModel.Name,Code=regionDomainModel.Code});
            return Ok(regiondto);
        }
        [HttpPut]
        [Route("{code}")]
        public IActionResult Update([FromRoute] string code,[FromBody] RegionDTO Regions)
        {
            var regionsList = _dbContext.regions.FirstOrDefault(x => x.Code == code);
            if(regionsList == null)
            {
                return NotFound();
            }
            //Map DTO to domain model
           regionsList.Name = Regions.Name;
            regionsList.Code = Regions.Code;
            //_dbContext.SaveChanges();
            var regiondto = new RegionDTO()
            {
                Code = regionsList.Code,
                Name = regionsList.Name,
            };
            _dbContext.SaveChanges();
            return Ok(regionsList);
        }
        [HttpDelete]
        [Route("{code}")]
        public IActionResult Delete([FromRoute] string code) 
        {
            var regionsList = _dbContext.regions.FirstOrDefault(x=>x.Code == code);
            if(regionsList == null)
            {
                return NotFound();
            }
            _dbContext.Remove(regionsList);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
