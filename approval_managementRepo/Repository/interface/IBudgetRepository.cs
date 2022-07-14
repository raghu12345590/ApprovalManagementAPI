using ApprovalManagementAPI.DataModel.DTO;
using ApprovalManagementAPI.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.DataModel.Repository.Interface
{
    public interface IBudgetRepository
{
       Task< List<RequestDetail>> GetAllRequestDetails();

       Task< List<RequestDetail>> GetRequestbyID(int id);

        Task<List<RequestDetail>> GetRequestByManagerId(int managerId, int requestStatus);

        RequestDetail GetRequestbyRequestId(int requestId);

       Task< List <RequestDetail>> GetRequestbyResult(int userId, int requestResultId);

       Task<int> updateDeleteRequest(int requestId, bool IsDeleted);

        Task<int> updateRequestResult(int requestId, int requestStatus);

        Task<int> updateRejectedReasonComment(int requestId, string comment);

        RequestDetail GetRequest(int id);

        int AddRequest(RequestDetail request);

        int DeleteRequest(int id);

        Task<int> UpdateRequest(RequestDetail requestDetail);

        RequestDetail UpdateRequestById(int id,RequestDetail request);



        
    }
}
