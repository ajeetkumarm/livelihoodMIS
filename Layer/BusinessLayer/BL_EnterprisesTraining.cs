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
    public class BL_EnterprisesTraining
    {
        DL_EnterprisesTraining obj_DL_EnterprisesTraining = new DL_EnterprisesTraining();
        public int BL_InsUpdEntTraining(ML_EnterprisesTraining obj_ML_EnterprisesTraining)
        {
            return obj_DL_EnterprisesTraining.DL_InsUpdEntTraining(obj_ML_EnterprisesTraining);
        }
    }
}
