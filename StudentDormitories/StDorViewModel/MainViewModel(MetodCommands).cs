using StDorVMLibrary;
using StDorVMLibrary.VMClasses;

namespace StDorViewModel
{
    /// <summary>Класс ViewModel для Модели работающей с Комнатами Общежитий</summary>
    public partial class MainViewModel : StDorViewModelDD
    {

        protected override void DormitoryRemoveMetod(DormitoryVM dormitory)
        {
            base.DormitoryRemoveMetod(dormitory);
            DormitoryRemoveMetodAsync(dormitory);
        }

        /// <summary>Асинхронный метод удаления Общежития</summary>
        /// <param name="dormitory">Удаляемое Общежитие</param>
        protected virtual async void DormitoryRemoveMetodAsync(DormitoryVM dormitory)
        {
            await model.RemoveDormitoryAsync(dormitory.CopyDTO());
        }

        protected override void DormitorySaveAddMetod(DormitoryVM dormitory)
        {
            base.DormitorySaveAddMetod(dormitory);
            DormitoryAddMetodAsync(dormitory);
        }
        /// <summary>Асинхронный метод добавления Общежития</summary>
        /// <param name="dormitory">Добавляемое Общежитие</param>
        protected virtual async void DormitoryAddMetodAsync(DormitoryVM dormitory)
        {
            await model.AddDormitoryAsync(dormitory.CopyDTO());
        }
        protected override void DormitorySaveChangeMetod(DormitoryVM dormitory)
        {
            DormitoryChangeMetodAsync(dormitory);
            base.DormitorySaveChangeMetod(dormitory);
        }
        /// <summary>Асинхронный метод изменения Общежития</summary>
        /// <param name="dormitory">Новые данные для Общежития</param>
        protected virtual async void DormitoryChangeMetodAsync(DormitoryVM dormitory)
        {
            await model.ChangeDormitoryAsync(dormitory.CopyDTO());
        }

        protected override void RoomRemoveMetod(RoomVM room)
        {
            base.RoomRemoveMetod(room);
            RoomRemoveMetodAsync(room);
        }

        /// <summary>Асинхронный метод удаления Комнаты</summary>
        /// <param name="dormitory">Удаляемая Комната</param>
        protected virtual async void RoomRemoveMetodAsync(RoomVM room)
        {
            await model.RemoveRoomAsync(room.CopyDTO());
        }

        protected override void RoomSaveAddMetod(RoomVM room)
        {
            base.RoomSaveAddMetod(room);
            RoomAddMetodAsync(room);
        }

        /// <summary>Асинхронный метод добавления Комнаты</summary>
        /// <param name="room">Добавляемая Комната</param>
        protected virtual async void RoomAddMetodAsync(RoomVM room)
        {
            await model.AddRoomAsync(room.CopyDTO());
        }

        protected override void RoomSaveChangeMetod(RoomVM room)
        {
            base.RoomSaveChangeMetod(room);
            RoomChangeMetodAsync(room);
        }

        /// <summary>Асинхронный метод изменения Комнаты</summary>
        /// <param name="room">Новые данные для Комнаты</param>
        protected virtual async void RoomChangeMetodAsync(RoomVM room)
        {
            await model.ChangeRoomAsync(room.CopyDTO());
        }
    }
}
