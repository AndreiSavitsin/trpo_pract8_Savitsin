using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace trpo_pract8_Savitsin
{
    public class Training
    {
        DatePicker trainingDate;
        string trainingType;
        int duration;
        string workLoad;
        string description;

        public DatePicker TrainingDate
        {
            get { return trainingDate; } 
            set { trainingDate = value; }
        }
        public string TrainingType
        {
            get { return trainingType; }
            set { trainingType = value; }
        }
        public int Duration
        {
            get { return duration; } 
            set {  duration = value; }
        }
        public string WorkLoad
        {
            get { return workLoad; }
            set { workLoad = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
