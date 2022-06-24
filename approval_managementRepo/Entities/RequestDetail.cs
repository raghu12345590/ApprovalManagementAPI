using System;
using System.Collections.Generic;

#nullable disable

namespace ApprovalManagementAPI.DataModel.Entities
{
    public partial class RequestDetail
    {
        public int RequestId { get; set; }
        public int? UserId { get; set; }
        public int? ManagerId { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public int? EstAmount { get; set; }
        public int? AdvAmount { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? RequestStatus { get; set; }
        public string Comments { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual UserInfo User { get; set; }
    }
}
