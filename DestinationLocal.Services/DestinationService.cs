using DestinationLocal.Data;
using System;
using System.Collections.Generic;
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
    }
}
