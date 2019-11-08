using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel;

namespace ToDoApp.Models
{
    class ToDoModel : INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Приватные поля
        /// </summary>
        private bool _isDone;
        private string _numberOfTask;
        private string _engineer;
        private string _note;

        #region Свойства


        /// <summary>
        /// Свойство "Выполнено"
        /// </summary>
        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                if (_isDone == value) return; //Если данные получаем те же самые, то ничего не делаем

                _isDone = value;
                OnPropertyChanged("IsDone"); // Иначе - вызываем событие OnPropertyChanged
            }
        }
        /// <summary>
        /// Свойство "Номер заявки"
        /// </summary>
        [JsonProperty(PropertyName = "numberOfTask")]
        public string NumberOfTask
        {
            get { return _numberOfTask; }
            set
            {
                if (_numberOfTask == value) return;//Если данные получаем те же самые, то ничего не делаем
                _numberOfTask = value;
                OnPropertyChanged("NumberOfTask");// Иначе - вызываем событие OnPropertyChanged
            }
        }
        /// <summary>
        /// Свойство "Инженер"
        /// </summary>
        [JsonProperty(PropertyName = "engineer")]
        public string Engineer
        {
            get { return _engineer; }
            set
            {
                if (_engineer == value) return;//Если данные получаем те же самые, то ничего не делаем
                _engineer = value;
                OnPropertyChanged("Engineer"); // Иначе - вызываем событие OnPropertyChanged
            }
        }

        /// <summary>
        /// Свойство "Примечание"
        /// </summary>
        [JsonProperty(PropertyName = "note")]
        public string Note
        {
            get { return _note; }
            set
            {
                if (_note == value) return;//Если данные получаем те же самые, то ничего не делаем
                _note = value;
                OnPropertyChanged("Note");// Иначе - вызываем событие OnPropertyChanged
            }
        }
        #endregion

        /// <summary>
        /// Событие, на которое подписывается ObservableCollection<ToDoModel> toDoDataList  и уведомляет об изменениях
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Обращается к событию и вызывает его
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // ? - проверка на null (если никто не подписался на событие). Вместо записи if(PropertyChanged!=null)....
            /*Invoke Метод выполняет поиск по родительской цепочке элемента управления до тех пор, 
             * пока не обнаружит элемент управления или форму, которые имеют обработчик окна,
             * если его базовый маркер окна текущего элемента управления еще не существует.
             * Если не удается найти соответствующий обработчик, Invoke метод вызовет исключение. 
             * Исключения, возникающие во время вызова, передаются обратно вызывающему объекту.
             * */
        }



    }
}
