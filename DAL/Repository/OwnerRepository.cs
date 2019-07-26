using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using DAL.Data;
using DAL.Entity;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class OwnerRepository : IOwnerRepository<Owner>
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }


        public int TotalPages(int pageSize)
        {
            int totalRecord = _context.Owners.Count();
            return totalRecord / pageSize + ((totalRecord % pageSize) > 0 ? 1 : 0);
        }


        public IEnumerable<Owner> GetAllSorting(OwnerFormData ownerFormData)
        {
            ownerFormData.Page++;
            
            SortDirection direction = ownerFormData.SortedDesc 
                ? SortDirection.Descending 
                : SortDirection.Ascending;

            return _context.Owners.AsQueryable()
                .Sort<Owner>(ownerFormData.SortedId, direction)
                .Skip(ownerFormData.PageSize * (ownerFormData.Page - 1))
                .Take(ownerFormData.PageSize).ToList();
        }


        public async Task Insert(Owner owner)
        {
            _context.Add(owner);
            await _context.SaveChangesAsync();
        }


        public async Task<Owner> GetById(int id)
        {
            return await _context.Owners.FindAsync(id);
        }


        public bool RemoveById(int id)
        {
            var owner = _context.Owners.Find(id);
            _context.Owners.Remove(owner);
            _context.SaveChanges();

            return true;
        }


        public int Update(Owner owner)
        {
            _context.Entry(owner).State = EntityState.Modified;
            _context.SaveChanges();

            return 1;
        }


        public async Task<List<Car>> GetCarsByOwnerId(int id)
        {
            return await _context
                .CarOwners
                .Where(_ => _.Owner.Id == id)
                .Include(_ => _.Car)
                .Select(_ => _.Car)
                .ToListAsync();
        }

    }
}