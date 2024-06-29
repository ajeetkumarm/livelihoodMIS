using System;
using System.Collections.Generic;
using System.Data;
using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BusinessProgressCustomerRepository
    {
        public static List<BPCDigitalCategory> GetCategoryAndServiceLineList()
        {
            List<BPCDigitalCategory> list = new List<BPCDigitalCategory>();
            try
            {
                var dataSet = SqlBusinessProgressCustomer.GetCategoryAndServiceLineList();
                DataTable dtCategory = dataSet.Tables[0];
                DataTable dtCategoryServiceLine = dataSet.Tables[1];

                foreach (DataRow row in dtCategory.Rows)
                {
                    list.Add(new BPCDigitalCategory
                    {
                        CategoryId = Convert.ToInt32(row["CategoryId"]),
                        Category = row["Category"].ToString()
                    });
                }
                foreach (var item in list)
                {
                    foreach (DataRow row in dtCategoryServiceLine.Rows)
                    {
                        if (item.CategoryId == Convert.ToInt32(row["DigitalCategoryId"]))
                        {
                            item.ServiceLines.Add(new BPCServiceLine
                            {
                                ServiceId = Convert.ToInt32(row["ServiceId"]),
                                DigitalCategoryId = Convert.ToInt32(row["DigitalCategoryId"]),
                                ServiceLine = row["ServiceLine"].ToString()
                            });
                        }
                    }
                }
            }
            catch 
            {

            }
            return list;
        }
    }
}
