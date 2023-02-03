using API.DTOS;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<User>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
           var user = await _userRepository.GetUserById(id);
           
           return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, [FromBody]User user)
        {
            if(user == null){
                return NotFound();
            }

           _userRepository.Update(user);
           await _userRepository.SaveAsync();

           var updatedUser = await _userRepository.GetUserById(id);
           
           return Ok(_mapper.Map<User, UserDto>(updatedUser));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if(user == null) {
                return NotFound();
            }

            _userRepository.Delete(user);
            await _userRepository.SaveAsync();

            return Ok(_mapper.Map<User, UserDto>(user));
        }
    }
}