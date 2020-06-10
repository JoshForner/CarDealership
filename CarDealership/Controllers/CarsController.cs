using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsDBContext _context;
        public CarsController(CarsDBContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        public async Task<ActionResult<List<Cars>>> GetCars()
        {
            List<Cars> cars = await _context.Cars.ToListAsync();
            return cars;
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<Cars>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                return car;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<ActionResult<Cars>> AddCar(Cars car)
        {
            if (ModelState.IsValid)
            {
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCar(int id, Cars newCar)
        {
            if (id != newCar.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(newCar).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }

        
    }
}
