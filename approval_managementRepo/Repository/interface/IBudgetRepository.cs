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

        RequestDetail GetRequest(int id);

        int AddRequest(RequestDetail request);

        int DeleteRequest(int id);

        RequestDetail UpdateRequest(RequestDetail request);

        RequestDetail UpdateRequestById(int id,RequestDetail request);

        
    }
}
