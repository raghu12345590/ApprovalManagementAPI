using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.DataModel.Repository;
using ApprovalManagementAPI.DataModel.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.Services
{
    public class BudgetRequestService : IBudgetRequestService
    {
        private readonly IBudgetRepository _budgetRequest;

        public BudgetRequestService(IBudgetRepository budgetRequest)
        {
            _budgetRequest = budgetRequest;

        }

        public Task<List<RequestDetail>> GetAllRequestDetails()
        {
            return  _budgetRequest.GetAllRequestDetails();
        }

        public Task<List<RequestDetail>> GetRequestbyID(int id)
        {
            return _budgetRequest.GetRequestbyID(id);
        }

        public Task<List<RequestDetail>> GetRequestByManagerId(int managerId, int requestStatus)
        {
            return _budgetRequest.GetRequestByManagerId(managerId, requestStatus);
        }

        public RequestDetail GetRequestbyRequestId(int id)
        {
            return _budgetRequest.GetRequest(id);
        }

        public Task<List<RequestDetail>> GetRequestbyResult(int userId, int requestResultId)
        {
            return _budgetRequest.GetRequestbyResult(userId,requestResultId);
        }

        public Task<int> updateDeleteRequest(int RequestId, bool IsDeleted)
        {
            return _budgetRequest.updateDeleteRequest(RequestId, IsDeleted);
        }

        public Task<int> updateRequestResult(int RequestId, int requestStatus)
        {
            return _budgetRequest.updateRequestResult(RequestId, requestStatus);
        }

        public Task<int> updateRejectedReasonComment(int RequestId, string comment)
        {
            return _budgetRequest.updateRejectedReasonComment(RequestId, comment);
        }

        public int AddRequest(RequestDetail request)
        {
            return _budgetRequest.AddRequest(request);
        }

        public int DeleteRequest(int id)
        {
            return (_budgetRequest.DeleteRequest(id));
        }

        public async Task<int> UpdateRequest(RequestDetail requestDetail)
        {
            return await _budgetRequest.UpdateRequest(requestDetail);
        }

      

    }
}
