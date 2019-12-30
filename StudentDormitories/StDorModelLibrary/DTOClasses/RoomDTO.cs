using CommLibrary;

namespace StDorModelLibrary.DTOClasses
{
    /// <summary>Класс для одной Комнаты</summary>
    public class RoomDTO : BaseIdDTO
    {
        /// <summary>ID общежития</summary>
        public int DormitoryID { get; set; }

        /// <summary>Номер комнаты</summary>
        public int Number { get; set; }

        /// <summary>Конструктор задающий значения свойствам</summary>
        /// <param name="id">ID экземпляра Комнаты</param>
        /// <param name="dormitoryID">ID общежития</param>
        /// <param name="number">Номер комнаты</param>
        public RoomDTO(int id, int dormitoryID, int number)
            : base(id)
        {
            DormitoryID = dormitoryID;
            Number = number;
        }
    }
}
