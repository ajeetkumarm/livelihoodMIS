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
    public class BL_State
    {
        DL_State obj_DL_State = new DL_State();
        public int BL_InsState(ML_State obj_ML_State)
        {
            return obj_DL_State.DL_InsState(obj_ML_State);
        }
        public DataTable BL_StateDetails(ML_State obj_ML_State)
        {
            return obj_DL_State.DL_StateDetails(obj_ML_State);
        }
        public int BL_UpdState(ML_State obj_ML_State)
        {
            return obj_DL_State.DL_UpdState(obj_ML_State);
        }        
        public int BL_StateDelete(ML_State obj_ML_State)
        {
            return obj_DL_State.DL_StateDelete(obj_ML_State);
        }
    }
}
