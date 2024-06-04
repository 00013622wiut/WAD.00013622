using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00013622.Dtos;
using WAD._00013622.Interfaces;
using WAD._00013622.Models;
using WAD._00013622.Responses;

namespace WAD._00013622.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersWithOrdersAsync();
            var usersReadDto = _mapper.Map<IEnumerable<UserReadDto>>(users);
            return Ok(usersReadDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdWithOrdersAsync(id);
            if (user == null)
            {
                return NotFound(new BaseResponse { Success = false, Message = "User not found", Error = "NotFound" });
            }

            var userReadDto = _mapper.Map<UserReadDto>(user);
            return Ok(userReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateUser(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            await _userRepository.AddAsync(user);

            return Ok(new BaseResponse { Success = true, Message = "User added successfully", Error = null });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse>> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound(new BaseResponse { Success = false, Message = "User not found", Error = "NotFound" });
            }

            _mapper.Map(userUpdateDto, user);
            await _userRepository.UpdateAsync(user);

            return Ok(new BaseResponse { Success = true, Message = "User updated successfully", Error = null });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound(new BaseResponse { Success = false, Message = "User not found", Error = "NotFound" });
            }

            await _userRepository.DeleteAsync(id);
            return Ok(new BaseResponse { Success = true, Message = "User deleted successfully", Error = null });
        }
    }
}
