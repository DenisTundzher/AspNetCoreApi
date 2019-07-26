using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Interface
{
    public interface IOwnerRepository<T> where T : class
    {
        IEnumerable<Owner> GetAll();
        Task Insert(T entity);
        Task<Owner> GetById(int id);
        bool RemoveById(int id);
        int Update(Owner owner);
        Task<List<Car>> GetCarsByOwnerId(int id);
        IEnumerable<Owner> GetAllSorting(OwnerFormData ownerFormData);
        int TotalPages(int pageSize);
    }
}
