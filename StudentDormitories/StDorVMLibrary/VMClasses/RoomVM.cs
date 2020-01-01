using CommLibrary;
using StDorModelLibrary.DTOClasses;

namespace StDorVMLibrary.VMClasses
{
    /// <summary>Класс VM для комнат работающий с DTO типом RoomDTO</summary>
    public class RoomVM : BaseIdVM<RoomDTO>, ICopy<RoomVM>, IEquatableValues<RoomVM>
    {
        /// <summary>Приватное поля для хранения значения свойства</summary>
        private int _dormitoryID;
        /// <summary>ID общежития</summary>
        public int DormitoryID { get => _dormitoryID; set => SetProperty(ref _dormitoryID, value); }

        /// <summary>Приватное поля для хранения значения свойства</summary>
        private int _number;
        /// <summary>Номер комнаты</summary>
        public int Number { get => _number; set => SetProperty(ref _number, value); }

        /// <summary>Безпараметрический конструктор</summary>
        public RoomVM() { }
        /// <summary>Конструктор с передачей ID</summary>
        /// <param name="id">Значение ID</param>
        public RoomVM(int id) : base(id) { }
        /// <summary>Конструктор с передачей DTO типа</summary>
        /// <param name="other">Экземпляр DTO типа</param>
        public RoomVM(RoomDTO dto) : base(dto) => CopyFromDTO(dto);
        /// <summary>Конструктор с передачей RoomVMVM</summary>
        /// <param name="other">Экземпляр RoomVMVM</param>
        public RoomVM(RoomVM other) => CopyFrom(other);

        public override RoomDTO CopyDTO()
            => new RoomDTO(ID, DormitoryID, Number);

        public override void CopyFromDTO(RoomDTO dto)
        {
            ID = dto.ID;
            DormitoryID = dto.DormitoryID;
            Number = dto.Number;
        }

        public RoomVM Copy() => (RoomVM)MemberwiseClone();

        public void CopyFrom(RoomVM other)
        {
            ID = other.ID;
            DormitoryID = other.DormitoryID;
            Number = other.Number;
        }

        public void CopyTo(RoomVM other)
        {
            other.ID = ID;
            other.DormitoryID = DormitoryID;
            other.Number = Number;
        }

        public bool EqualValues(RoomVM other)
            => other.ID == ID
            && other.DormitoryID == DormitoryID
            && other.Number == Number;

    }
}
