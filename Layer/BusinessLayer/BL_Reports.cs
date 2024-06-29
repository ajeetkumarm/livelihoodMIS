using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ModelLayer;
using System.Data;

namespace BusinessLayer
{
    public class BL_Reports
    {
        DL_Reports obj_DL_Reports=new DL_Reports();

        public DataTable BL_RptEnrollmentDetails(ML_Reports obj_ML_Reports)
        {
            return obj_DL_Reports.DL_RptEnrollmentDetails(obj_ML_Reports);
        }
        public DataTable BL_RptTrainingDetails(ML_Reports obj_ML_Reports)
        {
            return obj_DL_Reports.DL_RptTrainingDetails(obj_ML_Reports);
        }
        public DataTable BL_RptEnterpriesTrainingDetails(ML_Reports obj_ML_Reports)
        {
            return obj_DL_Reports.DL_RptEnterpriesTrainingDetails(obj_ML_Reports);
        }
        public DataTable BL_RptBusinessProgressDetails(ML_Reports obj_ML_Reports)
        {
            return obj_DL_Reports.DL_RptBusinessProgressDetails(obj_ML_Reports);
        }
    }
}
