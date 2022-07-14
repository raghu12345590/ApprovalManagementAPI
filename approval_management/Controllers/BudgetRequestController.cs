using ApprovalManagementAPI.Services;
using ApprovalManagementAPI.DataModel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApprovalManagementAPI.ServiceModels.DTO.Request;
using AutoMapper;

namespace ApprovalManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetRequestController : ControllerBase
    {
        private readonly IBudgetRequestService _budgetRequest;
        private readonly IMapper _mapper;

        public BudgetRequestController(IBudgetRequestService budgetRequest, IMapper mapper)
        {
            _budgetRequest = budgetRequest;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("api/Requests")]
        public async Task<ActionResult<List<RequestDetail>>> GetAllRequests()
        {
            return await _budgetRequest.GetAllRequestDetails();
        }

        //GET: api/RequestDetail/5
       [Authorize()]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RequestDetail>>> GetRequestbyID(int id)
        {
            return await _budgetRequest.GetRequestbyID(id);
        }

        [HttpGet("GetResultByManagerId/{managerId}/{requestStatus}")]
        public async Task<ActionResult<List<RequestDetail>>> GetResultByManagerId(int managerId,int requestStatus)
        {
          //  var response = _mapper.Map<RequestDetail>(managerId);
            return await _budgetRequest.GetRequestByManagerId(managerId,requestStatus);
        }
        [Authorize()]
        [HttpGet("GetRequestbyRequestId/{requestId}")]
        public ActionResult<RequestDetail> GetRequestbyRequestId(int requestId)
        {
            return _budgetRequest.GetRequestbyRequestId(requestId);
        }

        [HttpGet("{userId}/{requestResultId}")]
        public async Task<ActionResult<List<RequestDetail>>> GetRequestbyResult(int userId, int requestResultId)
        {
            return await _budgetRequest.GetRequestbyResult(userId,requestResultId);
        }

        [HttpPut("{RequestId}/{IsDeleted}")]
        public async Task<ActionResult<int>> updateDeleteRequest(int RequestId, bool IsDeleted)
        {
            return await _budgetRequest.updateDeleteRequest(RequestId, IsDeleted);
        }

        [HttpPut("updateRequestStatus/{requestId}/{requestStatus}")]
        public async Task<ActionResult<int>> updateResultRequest(int requestId, int requestStatus)
        {
            return await _budgetRequest.updateRequestResult(requestId, requestStatus);
        }

        [HttpPut("updateRejectedReasonComment/{RequestId}/{comment}")]
        public async Task<ActionResult<int>> updateRejectedReasonComment(int RequestId, string comment)
        {
            return await _budgetRequest.updateRejectedReasonComment(RequestId, comment);
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
        public async Task<int> UpdateRequest([FromBody] RequestDetailsDTO requestDetail)
        {
            var response = _mapper.Map<RequestDetail>(requestDetail);
            return await _budgetRequest.UpdateRequest(response);
        }


    }
}
