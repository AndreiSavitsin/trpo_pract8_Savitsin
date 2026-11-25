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
    /// Логика взаимодействия для TrainingDiary.xaml
    /// </summary>
    public partial class TrainingDiary : Page
    {
        public ObservableCollection<Training> TrainingList { get; set; } = new();
        public TrainingDiary()
        {
            InitializeComponent();
            LoadTrainings();
            DataContext = this;
        }
        string FileName = "trainings.json";
        public Training? SelectedTraining { get; set; }

        private void LoadTrainings()
        {
            if (File.Exists(FileName))
            {
                try
                {
                    var items = JsonSerializer.Deserialize<ObservableCollection<Training>>(File.ReadAllText(FileName));
                    if (items != null)
                    {
                        TrainingList = items;
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить из файла", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        public void SaveTrainings()
        {
            File.WriteAllText(FileName, JsonSerializer.Serialize(TrainingList));
        }
        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TrainingDetails(TrainingList));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTraining == null)
            {
                MessageBox.Show("Выберите тренировку для редактирования", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            NavigationService.Navigate(new TrainingDetails(TrainingList, SelectedTraining));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTraining == null)
            {
                MessageBox.Show("Выберите тренировку для удаления", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show("Вы действительно хотите удалить тренировку?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                TrainingList.Remove(SelectedTraining);
                SaveTrainings();
            }
        }
    }
}
