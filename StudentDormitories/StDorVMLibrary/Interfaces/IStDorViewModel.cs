using System.ComponentModel;

namespace StDorVMLibrary.Interfaces
{
    /// <summary>Интерфейс ViewModel</summary>
    public interface IStDorViewModel : IDormitoryEdit, IDormitoriesVM, IRoomEdit, IRoomsVM, INotifyPropertyChanged
    {
    }
}