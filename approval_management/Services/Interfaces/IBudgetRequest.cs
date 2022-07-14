using System.Collections.Generic;
using System.Threading.Tasks;

using ApprovalManagementAPI.DataModel.Entities;

namespace ApprovalManagementAPI.Services
{
    public interface IBudgetRequestService
    {
       Task< List<RequestDetail>> GetAllRequestDetails();

        Task<List<RequestDetail>> GetRequestbyID(int id);

        Task<List<RequestDetail>> GetRequestByManagerId(int managerId, int requestStatus);

        RequestDetail GetRequestbyRequestId(int requestId);

        Task<List<RequestDetail>> GetRequestbyResult(int userId, int requestResultId);

        Task<int> updateDeleteRequest(int requestId, bool IsDeleted);

        Task<int> updateRequestResult(int requestId, int requestStatus);

        Task<int> updateRejectedReasonComment(int requestId, string comment);

        int AddRequest(RequestDetail request);

        int DeleteRequest(int id);

        Task<int> UpdateRequest(RequestDetail requestDetail);

      




    }
}
