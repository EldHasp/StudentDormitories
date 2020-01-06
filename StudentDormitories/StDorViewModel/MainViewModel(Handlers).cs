using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;
using StDorVMLibrary;
using StDorVMLibrary.VMClasses;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace StDorViewModel
{
    /// <summary>Класс ViewModel для Модели работающей с Комнатами Общежитий</summary>
    public partial class MainViewModel : StDorViewModelDD
    {
        /// <summary>Обработчик события изменения в комнатах</summary>
        /// <param name="sender">Источник события</param>
        /// <param name="action">Действие события</param>
        /// <param name="rooms">Комнаты затронутые событием</param>
        private void Model_ChangedRoomsEvent(object sender, ActionChanged action, ImmutableHashSet<RoomDTO> rooms)
        {
            switch (action)
            {
                case ActionChanged.Add:
                    if (rooms.Any())
                        Task.Factory.StartNew(RoomsAdd, rooms.ToHashSet());
                    break;
                case ActionChanged.Changed:
                    if (rooms.Any())
                        Task.Factory.StartNew(RoomsChanged, rooms.ToHashSet());
                    break;
                case ActionChanged.Remove:
                    if (rooms.Any())
                        Task.Factory.StartNew(RoomsRemove, rooms.ToHashSet());
                    break;
                default:
#if DEBUG
                    ShowMetod($"Какой-то баг {sender}");
#else
                throw new Exception($"Какой-то баг {sender}");
#endif
                    break;
            }
        }

        /// <summary>Обработчик события изменения в общежитиях</summary>
        /// <param name="sender">Источник события</param>
        /// <param name="action">Действие события</param>
        /// <param name="dormitories">Общежития затронутые событием</param>
        private void Model_ChangedDormitoriesEvent(object sender, ActionChanged action, ImmutableHashSet<DormitoryDTO> dormitories)
        {
            switch (action)
            {
                case ActionChanged.Add:
                    if (dormitories.Any())
                        Task.Factory.StartNew(DormitoriesAdd, dormitories.ToHashSet());
                    break;
                case ActionChanged.Changed:
                    if (dormitories.Any())
                        Task.Factory.StartNew(DormitoriesChanged, dormitories.ToHashSet());
                    break;
                case ActionChanged.Remove:
                    if (dormitories.Any())
                        Task.Factory.StartNew(DormitoriesRemove, dormitories.ToHashSet());
                    break;
                default:
#if DEBUG
                    ShowMetod($"Какой-то баг {sender}");
#else
                throw new Exception($"Какой-то баг {sender}");
#endif
                    break;
            }
        }

        /// <summary>Добавление Комнат</summary>
        /// <param name="state">Добавляемые Комнаты</param>
        private void RoomsAdd(object state)
        {
            /// Получение коллекции из параметра
            HashSet<RoomDTO> rooms = (HashSet<RoomDTO>)state;

            /// Цикл по повтору запросов
            for (int i = 0; i < CountRepeatRequests; i++)
            {
                /// Очистка коллекции от комнат не из выделенного общежития
                rooms.RemoveWhere(r => r.DormitoryID != DormitorySelected?.ID);

                /// Создание коллекции добавляемых Комнат
                List<RoomVM> list = new List<RoomVM>(rooms.Count);

                /// Цикл по полученной коллекции
                foreach (var room in rooms.ToArray())
                {
                    /// Если в имеющейся коллекции нет комнаты с таким ID
                    if (Dormitories.All(r => r.ID != room.ID))
                    {
                        /// Создание новой Комнаты для добавления в коллекцию
                        list.Add(new RoomVM(room));
                        /// Удаление созданной из полученной коллекции
                        rooms.Remove(room);
                    }
                }

                /// Если в добавляемой коллекции есть элементы
                if (list.Count > 0)
                    /// Вызов метода добавления в коллекцию в потоке UI
                    dispatcher.BeginInvoke((Action<IEnumerable<RoomVM>>)RoomsAddUI, list);

                /// Если полученная коллекция пустая
                if (rooms.Count < 1)
                    /// Выход из цикла
                    break;

                /// Ожидание перед следующим циклом
                Thread.Sleep(TimeOut);
            }
        }

        /// <summary>Метод добавляющий Комнаты в коллекцию  для представления</summary>
        /// <param name="rooms">Добавляемые Комнаты</param>
        /// <remarks>Метод должен выполняться в UI потоке</remarks>
        private void RoomsAddUI(IEnumerable<RoomVM> rooms)
        {
            foreach (var room in rooms.Where(r => r.DormitoryID == DormitorySelected?.ID))
                Rooms.Add(room);
        }

        /// <summary>Изменение Комнат</summary>
        /// <param name="state">Изменяемые Комнаты</param>
        private void RoomsChanged(object state)
        {
            /// Получение коллекции из параметра
            HashSet<RoomDTO> rooms = (HashSet<RoomDTO>)state;

            /// Цикл по повтору запросов
            for (int i = 0; i < CountRepeatRequests; i++)
            {
                /// Очистка коллекции от комнат не из выделенного общежития
                rooms.RemoveWhere(r => r.DormitoryID != DormitorySelected?.ID);

                /// Создание коллекции изменяемых Комнат
                Dictionary<RoomDTO, RoomVM> list = new Dictionary<RoomDTO, RoomVM>(rooms.Count);

                /// Цикл по полученной коллекции
                foreach (var room in rooms.ToArray())
                {
                    /// Если в имеющейся коллекции есть Комната с таким ID
                    RoomVM rvm = (RoomVM)Rooms.FirstOrDefault(r => r.ID == room.ID);
                    if (rvm != null)
                    {
                        /// Создание новой пары Данные и Комната для изменения в коллекции
                        list.Add(room, rvm);
                        /// Удаление Комнаты из полученной коллекции
                        rooms.Remove(room);
                    }
                }

                /// Если в добавляемой коллекции есть элементы
                if (list.Count > 0)
                    /// Вызов метода добавления в коллекцию в потоке UI
                    dispatcher.BeginInvoke((Action<Dictionary<RoomDTO, RoomVM>>)RoomsChangedUI, list);

                /// Если полученная коллекция пустая
                if (rooms.Count < 1)
                    /// Выход из цикла
                    break;

                /// Ожидание перед следующим циклом
                Thread.Sleep(TimeOut);
            }
        }

        /// <summary>Метод изменяющий Комнаты в коллекции  для представления</summary>
        /// <param name="rooms">DTO тип с новыми данными и Комната</param>
        /// <remarks>Метод должен выполняться в UI потоке</remarks>
        private void RoomsChangedUI(Dictionary<RoomDTO, RoomVM> rooms)
        {
            foreach (var room in rooms)
                room.Value.CopyFromDTO(room.Key);
        }

        /// <summary>Удаление Комнат</summary>
        /// <param name="state">Удаляемые Комнаты</param>
        private void RoomsRemove(object state)
        {
            /// Получение коллекции из параметра
            HashSet<RoomDTO> rooms = (HashSet<RoomDTO>)state;

            /// Цикл по повтору запросов
            for (int i = 0; i < CountRepeatRequests; i++)
            {
                /// Очистка коллекции от комнат не из выделенного общежития
                rooms.RemoveWhere(r => r.DormitoryID != DormitorySelected?.ID);

                /// Создание коллекции удаляемых Комнат
                List<RoomVM> list = new List<RoomVM>(rooms.Count);

                /// Цикл по полученной коллекции
                foreach (var room in rooms.ToArray())
                {
                    /// Если в имеющейся коллекции есть комната с таким ID
                    RoomVM rvm = (RoomVM)Rooms.FirstOrDefault(r => r.ID == room.ID);
                    if (rvm != null)
                    {
                        /// Проверка на идентичность данных
                        if (!rvm.EqualValues(room))
                            throw new StDorModelException($"Данные комнаты с ID={room.ID} не совпадают.", StDorModelExceptionEnum.DoNotMatch);

                        /// Добавление Комнаты для удаления из коллекции
                        list.Add(rvm);
                        /// Удаление Комнаты из полученной коллекции
                        rooms.Remove(room);
                    }
                }

                /// Если в добавляемой коллекции есть элементы
                if (list.Count > 0)
                    /// Вызов метода добавления в коллекцию в потоке UI
                    dispatcher.BeginInvoke((Action<List<RoomVM>>)RoomsRemoveUI, list);

                /// Если полученная коллекция пустая
                if (rooms.Count < 1)
                    /// Выход из цикла
                    break;

                /// Ожидание перед следующим циклом
                Thread.Sleep(TimeOut);
            }
        }

        /// <summary>Метод удаляющий Комнаты в коллекции  для представления</summary>
        /// <param name="rooms">Удаляемые Комнаты</param>
        /// <remarks>Метод должен выполняться в UI потоке</remarks>
        private void RoomsRemoveUI(List<RoomVM> rooms)
        {
            foreach (var room in rooms)
                Rooms.Remove(room);
        }

        /// <summary>Добавление Общежитий</summary>
        /// <param name="state">Добавляемые Общежития</param>
        private void DormitoriesAdd(object state)
        {
            /// Получение коллекции из параметра
            HashSet<DormitoryDTO> dormitories = (HashSet<DormitoryDTO>)state;

            /// Цикл по повтору запросов
            for (int i = 0; i < CountRepeatRequests; i++)
            {
                /// Создание коллекции добавляемых Общежитий
                List<DormitoryVM> list = new List<DormitoryVM>(dormitories.Count);

                /// Цикл по полученной коллекции
                foreach (var dorm in dormitories.ToArray())
                {
                    /// Если в имеющейся коллекции нет общежития с таким ID
                    if (Dormitories.All(d => d.ID != dorm.ID))
                    {
                        /// Создание нового Общежития для добавления в коллекцию
                        list.Add(new DormitoryVM(dorm));
                        /// Удаление созданного из полученной коллекции
                        dormitories.Remove(dorm);
                    }
                }

                /// Если в добавляемой коллекции есть элементы
                if (list.Count > 0)
                    /// Вызов метода добавления в коллекцию в потоке UI
                    dispatcher.BeginInvoke((Action<IEnumerable<DormitoryVM>>)DormitoriesAddUI, list);

                /// Если полученная коллекция пустая
                if (dormitories.Count < 1)
                    /// Выход из цикла
                    break;

                /// Ожидание перед следующим циклом
                Thread.Sleep(TimeOut);
            }
        }
        /// <summary>Метод добавляющий Общежития в коллекцию  для представления</summary>
        /// <param name="dormitories">Добавляемые Общежития</param>
        /// <remarks>Метод должен выполняться в UI потоке</remarks>
        private void DormitoriesAddUI(IEnumerable<DormitoryVM> dormitories)
        {
            foreach (var dorm in dormitories)
                Dormitories.Add(dorm);
        }

        /// <summary>Изменение Общежитий</summary>
        /// <param name="state">Изменяемые Общежития</param>
        private void DormitoriesChanged(object state)
        {
            /// Получение коллекции из параметра
            HashSet<DormitoryDTO> dormitories = (HashSet<DormitoryDTO>)state;

            /// Цикл по повтору запросов
            for (int i = 0; i < CountRepeatRequests; i++)
            {
                /// Создание коллекции изменяемых Общежитий
                Dictionary<DormitoryDTO, DormitoryVM> list = new Dictionary<DormitoryDTO, DormitoryVM>(dormitories.Count);

                /// Цикл по полученной коллекции
                foreach (var dorm in dormitories.ToArray())
                {
                    /// Если в имеющейся коллекции есть Общежитие с таким ID
                    DormitoryVM drm = (DormitoryVM)Dormitories.FirstOrDefault(d => d.ID == dorm.ID);
                    if (drm != null)
                    {
                        /// Создание новой пары Данные и Комната для изменения в коллекции
                        list.Add(dorm, drm);
                        /// Удаление Общежития из полученной коллекции
                        dormitories.Remove(dorm);
                    }
                }

                /// Если в добавляемой коллекции есть элементы
                if (list.Count > 0)
                    /// Вызов метода добавления в коллекцию в потоке UI
                    dispatcher.BeginInvoke((Action<Dictionary<DormitoryDTO, DormitoryVM>>)DormitoriesChangedUI, list);

                /// Если полученная коллекция пустая
                if (dormitories.Count < 1)
                    /// Выход из цикла
                    break;

                /// Ожидание перед следующим циклом
                Thread.Sleep(TimeOut);
            }

        }

        /// <summary>Метод изменяющий Общежития в коллекции  для представления</summary>
        /// <param name="dormitories">DTO тип с новыми данными и Общежитие</param>
        /// <remarks>Метод должен выполняться в UI потоке</remarks>
        private void DormitoriesChangedUI(Dictionary<DormitoryDTO, DormitoryVM> dormitories)
        {
            foreach (var dormitory in dormitories)
                dormitory.Value.CopyFromDTO(dormitory.Key);
        }

        /// <summary>Удаление Общежитий</summary>
        /// <param name="state">Удаляемые Общежития</param>
        private void DormitoriesRemove(object state)
        {
            /// Получение коллекции из параметра
            HashSet<DormitoryDTO> dormitories = (HashSet<DormitoryDTO>)state;

            /// Цикл по повтору запросов
            for (int i = 0; i < CountRepeatRequests; i++)
            {

                /// Создание коллекции удаляемых Общежитий
                List<DormitoryVM> list = new List<DormitoryVM>(dormitories.Count);

                /// Цикл по полученной коллекции
                foreach (var dormitory in dormitories.ToArray())
                {
                    /// Если в имеющейся коллекции есть общежитие с таким ID
                    DormitoryVM dorm = (DormitoryVM)Rooms.FirstOrDefault(d => d.ID == dormitory.ID);
                    if (dorm != null)
                    {
                        /// Проверка на идентичность данных
                        if (!dorm.EqualValues(dormitory))
                            throw new StDorModelException($"Данные общежития с ID={dormitory.ID} не совпадают.", StDorModelExceptionEnum.DoNotMatch);

                        /// Добавление Общежития для удаления из коллекции
                        list.Add(dorm);
                        /// Удаление Общежития из полученной коллекции
                        dormitories.Remove(dormitory);
                    }
                }

                /// Если в добавляемой коллекции есть элементы
                if (list.Count > 0)
                    /// Вызов метода добавления в коллекцию в потоке UI
                    dispatcher.BeginInvoke((Action<List<DormitoryVM>>)DormitoriesRemoveUI, list);

                /// Если полученная коллекция пустая
                if (dormitories.Count < 1)
                    /// Выход из цикла
                    break;

                /// Ожидание перед следующим циклом
                Thread.Sleep(TimeOut);
            }
        }

        /// <summary>Метод удаляющий Общежития в коллекции  для представления</summary>
        /// <param name="dormitories">Удаляемые Общежития</param>
        /// <remarks>Метод должен выполняться в UI потоке</remarks>
        private void DormitoriesRemoveUI(List<DormitoryVM> dormitories)
        {
            foreach (var dorm in dormitories)
                Dormitories.Remove(dorm);
        }

    }
}
