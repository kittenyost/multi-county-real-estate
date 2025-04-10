using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LivingCountyLewisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private static readonly List<dynamic> listings = new()
        {
            new {
                Id = 1,
                Title = "Modern Family Home",
                Price = 385000,
                Area = "426",
                Address = "123 Maple Street, Centralia, WA",
                Description = "Spacious 3-bedroom home with updated kitchen, fenced backyard, and two-car garage.",
                Image = "https://your-consistent-url.com/modern-familyhome.jpg"
            },
            new {
                Id = 3,
                Title = "Cozy Cabin",
                Price = 239000,
                Area = "426",
                Address = "42 Pine Lane, Mountain View, CO",
                Description = "Rustic 2-bed, 1-bath cabin nestled in the pines — perfect weekend getaway.",
                Image = "https://images.unsplash.com/photo-1600585154035-7c6c4c3a32c3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
            }
        };

        [HttpGet]
        public IActionResult GetListings()
        {
            return Ok(listings);
        }

        [HttpGet("{id}")]
        public IActionResult GetListingById(int id)
        {
            var listing = listings.FirstOrDefault(l => l.Id == id);
            if (listing == null) return NotFound();
            return Ok(listing);
        }

        [HttpGet("area/{areaNumber}")]
        public IActionResult GetListingsByArea(string areaNumber)
        {
            var filtered = listings.Where(l => l.Area == areaNumber).ToList();
            return Ok(filtered);
        }
    }
}