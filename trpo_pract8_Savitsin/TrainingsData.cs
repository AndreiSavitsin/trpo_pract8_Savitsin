using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo_pract8_Savitsin
{
    public static class TrainingsData
    {
        public static ObservableCollection<Training> TrainingList { get; set; } = new();
    }
}
