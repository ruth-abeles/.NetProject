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
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _roomService.GetAllRoomAsync();
            var listDto = _mapper.Map<IEnumerable<RoomDto>>(list);
            return Ok(listDto);
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
                return NotFound();
            var roomDto = _mapper.Map<IEnumerable<RoomDto>>(room);
            return Ok(roomDto);
        }

        // POST api/<RoomController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoomPostModel room)
        {
            var roomToAdd = _mapper.Map<Room>(room);
            var newRoom=_roomService.AddRoomAsync(roomToAdd);
            return Ok(_mapper.Map<RoomDto>(newRoom));
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Room room)
        {
            var roomToEdit= _mapper.Map<Room>(room);
            roomToEdit= await _roomService.UpdateRoomAsync(id, roomToEdit);
            return Ok(roomToEdit);
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _roomService.DeleteRoomAsync(id);
        }
    }
}
