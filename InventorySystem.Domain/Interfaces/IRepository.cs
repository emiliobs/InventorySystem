using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Domain.Interfaces;

// GEneric interface for basic CRUD operations
public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);
}