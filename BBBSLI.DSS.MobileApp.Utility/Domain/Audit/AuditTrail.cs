using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Utility.Domain.Audit
{
    public sealed class AuditTrail
    {
        public Guid Id { get; set; }
        public string SfCode { get; set; }
        public string AffectedColumns { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string TableName { get; set; }
        public DateTime? DateTime { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string EntityId { get; set; }
    }
}
