using DataLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class BL_EnterprisesTraining
    {
        DL_EnterprisesTraining obj_DL_EnterprisesTraining = new DL_EnterprisesTraining();
        public int BL_InsUpdEntTraining(ML_EnterprisesTraining obj_ML_EnterprisesTraining)
        {
            return obj_DL_EnterprisesTraining.DL_InsUpdEntTraining(obj_ML_EnterprisesTraining);
        }
        public ML_EnterprisesTraining GetDetailByEnrollmentId(int enrollmentId)
        {
            return obj_DL_EnterprisesTraining.GetDetailByEnrollmentId(enrollmentId);
        }
    }
}
