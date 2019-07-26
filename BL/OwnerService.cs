using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Models;
using DAL.Entity;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BL
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository<Owner> _ownerRepository;

        public OwnerService(IOwnerRepository<Owner> ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }


        public IEnumerable<OwnerModel> GetAllOwners()
        {
            return Mapper.Map<IEnumerable<OwnerModel>>(_ownerRepository.GetAll());
        }


        public ListOwners OwnersSorting(OwnerFormData ownerFormData)
        {
            ListOwners listOwners = new ListOwners();
            listOwners.Owners = Mapper.Map<IEnumerable<OwnerModel>>(_ownerRepository.GetAllSorting(ownerFormData));
            listOwners.TotalPages = _ownerRepository.TotalPages(ownerFormData.PageSize);

            return listOwners;
        }


        public async Task<List<CarModel>> GetOwnerCar(int id)
        {
            return Mapper.Map<List<CarModel>>(await _ownerRepository
                .GetCarsByOwnerId(id));
        }


        public async Task AddOwner(OwnerModel owner)
        {
            await _ownerRepository.Insert(Mapper.Map<Owner>(owner));
        }


        public async Task<OwnerModel> GetOwnerById(int id)
        {
            return Mapper.Map<OwnerModel>(await _ownerRepository.GetById(id));
        }


        public bool RemoveOwner(int id)
        {
            return _ownerRepository.RemoveById(id);
        }


        public int UpdateOwner(OwnerModel owner)
        {
            return _ownerRepository.Update(Mapper.Map<Owner>(owner));
        }

    }
}
