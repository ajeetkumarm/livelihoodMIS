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
    public class BL_Enrollment
    {
        DL_Enrollment obj_DL_Enrollment = new DL_Enrollment();
        public int BL_InsEnrollment(ML_Enrollment obj_ML_Enrollment)
        {
            return obj_DL_Enrollment.DL_InsEnrollment(obj_ML_Enrollment);
        }
        public DataTable BL_EnrollmentDetails(ML_Enrollment obj_ML_Enrollment)
        {
            return obj_DL_Enrollment.DL_EnrollmentDetails(obj_ML_Enrollment);
        }
        public int BL_UpdEDPTraning(ML_Enrollment obj_ML_Enrollment)
        {
            return obj_DL_Enrollment.DL_UpdEDPTraning(obj_ML_Enrollment);
        }
        public int BL_DeleteEnrollmentForm(ML_Enrollment obj_ML_Enrollment)
        {
            return obj_DL_Enrollment.DL_DeleteEnrollmentForm(obj_ML_Enrollment);
        }
    }
}
