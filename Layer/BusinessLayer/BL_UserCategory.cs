using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class BL_UserCategory
    {
        DL_UserCategory obj_DL_UserCategory = new DL_UserCategory();
        public int BL_InsUpdDelUserCategory(ML_UserCategory obj_ML_UserCategory)
        {
            return obj_DL_UserCategory.DL_InsUpdDelUserCategory(obj_ML_UserCategory);
        }
        public DataTable BL_UserCategoryDetails(ML_UserCategory obj_ML_UserCategory)
        {
            return obj_DL_UserCategory.DL_UserCategoryDetails(obj_ML_UserCategory);
        }
    }
}
