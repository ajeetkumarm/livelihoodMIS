using System.Collections.Generic;
using DataLayer;
using ModelLayer;
using System.Data;

namespace BusinessLayer
{
    public class BL_Village
    {
        DL_Village obj_DL_Village = new DL_Village();
        public int BL_InsUpdDelVillage(ML_Village obj_ML_Village)
        {
            return obj_DL_Village.DL_InsUpdDelVillage(obj_ML_Village);
        }
        public DataTable BL_VillageDetails(ML_Village obj_ML_Village)
        {
            return obj_DL_Village.DL_VillageDetails(obj_ML_Village);
        }
        public IList<VillageList> GetVillages(int pageNumber, int pageSize, string villageName)
        {
            return obj_DL_Village.GetVillages(pageNumber, pageSize, villageName);
        }
    }
}
