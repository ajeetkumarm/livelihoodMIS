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
    public class BL_Training
    {
        DL_Training obj_DL_Training = new DL_Training();
        public int BL_InsUpdTraining(ML_Training obj_ML_Training)
        {
            return obj_DL_Training.DL_InsUpdTraining(obj_ML_Training);
        }
        public DataTable BL_FieldTraining(ML_Training obj_ML_Training)
        {
            return obj_DL_Training.DL_FieldTraining(obj_ML_Training);
        }
    }
}
