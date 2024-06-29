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
    public class BL_Project
    {
        DL_Project obj_DL_Project=new DL_Project();
        public int BL_InsUpdDelProject(ML_Project obj_ML_Project)
        {
            return obj_DL_Project.DL_InsUpdDelProject(obj_ML_Project);
        }
        public DataTable BL_ProjectDetails(ML_Project obj_ML_Project)
        {
            return obj_DL_Project.DL_ProjectDetails(obj_ML_Project);
        }
    }
}
