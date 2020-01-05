using CommLibrary;
using System.ComponentModel;

namespace StDorVMLibrary.Interfaces
{
    /// <summary>Интерфейс VM для общежитий</summary>
    public interface IDormitory : IBaseID
    {
        /// <summary>Название общежития</summary>
         string Title { get; set; }

        /// <summary>Адрес общежития</summary>
         string Address { get; set; }
    }
}
