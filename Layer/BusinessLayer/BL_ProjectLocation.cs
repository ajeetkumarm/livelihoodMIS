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
    public class BL_ProjectLocation
    {
        DL_ProjectLocation obj_DL_ProjectLocation = new DL_ProjectLocation();
        public int BL_InsUpdDelProjectLoction(ML_ProjectLocation obj_ML_ProjectLocation)
        {
            return obj_DL_ProjectLocation.DL_InsUpdDelProjectLoction(obj_ML_ProjectLocation);
        }
        public DataTable BL_ProjectLoctionDetails(ML_ProjectLocation obj_ML_ProjectLocation)
        {
            return obj_DL_ProjectLocation.DL_ProjectLoctionDetails(obj_ML_ProjectLocation);
        }
    }
}
