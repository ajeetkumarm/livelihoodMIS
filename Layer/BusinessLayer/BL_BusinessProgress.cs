using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ModelLayer;
using System.Data;

namespace BusinessLayer
{
    public class BL_BusinessProgress
    {
        DL_BusinessProgress obj_DL_BusinessProgress = new DL_BusinessProgress();
        //public int BL_InsBusinessProgress(ML_BusinessProgress obj_ML_BusinessProgress)
        //{
        //    return obj_DL_BusinessProgress.DL_InsBusinessProgress(obj_ML_BusinessProgress);
        //}
        public void BL_InsBusinessProgress(ML_BusinessProgress obj_ML_BusinessProgress)
        {
            obj_DL_BusinessProgress.DL_InsBusinessProgress(obj_ML_BusinessProgress);
        }
        public DataTable BL_BusinessProgressDetails(ML_BusinessProgress obj_ML_BusinessProgress)
        {
            return obj_DL_BusinessProgress.DL_BusinessProgressDetails(obj_ML_BusinessProgress);
        }        
    }
}
