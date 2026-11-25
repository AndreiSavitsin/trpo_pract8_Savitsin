using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace trpo_pract8_Savitsin
{
    public class Training : INotifyPropertyChanged
    {
        DateTime trainingDate = DateTime.Today;
        string trainingType = string.Empty;
        int duration;
        string workLoad = string.Empty;
        string description = string.Empty;

        public DateTime TrainingDate
        {
            get { return trainingDate; } 
            set 
            {
                trainingDate = value;
                OnPropertyChanged();
            }
        }
        public string TrainingType
        {
            get { return trainingType; }
            set 
            {
                trainingType = value;
                OnPropertyChanged();
            }
        }
        public int Duration
        {
            get { return duration; } 
            set 
            {
                duration = value;
                OnPropertyChanged();
            }
        }
        public string WorkLoad
        {
            get { return workLoad; }
            set 
            {
                workLoad = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
