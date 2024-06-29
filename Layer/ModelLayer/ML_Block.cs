using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ML_Block
    {
        public string Qstring { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
