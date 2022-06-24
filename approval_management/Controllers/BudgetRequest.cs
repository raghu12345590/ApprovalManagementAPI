using ApprovalManagementAPI.Services;
using ApprovalManagementAPI.DataModel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetRequest : ControllerBase
    {
        private readonly IBudgetRequestService _budgetRequest;

        public BudgetRequest(IBudgetRequestService budgetRequest)
        {
            _budgetRequest = budgetRequest;

        }

        [HttpGet]
        [Route("api/Requests")]
        public async Task<ActionResult<List<RequestDetail>>> GetAllRequests()
        {
            return await _budgetRequest.GetAllRequestDetails();
        }

        //GET: api/RequestDetail/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RequestDetail>>> GetRequestbyID(int id)
        {
            return await _budgetRequest.GetRequestbyID(id);
        }

        [HttpPost]
        public int AddRequest(RequestDetail requestDetail)
        {
            return _budgetRequest.AddRequest(requestDetail);

        }

        [HttpDelete("{id}")]
        public int DeleteRequest(int id)
        {
            return _budgetRequest.DeleteRequest(id);

        }

        [HttpPut]
        public ActionResult<RequestDetail> UpdateRequest(RequestDetail requestDetail)
        {
            return _budgetRequest.UpdateRequest(requestDetail);
        }

        [HttpPut("{id}")]
        public ActionResult<RequestDetail> UpdateRequestById(RequestDetail requestDetail)
        {
            return _budgetRequest.UpdateRequest(requestDetail);
        }
    }
}
