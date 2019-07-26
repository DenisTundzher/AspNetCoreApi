using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace BL
{
    public interface IOwnerService
    {
        IEnumerable<OwnerModel> GetAllOwners();
        Task AddOwner(OwnerModel owner);
        Task<OwnerModel> GetOwnerById(int id);
        bool RemoveOwner(int id);
        int UpdateOwner(OwnerModel owner);
        Task<List<CarModel>> GetOwnerCar(int id);
        ListOwners OwnersSorting(OwnerFormData ownerFormData);
    }
}
