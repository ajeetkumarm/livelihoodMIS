using DataLayer;
using ModelLayer;
using System.Collections.Generic;
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
        public DataTable BL_EnterpriseDetails(ML_Enrollment obj_ML_Enrollment)
        {
            return obj_DL_Enrollment.DL_EnterpriseDetails(obj_ML_Enrollment);
        }
        public IList<EnterpriesSetupList> GetEnterpriseSetupList(int createdUser, int projectId, int pageNumber, int pageSize, string search)
        {
            return obj_DL_Enrollment.GetEnterpriseSetupList(createdUser, projectId, pageNumber, pageSize, search);
        }
        public IList<BusinessProgressList> GetBusinessProgressList(int createdUser, int projectId, int pageNumber, int pageSize, string search)
        {
            return obj_DL_Enrollment.GetBusinessProgressList(createdUser, projectId, pageNumber, pageSize, search);
        }
    }
}
