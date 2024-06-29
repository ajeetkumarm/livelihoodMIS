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
    public class BL_DigitalCategory
    {
        DL_DigitalCategory obj_DL_DigitalCategory = new DL_DigitalCategory();
        public int BL_InsUpdDelDigitalCategory(ML_DigitalCategory obj_ML_DigitalCategory)
        {
            return obj_DL_DigitalCategory.DL_InsUpdDelDigitalCategory(obj_ML_DigitalCategory);
        }
        public DataTable BL_DigitalCategoryDetails(ML_DigitalCategory obj_ML_DigitalCategory)
        {
            return obj_DL_DigitalCategory.DL_DigitalCategoryDetails(obj_ML_DigitalCategory);
        }
    }
}
