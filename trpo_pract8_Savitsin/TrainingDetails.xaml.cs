using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace trpo_pract8_Savitsin
{
    /// <summary>
    /// Логика взаимодействия для TrainingDetails.xaml
    /// </summary>
    public partial class TrainingDetails : Page
    {
        ObservableCollection<Training> trainingList;
        Training? originalTraining;
        Training currentTraining;

        public TrainingDetails(ObservableCollection<Training> trainingList, Training? training = null)
        {
            InitializeComponent();

            this.trainingList = trainingList;
            originalTraining = training;

            if (originalTraining != null)
            {
                tbHeader.Text = "Редактирование тренировки";
                currentTraining = new Training
                {
                    TrainingType = originalTraining.TrainingType,
                    TrainingDate = originalTraining.TrainingDate,
                    WorkLoad = originalTraining.WorkLoad,
                    Duration = originalTraining.Duration,
                    Description = originalTraining.Description
                };
            }
            else
            {
                tbHeader.Text = "Создание тренировки";
                currentTraining = new Training
                {
                    TrainingDate = DateTime.Today
                };
            }

            DataContext = currentTraining;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentTraining.TrainingType) ||
                currentTraining.TrainingDate.Date > DateTime.Today ||
                string.IsNullOrWhiteSpace(currentTraining.WorkLoad) ||
                currentTraining.WorkLoad.Trim().Length < 3 ||
                currentTraining.Duration <= 0)
            {
                MessageBox.Show("Заполните все поля корректно");
                return;
            }

            if (originalTraining == null)
            {
                trainingList.Add(currentTraining);
            }
            else
            {
                originalTraining.TrainingType = currentTraining.TrainingType;
                originalTraining.TrainingDate = currentTraining.TrainingDate;
                originalTraining.WorkLoad = currentTraining.WorkLoad;
                originalTraining.Duration = currentTraining.Duration;
                originalTraining.Description = currentTraining.Description;
            }

            File.WriteAllText("trainings.json", JsonSerializer.Serialize(trainingList));
            NavigationService.GoBack();
        }
    }
}
