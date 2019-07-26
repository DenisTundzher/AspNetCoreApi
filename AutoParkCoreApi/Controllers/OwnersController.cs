using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common.Models;
using BL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace AutoParkCoreApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }


        [HttpGet]
        [Route("Owners")]
        public ActionResult<IEnumerable<OwnerModel>> GetOwners()
        {
            var owners = _ownerService.GetAllOwners();

            return Ok(owners);
        }


        [HttpPost("{id}")]
        [Route("Owners/Cars/{id}")]
        public async Task<IActionResult> Cars([FromRoute]int id)
        {
            var cars = await _ownerService.GetOwnerCar(id);

            return Ok(cars);
        }



        [HttpPost]
        [Route("Owners/GetDataSorting")]
        public ActionResult<ListOwners> GetDataSorting([FromForm] OwnerFormData ownerFormData)
        {
            var owners = _ownerService.OwnersSorting(ownerFormData);
            return Ok(owners);
        }


        [HttpGet("{id}")]
        [Route("Owners/{id}")]
        public async Task<IActionResult> GetOwner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = await _ownerService.GetOwnerById(id);

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }


        [HttpPut("{id}")]
        [Route("Owners/Update/{id}")]
        public int Update(OwnerModel owner)
        {

            return _ownerService.UpdateOwner(owner);
        }


        [HttpPost]
        [Route("Owners/Create")]
        public async Task<IActionResult> Create([FromForm] OwnerModel owner)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);;
            await _ownerService.AddOwner(owner);

            return CreatedAtAction("GetOwner", new { id = owner.Id }, owner);
        }
        

        [HttpDelete("{id}")]
        [Route("Owners/Delete/{id}")]
        public IActionResult DeleteOwner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_ownerService.RemoveOwner(id));
        }
    }
}