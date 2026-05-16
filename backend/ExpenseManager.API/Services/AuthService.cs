using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.API.Data;
using ExpenseManager.API.DTOs.Auth;
using ExpenseManager.API.Exceptions;
using ExpenseManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var existingUser= await _context.Users
                .FirstOrDefaultAsync(user => user.Email == dto.Email);

            if(existingUser != null)
                throw new BusinessException("Email đã được sử dụng");

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                FullName = dto.FullName
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDto
            {
                Token=token,
                Email=user.Email,
                FullName = user.FullName
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(user => user.Email == dto.Email);

            if(user == null || !BCrypt.Net.BCrypt.Verify(dto.Password,user.PasswordHash))
                throw new BusinessException("Email hoặc mật khẩu không chính xác");

            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDto
            {
                Token=token,
                Email = user.Email,
                FullName = user.FullName
            };
        }
    }
}