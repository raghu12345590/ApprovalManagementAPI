using ApprovalManagementAPI.DataModel.DTO;
using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.DataModel.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.DataModel.Repository
{
    public class BudgetRequestRepository : IBudgetRepository
    {
        private readonly BudgetRequestContext _context;
        public BudgetRequestRepository(BudgetRequestContext context)
        {
            _context = context;
        }
        public async Task<List<RequestDetail>> GetAllRequestDetails()
        {
            return await _context.RequestDetails.ToListAsync();
        }

        public async Task<List<RequestDetail>> GetRequestbyID(int id)
        {
            return await _context.RequestDetails.Where(x => x.UserId == id).ToListAsync();
        }

        public RequestDetail GetRequest(int id)
        {
            return _context.RequestDetails.FirstOrDefault(x => x.RequestId == id);
        }

        public int AddRequest(RequestDetail request)
        {
            _context.RequestDetails.Add(request);
            _context.SaveChanges();
            return 1;
        }

        public int DeleteRequest(int id)
        {
            RequestDetail requestDetail = GetRequest(id);
            if (requestDetail != null)
            {
                _context.RequestDetails.Remove(requestDetail);
                _context.SaveChanges(true);
                return 1;
            }
            return 0;
        }

        public RequestDetail UpdateRequest(RequestDetail request)
        {
            _context.RequestDetails.Update(request);
            _context.SaveChanges();
            return null;
        }

        public RequestDetail UpdateRequestById(int id,RequestDetail request)
        {
            
                _context.RequestDetails.Update(request);
                _context.SaveChanges();
                return null;
                 
        }

       



    }
}
