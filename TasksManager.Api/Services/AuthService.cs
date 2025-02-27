using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TasksManager.Api.Contexts;
using TasksManager.Api.DTOs;
using TasksManager.Api.Models;
using TasksManager.Api.Services.Interfaces;

namespace TasksManager.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;

        public AuthService(AppDbContext context
            , UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , IJwtTokenGenerator tokenGenerator
            , IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
            _mapper = mapper;
        }

        public async Task<LoginDto> Login(LoginRequestDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrEmpty(request.Email))
                throw new ArgumentException(nameof(request.Email));

            if (string.IsNullOrEmpty(request.Password))
                throw new ArgumentException(nameof(request.Password));

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email != null && x.Email.ToLower().Trim() == request.Email.ToLower().Trim());
            if (user == null)
                throw new Exception("User could not be found");

            bool isValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isValid)
                throw new Exception("User/password incorrect, please try again");

            var token = _tokenGenerator.GenerateToken(user);

            return new LoginDto
            {
                UserId = user.Id,
                Token = token,
            };
        }

        public async Task<UserDto?> Register(RegistrationRequestDto request)
        {
            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Email,
                NormalizedEmail = request.Email
            };

            if (string.IsNullOrWhiteSpace(request.Password))
                throw new ArgumentException(nameof(request.Password));

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(",", result.Errors.Select(x => $"{x.Code}: {x.Description}").ToList()));

            return _mapper.Map<UserDto>(user);
        }
    }
}
