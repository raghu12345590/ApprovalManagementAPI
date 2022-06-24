using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.DataModel.DTO
{
    public class BudgetDto
    {
        public string Purpose { get; set; }
        public string Description { get; set; }
        public int? EstAmount { get; set; }
        public int? AdvAmount { get; set; }
    }
}
