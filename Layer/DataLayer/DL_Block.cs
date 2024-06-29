using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class DL_Block
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelBlock(ML_Block obj_ML_Block)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_Block.Qstring),
                                  new SqlParameter("@StateId", obj_ML_Block.StateId),
                                  new SqlParameter("@DistrictId", obj_ML_Block.DistrictId),
                                  new SqlParameter("@BlockId", obj_ML_Block.BlockId),
                                  new SqlParameter("@BlockName", obj_ML_Block.BlockName),
                                  new SqlParameter("@CreatedBy", obj_ML_Block.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Block.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_BlockM", par);
        }
        public DataTable DL_BLockDetails(ML_Block obj_ML_Block)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Block.Qstring),
                                  new SqlParameter("@StateId", obj_ML_Block.StateId),
                                  new SqlParameter("@DistrictId", obj_ML_Block.DistrictId),
                                  new SqlParameter("@BlockId", obj_ML_Block.BlockId),
                                  new SqlParameter("@BlockName", obj_ML_Block.BlockName),
                                  new SqlParameter("@CreatedBy", obj_ML_Block.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Block.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_BlockM", par).Tables[0];
        }
    }
}
