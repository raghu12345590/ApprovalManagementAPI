using System.Collections.Generic;
using System.Threading.Tasks;

using ApprovalManagementAPI.DataModel.Entities;

namespace ApprovalManagementAPI.Services
{
    public interface IBudgetRequestService
    {
       Task< List<RequestDetail>> GetAllRequestDetails();

        Task<List<RequestDetail>> GetRequestbyID(int id);

        int AddRequest(RequestDetail request);

        int DeleteRequest(int id);

        RequestDetail UpdateRequest(RequestDetail request);

        RequestDetail UpdateRequestById(int id,RequestDetail request);




    }
}
