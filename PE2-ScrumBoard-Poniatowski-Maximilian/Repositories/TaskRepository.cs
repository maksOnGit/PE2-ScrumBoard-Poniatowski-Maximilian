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
        public Task<bool> Create(ScrumTask item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScrumTask>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ScrumTask> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
