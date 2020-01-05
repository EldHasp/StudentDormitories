using CommLibrary;
using System.ComponentModel;

namespace StDorVMLibrary.Interfaces
{
    /// <summary>Интерфейс VM для комнат</summary>
    public interface IRoom : IBaseID
    {
        /// <summary>ID общежития</summary>
        int DormitoryID { get; set; }

        /// <summary>Номер комнаты</summary>
        int Number { get; set; }
    }
}
