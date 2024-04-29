using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.DataAccess.Interfaces;
using Exam.DataAccess.UseInMemoryDbContext;
using Exam.Models.Models.InmemoryDataModel;
using Exam.Models.Models.InMemoryDataModel;
using Microsoft.EntityFrameworkCore;

namespace Exam.DataAccess.Services
{
    public class InMemoryDataServiceDAL : IInMemoryDataServiceDAL
    {
        private readonly MyDbContext _context;

        public InMemoryDataServiceDAL(MyDbContext context)
        {
            _context = context;
        }

        public void AddCusData(InMemoryDataRequest input)
        {
            _context.InMemoryDataRequests.Add(new InMemoryDataRequest { CId = input.CId, FirstName = input.FirstName, Surname = input.Surname, TelNum = input.TelNum, Address = input.Address, TId = input.TId });
            _context.SaveChanges();
        }

        public void AddTrackData(InMemoryDataTrackRequest input)
        {
            _context.InMemoryDataTrackRequests.Add(new InMemoryDataTrackRequest { TId = input.TId, TrackingNum = input.TrackingNum, Type = input.Type, status = input.status });
            _context.SaveChanges();
        }

         public async Task<IEnumerable> GetAllDataCusAsync()
        {
            return await _context.InMemoryDataRequests.ToListAsync();
        }
        public async Task<IEnumerable> GetAllDataTrackAsync()
        {
            return await _context.InMemoryDataTrackRequests.ToListAsync();
        }





        public async Task<IEnumerable> GetDataJoinTableAsync()
        {
            var query2 = from InMemoryDataRequest in _context.InMemoryDataRequests
                         join InMemoryDataTrackRequest in _context.InMemoryDataTrackRequests on InMemoryDataRequest.TId equals InMemoryDataTrackRequest.TId
                         select new InMemoryDataDTOResponse
                         {
                             Id = InMemoryDataRequest.CId,
                             FirstName = InMemoryDataRequest.FirstName,
                             Surname = InMemoryDataRequest.Surname,
                             TelNum = InMemoryDataRequest.TelNum,
                             Address = InMemoryDataRequest.Address,
                             TrackingNum = InMemoryDataTrackRequest.TrackingNum,
                             Type = InMemoryDataTrackRequest.Type
                         };

            return await query2.AsNoTracking().ToListAsync();
        }

        
    }
}
