using PE2_ScrumBoard_Poniatowski_Maximilian.Data;
using ScrumBoardLib.Entities;
using ScrumBoardLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ScrumBoardDbContext _context = null;
        public UserRepository(ScrumBoardDbContext ctx)
        {
            _context = ctx;
        }
        public async Task<bool> Create(User item)
        {
            _context.Users.Add(item);
            return await Task.FromResult(await _context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.FromResult(_context.Users);
        }

        public async Task<User> GetById(int id)
        {
            return await Task.FromResult(_context.Users.Where(u => u.Id == id).FirstOrDefault());
        }
    }
}
