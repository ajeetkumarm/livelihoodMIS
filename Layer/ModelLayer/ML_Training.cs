using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ML_Training
    {
        public string ProjectCode { get; set; }
        public int TrainingId { get; set; }
        public int EnrollmentId { get; set; }
        public string IsLifeSkillsTraining { get; set; }
        public string RCSCDate { get; set; }
        public string WRPCDate { get; set; }
        public string HNCDate { get; set; }
        public string FLCDate { get; set; }
        public string EDTSDate { get; set; }
        public string LEAPDate { get; set; }
        public string ESISDate { get; set; }
        public string BMTCDate { get; set; }
        public string MMTCDate { get; set; }
        public string EDPTCDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public string InductionTrainingDay1 { get; set; }
        public string InductionTrainingDay2 { get; set; }
        public string DigitalSkillTrainingDay1 { get; set; }
        public string DigitalSkillTrainingDay2 { get; set; }
        public string DigitalSkillTrainingDay3 { get; set; }
    }
}
