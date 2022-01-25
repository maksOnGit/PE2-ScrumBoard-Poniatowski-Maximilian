﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirportLib.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // read
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);

        // create
        Task<bool> Create(T item);

        
    }
}
