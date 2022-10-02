using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VertexCore.Interfaces;
using VertexCore.Models;

namespace VertexInfrastrature.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUserAsync(User model)
        {
            await _context.AddAsync(model);

            return await SaveAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetAUserAsync(string Id)
        {
            var user = await _context.Users
                        .Where(x => x.Id == Id)
                        .FirstOrDefaultAsync();

            return user;
        }

        public async Task<bool> GetAUserByEmailAsync(string email)
        {
            var user = await _context.Users
                        .Where(x => x.Email == email)
                        .FirstOrDefaultAsync();

            return user != null;
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
