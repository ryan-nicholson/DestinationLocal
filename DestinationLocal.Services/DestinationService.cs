using DestinationLocal.Data;
using DestinationLocal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Services
{
    public class DestinationService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userID;
        public DestinationService(string userID)
        {
            _context = new ApplicationDbContext();
            _userID = userID;
        }

        public async Task<bool> CreateDestinationAsync(DestinationCreate model)
        {
            Destination entity = new Destination(model.Name, model.City, model.State, model.Country);

            _context.Destinations.Add(entity);
            var changeCount = await _context.SaveChangesAsync();

            return changeCount == 1;
        }

        public async Task<List<DestinationListItem>> GetAllDestinationsAsync()
        {
            var entityList = await _context.Destinations.ToListAsync();

            var destinationList = entityList.Select(destination => new DestinationListItem
            {
                DestinationId = destination.DestinationId,
                Name = destination.Name,
                City = destination.City,
                State = destination.State,
                Country = destination.Country,
            }).ToList();

            return destinationList;
            
        }
        public async Task<DestinationDetail> GetDestinationByIdAsync(int destinationId)
        {
            var entity = await _context.Destinations.FindAsync(destinationId);
            if (entity == null)
                return null;

            var model = new DestinationDetail
            {
                DestinationId = entity.DestinationId,
                Name = entity.Name,
                City = entity.City,
                State = entity.State,
                Country = entity.Country,
                Bars = entity.Bars.Select(bar => new BarListItem
                {
                    BarId = bar.BarId,
                    Name = bar.Name,
                    ServesFood = bar.ServesFood,
                    AverageRating = bar.AverageRating
                }).ToList(),
                Hotels = entity.Hotels.Select(hotel => new HotelListItem
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    AverageRating = hotel.AverageRating
                }).ToList()
            };

            foreach (var rating in entity.Ratings)
            {
                model.Ratings.Add(new DestinationRatingListItem
                {
                    RatingId = rating.RatingId,
                    DestinationId = rating.DestinationId,
                    DestinationName = rating.Name,
                    Comment = rating.Comment,
                    IsUserOwned = rating.UserId == _userID,
                    Grade = rating.Grade,
                    StayDate = rating.StayDate
                });
            }
            return model;
        }

        //EDIT

        //DELETE
    }
}
