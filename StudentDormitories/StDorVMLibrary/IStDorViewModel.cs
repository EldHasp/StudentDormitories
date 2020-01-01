using StDorVMLibrary.VMClasses;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StDorVMLibrary
{
    /// <summary>Интерфейс ViewModel</summary>
    public interface IStDorViewModel
    {
        /// <summary>Коллекция общежитий</summary>
        ObservableCollection<DormitoryVM> Dormitories { get; }
        /// <summary>Выделеное общежитие</summary>
        DormitoryVM DormitorySelected { get; set; }
        /// <summary>Редактируемое/добавляемое общежитие</summary>
        DormitoryVM DormitoryEdit { get; set; }

        /// <summary>Коллекция комнат выделенного общежития</summary>
        ObservableCollection<RoomVM> Rooms { get; }
        /// <summary>Веделенная комната</summary>
        RoomVM RoomSelected { get; set; }
        /// <summary>Редактируемая/добавляемая комната</summary>
        RoomVM RoomEdit { get; set; }

        /// <summary>В редактируемом/добавляемом общежитии есть изменения</summary>
        bool IsModeDormitoryModify { get;}
        /// <summary>Режим редактирования/добавления общежития</summary>
        bool IsModeDormitoryEdit { get; }
        /// <summary>Режим добавления общежития</summary>
        bool IsModeDormitoryAdd { get; }

        /// <summary>В редактируемой/добавляемой комнате есть изменения</summary>
        bool IsModeRoomModify { get; }
        /// <summary>Режим редактирования/добавления комнаты</summary>
        bool IsModeRoomEdit { get; }
        /// <summary>Режим добавления комнаты</summary>
        bool IsModeRoomAdd { get; }

        /// <summary>Команда добавления общежития</summary>
        ICommand DormitoryAddCommand { get; }
        /// <summary>Команда редактирования общежития</summary>
        ICommand DormitoryEditCommand { get; }
        /// <summary>Команда удаления общежития</summary>
        ICommand DormitoryRemoveCommand { get; }
        /// <summary>Команда сохранения изменений в редактируемом/добавляемом общежитии</summary>
        ICommand DormitorySaveCommand { get; }
        /// <summary>Команда отмены изменений и выхода из режима редактирования/добавления общежития</summary>
        ICommand DormitoryCancelCommand { get; }

        /// <summary>Команда добавления комнаты</summary>
        ICommand RoomAddCommand { get; }
        /// <summary>Команда редактирования комнаты</summary>
        ICommand RoomEditCommand { get; }
        /// <summary>Команда удаления комнаты</summary>
        ICommand RoomRemoveCommand { get; }
        /// <summary>Команда сохранения изменений в редактируемой/добавляемой комнате</summary>
        ICommand RoomSaveCommand { get; }
        /// <summary>Команда отмены изменений и выхода из режима редактирования/добавления комнаты</summary>
        ICommand RoomCancelCommand { get; }
    }
}
