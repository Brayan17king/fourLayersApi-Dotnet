using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        private readonly FourLayersContext _context;

        public UserRepository(FourLayersContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users
                        .Include(u => u.Roles)
                        .Include(u => u.RefreshTokens)
                        .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }

        public async Task<UserEntity> GetByUsernameAsync(string username)
        {
            return await _context.Users
                        .Include(u => u.Roles)
                        .Include(u => u.RefreshTokens)
                        .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}