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
    public class BL_Theme
    {
        DL_Theme obj_DL_Theme = new DL_Theme();
        public int BL_InsUpdDelTheme(ML_Theme obj_ML_Theme)
        {
            return obj_DL_Theme.DL_InsUpdDelTheme(obj_ML_Theme);
        }
        public DataTable BL_ThemeDetails(ML_Theme obj_ML_Theme)
        {
            return obj_DL_Theme.DL_ThemeDetails(obj_ML_Theme);
        }
    }
}
