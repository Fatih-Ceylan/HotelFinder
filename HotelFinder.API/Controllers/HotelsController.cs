using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        //public HotelsController()
        //{
        //    _hotelService = new HotelManager();
        //}
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotel = _hotelService.GetAllHotels();
            return Ok(hotel); // response 200+ request body hotel
        }
        /// <summary>
        /// Get Hotel by specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates new hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Hotel hotel)
        {

            var createdModel = _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get" , new { id = createdModel.Id } , createdModel);

        }

        /// <summary>
        /// Updates hotel info
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }

        /// <summary>
        /// Deletes hotel with specified id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
