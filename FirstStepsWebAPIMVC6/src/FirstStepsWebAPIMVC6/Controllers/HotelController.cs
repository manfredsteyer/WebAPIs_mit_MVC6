using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FirstStepsWebAPIMVC6.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstStepsWebAPIMVC6.Controllers
{

    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        static List<Hotel> hotels;

        public HotelController()
        {
            if (hotels == null)
            {
                hotels = new List<Hotel>();

                hotels.Add(new Hotel {
                    Id = 1,
                    Name = "Hotel zur Post",
                    Sterne = 1
                });

                hotels.Add(new Hotel
                {
                    Id = 2,
                    Name = "Hotel Mama",
                    Sterne = 5
                });

            }
        }

        [HttpGet()]
        public List<Hotel> GetAll()
        {
            return hotels;
        }

        // /api/hotel/bySterne/3
        [HttpGet("bySterne/{minSterne}")]
        public List<Hotel> GetBySterne(int minSterne)
        {
            return hotels.Where(h => h.Sterne >= minSterne).ToList();
        }

        // GET /api/hotel/1
        [HttpGet("{id}")]
        public Hotel GetById(int id)
        {
            return hotels.Where(h => h.Id == id).FirstOrDefault();
        }

        // POST /api/hotel
        [HttpPost()]
        public IActionResult Post([FromBody] Hotel hotel)
        {
            hotels.Add(hotel);

            // return CreatedAtAction("GetById", new { id = hotel.Id }, hotel); // 201

            return new DemoActionResult
            {
                Id = hotel.Id,
                StatusCode = 201
            };
        }
    }
}
