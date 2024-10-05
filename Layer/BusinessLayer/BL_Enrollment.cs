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
            var data = obj_DL_Enrollment.GetEnterpriseSetupList(createdUser, projectId, pageNumber, pageSize, search);
            foreach (var item in data)
            {
                item.DisplayDelete = createdUser != 1 ? "display:none" : "";
            }
            return data;
        }
        public IList<BusinessProgressList> GetBusinessProgressList(int createdUser, int projectId, int pageNumber, int pageSize, string search)
        {
            var data= obj_DL_Enrollment.GetBusinessProgressList(createdUser, projectId, pageNumber, pageSize, search);
            foreach (var item in data)
            {
                item.DisplayDelete = createdUser != 1 ? "display:none" : "";
            }
            return data;
        }
        public bool EDPTrainingMoveToEnrollment(int enrollmentId, int updatedBy)
        {
            return obj_DL_Enrollment.EDPTrainingMoveToEnrollment(enrollmentId, updatedBy);
        }
        public bool EnterpriseSetupMoveToEDPTraining(int enrollmentId, int updatedBy)
        {
            return obj_DL_Enrollment.EnterpriseSetupMoveToEDPTraining(enrollmentId, updatedBy);
        }
        public bool BusinessProgressMoveToEnterpriseSetup(int enrollmentId, int updatedBy)
        {
            return obj_DL_Enrollment.BusinessProgressMoveToEnterpriseSetup(enrollmentId, updatedBy);
        }
        public ML_Enrollment GetEnrollmentDetail(int enrollmentId)
        {
            return obj_DL_Enrollment.GetEnrollmentDetail(enrollmentId);
        }
    }
}
