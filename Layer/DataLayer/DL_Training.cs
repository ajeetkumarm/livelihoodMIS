using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using Microsoft.ApplicationBlocks.Data;

namespace DataLayer
{
    public class DL_Training
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdTraining(ML_Training obj_ML_Training)
        {
            SqlParameter[] par ={ new SqlParameter("@TrainingId", obj_ML_Training.TrainingId),
                                  new SqlParameter("@EnrollmentId", obj_ML_Training.EnrollmentId),
                                  new SqlParameter("@IsLifeSkillsTraining", obj_ML_Training.IsLifeSkillsTraining),
                                  new SqlParameter("@RCSCDate", obj_ML_Training.RCSCDate),
                                  new SqlParameter("@WRPCDate", obj_ML_Training.WRPCDate),
                                  new SqlParameter("@HNCDate", obj_ML_Training.HNCDate),
                                  new SqlParameter("@FLCDate", obj_ML_Training.FLCDate),
                                  new SqlParameter("@EDTSDate", obj_ML_Training.EDTSDate),
                                  new SqlParameter("@LEAPDate", obj_ML_Training.LEAPDate),
                                  new SqlParameter("@ESISDate", obj_ML_Training.ESISDate),
                                  new SqlParameter("@BMTCDate", obj_ML_Training.BMTCDate),
                                  new SqlParameter("@MMTCDate", obj_ML_Training.MMTCDate),
                                  new SqlParameter("@EDPTCDate", obj_ML_Training.EDPTCDate),
                                  new SqlParameter("@CreatedBy", obj_ML_Training.CreatedBy),
                                  new SqlParameter("@UpdateBy", obj_ML_Training.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_InsUpdTraining", par);
        }
        public DataTable DL_FieldTraining(ML_Training obj_ML_Training)
        {
            SqlParameter[] par = { new SqlParameter("@EnrollmentId", obj_ML_Training.EnrollmentId) };
            return SqlHelper.ExecuteDataset(con, "USP_FetchTraining", par).Tables[0];
        }







    }    
}
