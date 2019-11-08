using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    class FileIOService
    {
        private readonly string PATH; // Путь к файлу
            public FileIOService(string path)
        {
            PATH = path;
        }
        /// <summary>
        /// Считывает данные с жесткого диска
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ToDoModel> LoadData()
        {
            var fileExists = File.Exists(PATH); //Проверяем существует ли файл
            if (!fileExists) //Если не существует, создаем
            {
                File.CreateText(PATH).Dispose();
                return new ObservableCollection<ToDoModel>(); //Возвращаем пустой список, т.к. файл создали и он пуст
            }
            using (var reader = File.OpenText(PATH)) //Если существует, открываем
            {
                string fileText = reader.ReadToEnd(); // Считываем файл до конца
                return JsonConvert.DeserializeObject<ObservableCollection<ToDoModel>>(fileText);//Десериализуем и записываем в список
            } 
        }
        /// <summary>
        /// Сохраняет данные на жесткий диск
        /// </summary>
        /// <param name="toDoDataList">Список задач с объектами типа ToDoModel</param>
        public void SaveData(object toDoDataList)
        {
            ///Поток для записи в файл и сериализации
            using(StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(toDoDataList);
                writer.Write(output);
            }
        }
    }
}
