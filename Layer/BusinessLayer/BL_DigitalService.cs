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
    public class BL_DigitalService
    {
        DL_DigitalService obj_DL_DigitalService = new DL_DigitalService();
        public int BL_InsUpdDelDigitalService(ML_DigitalService obj_ML_DigitalService)
        {
            return obj_DL_DigitalService.DL_InsUpdDelDigitalService(obj_ML_DigitalService);
        }
        public DataTable BL_DigitalServiceDetails(ML_DigitalService obj_ML_DigitalService)
        {
            return obj_DL_DigitalService.DL_DigitalServiceDetails(obj_ML_DigitalService);
        }
    }
}
