using PE2_ScrumBoard_Poniatowski_Maximilian.Data;
using ScrumBoardLib.Entities;
using ScrumBoardLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ScrumBoardDbContext _context = null;
        public TaskRepository(ScrumBoardDbContext ctx)
        {
            _context = ctx;
        }
        public async Task<bool> Create(ScrumTask item)
        {
            _context.Tasks.Add(item);
            return await Task.FromResult(await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> DeleteById(int id)
        {
            _context.Tasks.Remove(_context.Tasks.Where(t => t.Id == id).FirstOrDefault());
            return await Task.FromResult(await _context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<ScrumTask>> GetAll()
        {
            return await Task.FromResult(_context.Tasks);
        }

        public async Task<ScrumTask> GetById(int id)
        {
            return await Task.FromResult(_context.Tasks.Where(t => t.Id == id).FirstOrDefault());
        }
        //TODO Implement in Inteface
        public async Task<bool> Update(ScrumTask task)
        {
            _context.Tasks.Update(task);
            int result = await _context.SaveChangesAsync();
            return await Task.FromResult(result > 0);
        }
    }
}
