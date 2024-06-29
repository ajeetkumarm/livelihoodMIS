using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CL_DigitalService
/// </summary>
/// 

[Serializable]

public class CL_DigitalService
{
    public CL_DigitalService()
    {
        RecordCount = 0;
        ServiceDetailsCount = 0;
        gvUniqueID = String.Empty;
        XML_ServiceLoad = string.Empty;
        Root = string.Empty;
        CloseRoot = string.Empty;
        eindex = 0;
        Service_XML = string.Empty;
        EndService_Xml = string.Empty;
        ProcureBusinessCount = 0;
    }

    public int RecordCount { get; set; }
    public int ServiceDetailsCount { get; set; }
    public string gvUniqueID { get; set; }
    public string XML_ServiceLoad { get; set; }
    public string Root { get; set; }
    public string CloseRoot { get; set; }
    public int eindex { get; set; }
    public string Service_XML { get; set; }
    public string EndService_Xml { get; set; }
    public int ProcureBusinessCount { get; set; }

}