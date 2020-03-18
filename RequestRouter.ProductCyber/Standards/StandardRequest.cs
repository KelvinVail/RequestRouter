using System;
using System.Collections.Generic;
using System.Text;

namespace RequestRouter.ProductCyber
{
    public class StandardRequest: StandardRequestBase
    {

        public string Insured { get; set; }
        public string Phone { get; set; }
        public string MailingAddress { get; set; }
        public string BusinessAddress { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiriationDate { get; set; }

        public int YearFounded { get; set; }
        public decimal PriorFiscalYearRevenue { get; set; }
        public decimal ProjectedFiscalYearRevenue { get; set; }
        public int NumEmployees { get; set; }
        public int NumProtectedRecords { get; set; }
        public string BusinessClass { get; set; }
        public decimal Limit { get; set; }
    }
}
