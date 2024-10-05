using System;
using System.Collections.Generic;
using ModelLayer;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class DL_Village
    {
        SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection);
        public int DL_InsUpdDelVillage(ML_Village obj_ML_Village)
        {
            SqlParameter[] par ={new SqlParameter("@QString", obj_ML_Village.Qstring),
                                  new SqlParameter("@StateId", obj_ML_Village.StateId),
                                  new SqlParameter("@DistrictId", obj_ML_Village.DistrictId),
                                  new SqlParameter("@BlockId", obj_ML_Village.BlockId),
                                  new SqlParameter("@VillageId", obj_ML_Village.VillageId),
                                  new SqlParameter("@VillageName", obj_ML_Village.VillageName),
                                  new SqlParameter("@CreatedBy", obj_ML_Village.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Village.UpdatedBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "USP_VillageM", par);
        }
        public DataTable DL_VillageDetails(ML_Village obj_ML_Village)
        {
            SqlParameter[] par = {new SqlParameter("@QString", obj_ML_Village.Qstring),
                                  new SqlParameter("@StateId", obj_ML_Village.StateId),
                                  new SqlParameter("@DistrictId", obj_ML_Village.DistrictId),
                                  new SqlParameter("@BlockId", obj_ML_Village.BlockId),
                                  new SqlParameter("@VillageId", obj_ML_Village.VillageId),
                                  new SqlParameter("@VillageName", obj_ML_Village.VillageName),
                                  new SqlParameter("@CreatedBy", obj_ML_Village.CreatedBy),
                                  new SqlParameter("@UpdatedBy", obj_ML_Village.UpdatedBy)
            };
            return SqlHelper.ExecuteDataset(con, "USP_VillageM", par).Tables[0];
        }

        public IList<VillageList> GetVillages(int pageNumber, int pageSize, string villageName)
        {
            List<VillageList> villageList = new List<VillageList>();
            using (SqlConnection con = new SqlConnection(DB_Connection.Livelihood_Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetVillages", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    if (!string.IsNullOrEmpty(villageName))
                    {
                        cmd.Parameters.AddWithValue("@VillageName", villageName);
                    }

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            VillageList obj_VillageList = new VillageList();
                            obj_VillageList.VillageId = Convert.ToInt32(dr["VillageId"]);
                            obj_VillageList.VillageName = Convert.ToString(dr["VillageName"]);
                            obj_VillageList.StateName = Convert.ToString(dr["StateName"]);
                            obj_VillageList.DistrictName = Convert.ToString(dr["DistrictName"]);
                            obj_VillageList.BlockName = Convert.ToString(dr["BlockName"]);
                            obj_VillageList.TotalCount = Convert.ToInt32(dr["TotalCount"]);
                            obj_VillageList.RowNum = Convert.ToInt32(dr["RowNum"]);
                            villageList.Add(obj_VillageList);
                        }
                    }
                }
            }
            return villageList;
        }
        public DataTable GetVillageListExport()
        {
            return SqlHelper.ExecuteDataset(con, "usp_GetVillageList_Export").Tables[0];
        }
    }
}
