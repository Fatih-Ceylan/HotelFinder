using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        //public HotelRepository(HotelDbContext dbContext)
        //{
        //    hotelDb = dbContext;
        //}
        private readonly HotelDbContext hotelDb = new HotelDbContext();
        public Hotel CreateHotel(Hotel hotel)
        {
            hotelDb.Hotels.Add(hotel);
            hotelDb.SaveChanges();
            return hotel;
        }

        public void DeleteHotel(int id)
        {
            var deletedHotel = GetHotelById(id);
            hotelDb.Remove(deletedHotel);
            hotelDb.SaveChanges();
        }

        public List<Hotel> GetAllHotels()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            hotelDb.Hotels.Update(hotel);
            return hotel;
        }
    }
}
