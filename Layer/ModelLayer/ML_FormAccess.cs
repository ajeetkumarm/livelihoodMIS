using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ML_FormAccess
    {
        public int UserCode { get; set; }
        public int UserCategoryCode { get; set; }
        public int UserProjectCode { get; set; }
        public string FormAccess { get; set; }
        public string UpdatedBy { get; set; }
    }
}
