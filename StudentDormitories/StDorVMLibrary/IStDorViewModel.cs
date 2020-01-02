using CommLibrary;
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
        /// <summary>Выделенное общежитие</summary>
        DormitoryVM DormitorySelected { get; set; }
        /// <summary>Редактируемое/добавляемое общежитие</summary>
        DormitoryVM DormitoryEdit { get; set; }

        /// <summary>Коллекция комнат выделенного общежития</summary>
        ObservableCollection<RoomVM> Rooms { get; }
        /// <summary>Выделенная комната</summary>
        RoomVM RoomSelected { get; set; }
        /// <summary>Редактируемая/добавляемая комната</summary>
        RoomVM RoomEdit { get; set; }

        /// <summary>В редактируемом/добавляемом общежитии есть изменения</summary>
        bool IsDormitoryModify { get; }
        /// <summary>Режим редактирования/добавления общежития</summary>
        bool IsModeDormitoryEdit { get; }
        /// <summary>Режим добавления общежития</summary>
        bool IsModeDormitoryAdd { get; }

        /// <summary>В редактируемой/добавляемой комнате есть изменения</summary>
        bool IsRoomModify { get; }
        /// <summary>Режим редактирования/добавления комнаты</summary>
        bool IsModeRoomEdit { get; }
        /// <summary>Режим добавления комнаты</summary>
        bool IsModeRoomAdd { get; }

        /// <summary>Все режимы False</summary>
        bool AllFalseIsMode { get; }

        /// <summary>Команда добавления общежития</summary>
        RelayCommand DormitoryAddCommand { get; }
        /// <summary>Команда редактирования общежития</summary>
        RelayCommand DormitoryEditCommand { get; }
        /// <summary>Команда удаления общежития</summary>
        RelayCommand DormitoryRemoveCommand { get; }
        /// <summary>Команда сохранения изменений в редактируемом/добавляемом общежитии</summary>
        RelayCommand DormitorySaveCommand { get; }
        /// <summary>Команда отмены изменений и выхода из режима редактирования/добавления общежития</summary>
        RelayCommand DormitoryCancelCommand { get; }

        /// <summary>Команда добавления комнаты</summary>
        RelayCommand RoomAddCommand { get; }
        /// <summary>Команда редактирования комнаты</summary>
        RelayCommand RoomEditCommand { get; }
        /// <summary>Команда удаления комнаты</summary>
        RelayCommand RoomRemoveCommand { get; }
        /// <summary>Команда сохранения изменений в редактируемой/добавляемой комнате</summary>
        RelayCommand RoomSaveCommand { get; }
        /// <summary>Команда отмены изменений и выхода из режима редактирования/добавления комнаты</summary>
        RelayCommand RoomCancelCommand { get; }
    }
}