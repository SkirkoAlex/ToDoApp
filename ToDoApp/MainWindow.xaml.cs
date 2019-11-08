using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json"; //хранит путь к файлу
        /// <summary>
        /// Контейнер для хранения модели данных
        /// ToDoModel - тип данных хранения
        /// </summary>
        ///private BindingList<ToDoModel> toDoDataList;
        private ObservableCollection<ToDoModel> toDoDataList = new ObservableCollection<ToDoModel>();

        private FileIOService fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileIOService = new FileIOService(PATH);
            ///Проверка на выпадение исключения. 
            ///Если загрузить файл не удается, покажется окно с ошибкой и закроется окно
            try
            {
                toDoDataList = fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

            dgToDoList.ItemsSource = toDoDataList; // Добавление модели (списка) в DataGrid.
            toDoDataList.CollectionChanged += ToDoDataList_CollectionChanged; //ToDoDataList_CollectionChanged - событие, на котрое мы подписались.
        }

        /// <summary>
        /// Подписывается на событие ToDoDataList_CollectionChanged.
        /// При обновлении информации в списке, вызывается событие
        /// </summary>
        /// <param name="sender">Список, который передается в событие</param>
        /// <param name="e">События</param>
        private void ToDoDataList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
            {
                ///Проверка на выпадение исключения. 
                ///Если cохранить файл не удается, покажется окно с ошибкой и закроется окно
                try
                {
                    fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
        }
    }
}
