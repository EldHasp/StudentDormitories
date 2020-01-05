using CommLibrary;
using System.Collections.ObjectModel;

namespace StDorVMLibrary.Interfaces
{
    /// <summary>Интерфейс ViewModel</summary>
    public interface IDormitoriesVM : IDormitoryEdit
    {
        /// <summary>Коллекция общежитий</summary>
        ObservableCollection<IDormitory> Dormitories { get; }
        /// <summary>Выделенное общежитие</summary>
        IDormitory DormitorySelected { get; set; }

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
    }
}