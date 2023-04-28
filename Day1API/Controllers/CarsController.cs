using Day1API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day1API.filters;

namespace Day1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static List<Car> Cars = new List<Car>
        {
            new(1,"Car1","2019",10000,"Gas",new DateTime(2019,1,1)),
            new(2,"Car2","2020",10000,"Gas",new DateTime(2020,1,1)),
            new(3,"Car3","2018",15000, "Gas",new DateTime(2010,1,1)),
            new(4,"Car4","2021",17000, "Gas",new DateTime(2021,1,1)),
            new(5,"Car5","2022",11000, "Gas",new DateTime(2022,1,1)),
            new(6,"Car6","2019",9000, "Gas",new DateTime(2019,1,1))
        };

        [HttpGet]
        public ActionResult<List<Car>> GetAllCars()
        {
            return Cars;
            //return Ok(Cars);   
        }

        [HttpGet]
        [Route("{id}")]

        public ActionResult<Car> GetCarById(int id)
        {
            Car? car = Cars.FirstOrDefault(x => x.Id == id);
            if (car is null)
            {
                // return NotFound(new {Message="Car Not Found"});
                return NotFound(new GeneralResponse("Car Not Found"));
            }
            return car;
        }

        [HttpPost]
        [Route("V1")]
        public ActionResult AddCarV1(Car car)
        {
            car.Id = Cars.Count + 1;
            car.Type = "Gas";
            Cars.Add(car);
            //Next step (api/Cars/id) // successfully created//Message in Body
            return CreatedAtAction("GetCarById" //name of next step action
                , new { id = car.Id }, // parameters of next step
                new GeneralResponse("Car added Successfully")); //response body
        }


        [HttpPost]
        [Route("V2")]
        // Validate Type of Car “Electric, Gas, Diesel and Hybrid”.
        [ValidateCarType]
        public ActionResult AddCarV2(Car car)
        {

            //Executing
            car.Id = Cars.Count + 1;
            Cars.Add(car);
            //Next step (api/Cars/id) // successfully created//Message in Body
            return CreatedAtAction("GetCarById" //name of next step action
                , new { id = car.Id }, // parameters of next step
                new GeneralResponse("Car added Successfully")); //response body
        }

        [HttpPut]
        [Route("{id}")]

        public ActionResult UpdateCar(Car CarFromRequest, int id)
        {
            if (id != CarFromRequest.Id)
            {
                return BadRequest(new GeneralResponse("Bad Request"));
            }
            Car? CarToEdit = Cars.FirstOrDefault(x => x.Id == id);

            if (CarToEdit is null)
            { return NotFound(); }

            CarToEdit.Name = CarFromRequest.Name;
            CarToEdit.Model = CarFromRequest.Model;
            CarToEdit.Price = CarFromRequest.Price;

            return NoContent(); //204 
            // return Ok();

        }

        [HttpDelete]
        [Route("{id}")]

        public ActionResult DeleteCar(int id)
        {
            Car? CarToDelete = Cars.FirstOrDefault(x => x.Id == id);

            if (CarToDelete is null)
            { return NotFound(); }

            Cars.Remove(CarToDelete);
            return NoContent();

        }
    }

}
