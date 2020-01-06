using StDorModelLibrary.Interfaces;
using StDorVMLibrary;
using System.Windows.Threading;

namespace StDorViewModel
{
    /// <summary>Класс ViewModel для Модели работающей с Комнатами Общежитий</summary>
    public partial class MainViewModel : StDorViewModelDD
    {
        /// <summary>Диспетчер UI потока</summary>
        private readonly Dispatcher dispatcher;
        /// <summary>Модель</summary>
        private readonly IStDorModel model;

        /// <summary>Время ожидания между запросами в миллисекундах</summary>
        public int TimeOut { get; private set; } = 100;
        /// <summary>Количество повторов запросов</summary>
        public int CountRepeatRequests { get; private set; } = 10;

        /// <summary>Установка нового времени ожидания</summary>
        /// <param name="timeOut">Время ожидания между запросами в миллисекундах</param>
        /// <remarks>Если значение не в диапазоне 25...1000, то устанавливается по границам диапазона</remarks>
        public void SetTimeOut(int timeOut)
            => TimeOut =
            timeOut < 25
            ? 25
            : timeOut > 1000
                ? 1000
                : timeOut;

        /// <summary>Установка нового количество повторов</summary>
        /// <param name="countRepeatRequests">Количество повторов запросов</param>
        /// <remarks>Если значение не в диапазоне 2...100, то устанавливается по границам диапазона</remarks>
        public void SetCountRepeatRequests(int countRepeatRequests)
            => CountRepeatRequests =
            countRepeatRequests < 2
            ? 2
            : countRepeatRequests > 100
                ? 100
                : countRepeatRequests;

        /// <summary>Конструктор</summary>
        /// <param name="dispatcher">Диспетчер UI потока</param>
        /// <param name="model">Модель</param>
        public MainViewModel(Dispatcher dispatcher, IStDorModel model)
        {
            /// Сохранение ссылок
            this.dispatcher = dispatcher;
            this.model = model;

            /// Подсоединение обработчиков событий
            model.ChangedDormitoriesEvent += Model_ChangedDormitoriesEvent;
            model.ChangedRoomsEvent += Model_ChangedRoomsEvent;

        }
    }
}
