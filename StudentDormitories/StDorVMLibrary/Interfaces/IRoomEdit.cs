using CommLibrary;
using StDorVMLibrary.VMClasses;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StDorVMLibrary.Interfaces
{
    /// <summary>Интерфейс ViewModel</summary>
    public interface IRoomEdit
    {
        /// <summary>Коллекция общежитий</summary>
        ObservableCollection<IDormitory> Dormitories { get; }

        /// <summary>Редактируемая/добавляемая комната</summary>
        IRoom RoomEdit { get; set; }

        /// <summary>В редактируемой/добавляемой комнате есть изменения</summary>
        bool IsRoomModify { get; }
        /// <summary>Режим редактирования/добавления комнаты</summary>
        bool IsModeRoomEdit { get; }
        /// <summary>Режим добавления комнаты</summary>
        bool IsModeRoomAdd { get; }
    }
}