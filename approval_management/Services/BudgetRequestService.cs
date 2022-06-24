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

        public int AddRequest(RequestDetail request)
        {
            return _budgetRequest.AddRequest(request);
        }

        public int DeleteRequest(int id)
        {
            return (_budgetRequest.DeleteRequest(id));
        }

        public RequestDetail UpdateRequest(RequestDetail request)
        {
            return _budgetRequest.UpdateRequest(request);
        }

        public RequestDetail UpdateRequestById(int id,RequestDetail request)
        {
            return _budgetRequest.UpdateRequest(request);
        }


    }
}
