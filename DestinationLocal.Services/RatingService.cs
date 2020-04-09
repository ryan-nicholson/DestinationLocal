using DestinationLocal.Data;
using DestinationLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Services
{
    public class RatingService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userId;
        public RatingService(string userId)
        {
            _context = new ApplicationDbContext();
            _userId = userId;
        }

        public async Task<bool> CreateDestinationRatingAsync(DestinationRatingCreate model)
        {
            var entity = new DestinationRating
            {
                Comment = model.Comment,
                DestinationId = model.DestinationId,
                Grade = model.Grade,
                UserId = _userId,
                StayDate = model.StayDate
            };
            _context.Ratings.Add(entity);
            var changeCount = await _context.SaveChangesAsync();

            return changeCount == 1;
        }

        public async Task<bool> CreateBarRatingAsync(BarRatingCreate model)
        {
            var entity = new BarRating
            {
                Comment = model.Comment,
                BarId = model.BarId,
                Grade = model.Grade,
                UserId = _userId,
                StayDate = model.StayDate
            };
            _context.Ratings.Add(entity);
            var changeCount = await _context.SaveChangesAsync();

            return changeCount == 1;
        }
        public async Task<bool> CreateHotelRatingAsync(HotelRatingCreate model)
        {
            var entity = new HotelRating
            {
                Comment = model.Comment,
                HotelId = model.HotelId,
                Grade = model.Grade,
                UserId = _userId,
                StayDate = model.StayDate
            };
            _context.Ratings.Add(entity);
            var changeCount = await _context.SaveChangesAsync();

            return changeCount == 1;

        }
    }
}
