﻿using System;
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
    public class DL_DigitalService
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelDigitalService(ML_DigitalService obj_ML_DigitalService)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_DigitalService.Qstring),
                                 new SqlParameter("@ServiceId", obj_ML_DigitalService.ServiceId),
                                 new SqlParameter("@DigitalCategoryId", obj_ML_DigitalService.DigitalCategoryId),
                                 new SqlParameter("@ServiceLine", obj_ML_DigitalService.ServiceLine),
                                 new SqlParameter("@CreatedBy", obj_ML_DigitalService.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_DigitalService.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_DigitalServiceM", par);
        }
        public DataTable DL_DigitalServiceDetails(ML_DigitalService obj_ML_DigitalService)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_DigitalService.Qstring),
                                 new SqlParameter("@ServiceId", obj_ML_DigitalService.ServiceId),
                                 new SqlParameter("@DigitalCategoryId", obj_ML_DigitalService.DigitalCategoryId),
                                 new SqlParameter("@ServiceLine", obj_ML_DigitalService.ServiceLine),
                                 new SqlParameter("@CreatedBy", obj_ML_DigitalService.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_DigitalService.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_DigitalServiceM", par).Tables[0];
        }
    }
}
