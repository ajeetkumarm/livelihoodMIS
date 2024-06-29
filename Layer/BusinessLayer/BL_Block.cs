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
    public class BL_Block
    {
        DL_Block obj_DL_Block = new DL_Block();
        public int BL_InsUpdDelBlock(ML_Block obj_ML_Block)
        {
            return obj_DL_Block.DL_InsUpdDelBlock(obj_ML_Block);
        }
        public DataTable BL_BLockDetails(ML_Block obj_ML_Block)
        {
            return obj_DL_Block.DL_BLockDetails(obj_ML_Block);
        }
    }
}
