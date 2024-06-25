using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using R_home.Core.DTOs;
using R_home.Core.Models;
using R_home.Core.Services;
using R_home.Models;
using R_home.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace R_home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyController : ControllerBase
    {
        private readonly IBabyService _babyService;
        private readonly IMapper _mapper;
        public BabyController(IBabyService babyService,IMapper mapper)
        {
            _babyService = babyService;
            _mapper = mapper;
        }


        // GET: api/<BabyController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = _babyService.GetAllBabiesAsync();
            var listDto = _mapper.Map<IEnumerable<BabyDto>>(list);
            return Ok(listDto);
        }

        // GET api/<BabyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var baby = _babyService.GetBabiesByIdAsync(id);
            if (baby == null)
                return NotFound();
            var babyDto = _mapper.Map<BabyDto>(baby);
            return Ok(babyDto);
        }

        // POST api/<BabyController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BabyPostModel babyPostModel)
        {
            var baby = _mapper.Map<Baby>(babyPostModel);
            var newBaby=await _babyService.AddBabiesAsync(baby);
            return Ok(_mapper.Map<BabyDto>(newBaby));
        }

        // PUT api/<BabyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BabyPostModel baby)
        {
            var babyToEdit=_mapper.Map<Baby>(baby);
            await _babyService.UpdateBabiesAsync(id, babyToEdit);
            return Ok(_mapper.Map<BabyDto>(babyToEdit));
        }

        // DELETE api/<BabyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _babyService.DeleteBabiesAsync(id);
        }
    }
}
