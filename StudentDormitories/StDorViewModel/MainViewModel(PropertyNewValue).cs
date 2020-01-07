using StDorModelLibrary.DTOClasses;
using StDorVMLibrary;
using StDorVMLibrary.VMClasses;
using System.Collections.Immutable;
using System.Linq;

namespace StDorViewModel
{
    /// <summary>Класс ViewModel для Модели работающей с Комнатами Общежитий</summary>
    public partial class MainViewModel : StDorViewModelDD
    {
        protected override void PropertyNewValue<T>(ref T fieldProperty, T newValue, string propertyName)
        {
            base.PropertyNewValue(ref fieldProperty, newValue, propertyName);
            if (propertyName == nameof(DormitorySelected))
                SetRooms((DormitoryVM)DormitorySelected);
        }

        /// <summary>Инициализация коллекции Комнат заданного Общежития</summary>
        /// <param name="dormitory">Общежитие</param>
        /// <remarks>Метод должен выполняться в UI потоке</remarks>
        public virtual async void SetRooms(DormitoryVM dormitory)
        {
            if (dormitory == null)
                lock (Rooms)
                    Rooms.Clear();
            else
            {
                ImmutableHashSet<RoomDTO> rooms = await model.GetRoomsAsync(dormitory.CopyDTO());
                lock (Rooms)
                {
                    if (DormitorySelected == dormitory)
                    {
                        int index = 0;
                        foreach (RoomDTO room in rooms)
                        {
                            if (index < Rooms.Count)
                                ((RoomVM)Rooms[index]).CopyFromDTO(room);
                            else
                                Rooms.Add(new RoomVM(room));
                            index++;
                        }
                        for (int i = Rooms.Count - 1; index <= i; i--)
                            Rooms.RemoveAt(index);
                        RoomSelected = Rooms.FirstOrDefault();
                    }
                }
            }
        }

        /// <summary>Инициализация коллекции Общежитий</summary>
        /// <remarks>Метод должен выполняться в UI потоке</remarks>
        public virtual async void SetDormitories()
        {
            ImmutableHashSet<DormitoryDTO> dorms = await model.GetDormitoriesAsync();
            lock (Dormitories)
            {
                int index = 0;
                foreach (DormitoryDTO dorm in dorms)
                {
                    if (index < Dormitories.Count)
                        ((DormitoryVM)Dormitories[index]).CopyFromDTO(dorm);
                    else
                        Dormitories.Add(new DormitoryVM(dorm));
                    index++;
                }
                for (int i = Dormitories.Count - 1; index <= i; i--)
                    Dormitories.RemoveAt(index);
                DormitorySelected = Dormitories.FirstOrDefault();
            }
        }
    }
}
