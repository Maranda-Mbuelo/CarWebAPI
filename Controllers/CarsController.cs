using CarWebAPI.Data;
using CarWebAPI.Models;
using CarWebAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CarWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarApiDbContext dbContext;

        public CarsController(CarApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await dbContext.Cars.ToListAsync();
            return Ok(cars);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCarById")]
        public async Task<IActionResult> GetCarById(Guid id)
        {
            var car = await dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (car != null)
            {
                return Ok(car);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromForm] AddCarRequest addCarRequest)
        {
            if (addCarRequest.CarImage == null || addCarRequest.CarImage.Length == 0)
            {
                return BadRequest("No image file found");
            }

            // Convert DTO to Entity
            var car = new CarProperties()
            {
                CarName = addCarRequest.CarName,
                CarModel = addCarRequest.CarModel,
                CarType = addCarRequest.CarType,
                YearName = addCarRequest.YearName,
                CarYearMake = addCarRequest.CarYearMake,
                CarTransmission = addCarRequest.CarTransmission,
                CarEngineType = addCarRequest.CarEngineType,
                CarNoOfGears = addCarRequest.CarNoOfGears,
                CarHorsePower = addCarRequest.CarHorsePower,
                CarTorque = addCarRequest.CarTorque,
                CarKilowatts = addCarRequest.CarKilowatts,
                CarEngineSize = addCarRequest.CarEngineSize,
                CarNoOfSeats = addCarRequest.CarNoOfSeats,
                CarFuelConsuption = addCarRequest.CarFuelConsuption,
                CarFuelTankSize = addCarRequest.CarFuelTankSize,
                CarAcceleration = addCarRequest.CarAcceleration,
                CarPrice = addCarRequest.CarPrice,
                UrlHandle = addCarRequest.UrlHandle,
                Author = addCarRequest.Author,
            };
            car.Id = Guid.NewGuid();

            // Convert image to byte array
            using (var memoryStream = new MemoryStream())
            {
                await addCarRequest.CarImage.CopyToAsync(memoryStream);
                car.CarFeaturedImage = memoryStream.ToArray();

                // Convert byte array to base64 string
                car.CarFeaturedImageUrl = Convert.ToBase64String(car.CarFeaturedImage);
            }

            // Save the car entity to the database
            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCar([FromRoute] Guid id, UpdateCarRequest updateCarRequest)
        {
            // Check if car exists
            var existingCar = await dbContext.Cars.FindAsync(id);

            if (existingCar != null)
            {
                existingCar.CarName = updateCarRequest.CarName;
                existingCar.CarModel = updateCarRequest.CarModel;
                existingCar.CarType = updateCarRequest.CarType;
                existingCar.YearName = updateCarRequest.YearName;
                existingCar.CarYearMake = updateCarRequest.CarYearMake;
                existingCar.CarTransmission = updateCarRequest.CarTransmission;
                existingCar.CarEngineType = updateCarRequest.CarEngineType;
                existingCar.CarNoOfGears = updateCarRequest.CarNoOfGears;
                existingCar.CarHorsePower = updateCarRequest.CarHorsePower;
                existingCar.CarTorque = updateCarRequest.CarTorque;
                existingCar.CarKilowatts = updateCarRequest.CarKilowatts;
                existingCar.CarEngineSize = updateCarRequest.CarEngineSize;
                existingCar.CarNoOfSeats = updateCarRequest.CarNoOfSeats;
                existingCar.CarFuelConsuption = updateCarRequest.CarFuelConsuption;
                existingCar.CarFuelTankSize = updateCarRequest.CarFuelTankSize;
                existingCar.CarAcceleration = updateCarRequest.CarAcceleration;
                existingCar.CarPrice = updateCarRequest.CarPrice;
                existingCar.UrlHandle = updateCarRequest.UrlHandle;
                existingCar.Author = updateCarRequest.Author;

                dbContext.SaveChanges();

                return Ok(existingCar);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var existingCar = await dbContext.Cars.FindAsync(id);

            if (existingCar != null)
            {
                dbContext.Remove(existingCar);
                await dbContext.SaveChangesAsync();
                return Ok(existingCar);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
