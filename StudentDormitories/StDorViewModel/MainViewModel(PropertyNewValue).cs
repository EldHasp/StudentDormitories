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
        protected virtual async void SetRooms(DormitoryVM dormitory)
        {
            ImmutableHashSet<RoomDTO> rooms = await model.GetRoomsAsync(dormitory.CopyDTO());
            int index = 0;
            foreach (RoomDTO room in rooms)
            {
                if (index < Rooms.Count)
                    ((RoomVM)Rooms[index]).CopyFromDTO(room);
                else
                    Rooms.Add(new RoomVM(room));
                index++;
            }
            for (; index < Rooms.Count; index++)
                Rooms.RemoveAt(index);
            RoomSelected = Rooms.FirstOrDefault();
        }

        /// <summary>Инициализация коллекции Общежитий</summary>
        /// <remarks>Метод должен выполняться в UI потоке</remarks>
        protected virtual async void SetDormitories()
        {
            ImmutableHashSet<DormitoryDTO> dorms = await model.GetDormitoriesAsync();
            int index = 0;
            foreach (DormitoryDTO dorm in dorms)
            {
                if (index < Rooms.Count)
                    ((DormitoryVM)Dormitories[index]).CopyFromDTO(dorm);
                else
                    Dormitories.Add(new DormitoryVM(dorm));
                index++;
            }
            for (; index < Dormitories.Count; index++)
                Dormitories.RemoveAt(index);
            DormitorySelected = Dormitories.FirstOrDefault();
        }
    }
}
