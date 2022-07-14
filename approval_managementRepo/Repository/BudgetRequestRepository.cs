using ApprovalManagementAPI.DataModel.DTO;
using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.DataModel.Helper;
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
            
            return await _context.RequestDetails.Where(x => x.UserId == id && x.IsDeleted == false).OrderByDescending(x=>x.RequestId).ToListAsync();
           
        }

        public async Task<List<RequestDetail>> GetRequestByManagerId(int managerId, int requestStatus)
        {
            return await _context.RequestDetails.Where(x => x.ManagerId == managerId && x.IsDeleted == false && x.RequestStatus == requestStatus).ToListAsync();
        }

        public RequestDetail GetRequestbyRequestId(int id)
        {
            var Request1 = _context.RequestDetails.FirstOrDefault(x => x.RequestId == id && x.IsDeleted == false);
            if (Request1 != null)
            {
                _context.Entry(Request1).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return Request1;
            }
            return null;
            //return await _context.RequestDetails.FirstOrDefault(x => x.RequestId == id && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<RequestDetail>> GetRequestbyResult(int userId, int requestResultId)
        {
            return await _context.RequestDetails.Where(x=>x.UserId == userId && x.RequestStatus == requestResultId && x.IsDeleted == false).OrderByDescending(x => x.RequestId).ToListAsync();
        }

        public async Task<int> updateDeleteRequest(int id, bool IsDeleted)
        {
            if (id != 0)
            {
                var requestDetail = new RequestDetail { RequestId = id, IsDeleted = IsDeleted };
                _context.RequestDetails.Attach(requestDetail).Property(x => x.IsDeleted).IsModified = true;
                await _context.SaveChangesAsync(true);
               
                return 1;
                
            }
            return 0;
        }

        public async Task<int> updateRequestResult(int requestId, int requestStatus)
        {
            if(requestId != 0)
            {
                RequestDetail request = (RequestDetail)_context.RequestDetails.Where(x => x.RequestId == requestId);
                var requestDetail = new RequestDetail { RequestId = requestId, RequestStatus = requestStatus };
                var managerEmail = _context.UserInfos.Where(x => x.UserId == request.UserId).Select(y => y.EmailId).SingleOrDefault();
                _context.RequestDetails.Attach(requestDetail).Property(x => x.RequestStatus).IsModified = true;
                await _context.SaveChangesAsync(true);
                return 1;
            }
            return 0;
        }

        public async Task<int> updateRejectedReasonComment(int requestId, string reason)
        {
            if(requestId != 0)
            {
                var requestDetail = new RequestDetail { RequestId = requestId, Comments = reason };
                _context.RequestDetails.Attach(requestDetail).Property(x => x.Comments).IsModified = true;
                await _context.SaveChangesAsync(true);
                return 1;
            }
            return 0;
        }

        public RequestDetail GetRequest(int id)
        {
            return _context.RequestDetails.FirstOrDefault(x => x.RequestId == id);
        }

        public int AddRequest(RequestDetail request)
        {
           
            _context.RequestDetails.Add(request);
            _context.SaveChanges();
            var managerEmail = _context.UserInfos.Where(x => x.UserId == request.ManagerId).Select(y => y.EmailId).SingleOrDefault();
            EmailNotification.Emailnotification(managerEmail, request);
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

       
        public async Task<int> UpdateRequest(RequestDetail requestDetail)
        {
            try
            {
                _context.Entry(requestDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync(true);
                return 1;
            }
            catch
            {
                Exception ex;
                return -1;
            }
        }



        public RequestDetail UpdateRequestById(int id,RequestDetail request)
        {
            
                _context.RequestDetails.Update(request);
                _context.SaveChanges();
                return null;
                 
        }

       



    }
}
