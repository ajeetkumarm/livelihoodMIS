using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class BL_Education
    {
        DL_Education obj_DL_Education = new DL_Education();
        public int BL_InsUpdDelEducation(ML_Education obj_ML_Education)
        {
            return obj_DL_Education.DL_InsUpdDelEducation(obj_ML_Education);
        }
        public DataTable BL_EducationDetails(ML_Education obj_ML_Education)
        {
            return obj_DL_Education.DL_EducationDetails(obj_ML_Education);
        }
    }
}
