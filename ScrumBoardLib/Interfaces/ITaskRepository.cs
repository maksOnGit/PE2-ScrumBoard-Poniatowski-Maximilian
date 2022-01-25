using AirportLib.Interfaces;
using ScrumBoardLib.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoardLib.Interfaces
{
    public interface ITaskRepository : IRepository<ScrumTask>
    {
        // delete
        Task<bool> DeleteById(int id);
    }
}
