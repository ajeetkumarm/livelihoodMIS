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
    public class DL_Partner
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelPartner(ML_Partner obj_ML_Partner)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_Partner.Qstring),
                                 new SqlParameter("@PartnerId", obj_ML_Partner.PartnerId),
                                 new SqlParameter("@PartnerName", obj_ML_Partner.PartnerName),
                                 new SqlParameter("@CreatedBy", obj_ML_Partner.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_Partner.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_PartnerM", par);
        }
        public DataTable DL_PartnerDetails(ML_Partner obj_ML_Partner)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Partner.Qstring),
                                 new SqlParameter("@PartnerId", obj_ML_Partner.PartnerId),
                                 new SqlParameter("@PartnerName", obj_ML_Partner.PartnerName),
                                 new SqlParameter("@CreatedBy", obj_ML_Partner.CreatedBy),
                                 new SqlParameter("@UpdatedBy", obj_ML_Partner.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_PartnerM", par).Tables[0];
        }
    }
}
