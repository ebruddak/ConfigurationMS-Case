using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messages
{
   public class CreateReportRequestMessageCommand
    {
        public string UUID { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime CreatedTime { get; set; }

        public bool Status { get; set; }
        public string ReportUrl { get; set; }

        public List<ReportItemDto> ReportItems { get; set; }
    }
    public class ReportItemDto
    {
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
