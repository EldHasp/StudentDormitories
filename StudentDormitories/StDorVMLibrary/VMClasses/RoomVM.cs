using CommLibrary;
using StDorModelLibrary.DTOClasses;
using StDorVMLibrary.Interfaces;

namespace StDorVMLibrary.VMClasses
{
    /// <summary>Класс VM для комнат работающий с DTO типом RoomDTO</summary>
    public class RoomVM : BaseIdVM<RoomDTO>, ICopy<IRoom>,  IEquatableValues<IRoom>, IRoom
    {
        /// <summary>Приватное поля для хранения значения свойства</summary>
        private int _dormitoryID;

        public int DormitoryID { get => _dormitoryID; set => SetProperty(ref _dormitoryID, value); }

        /// <summary>Приватное поля для хранения значения свойства</summary>
        private int _number;

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
        public RoomVM(IRoom other) => CopyFrom(other);

        public override RoomDTO CopyDTO()
            => new RoomDTO(ID, DormitoryID, Number);

        public override void CopyFromDTO(RoomDTO dto)
        {
            ID = dto.ID;
            DormitoryID = dto.DormitoryID;
            Number = dto.Number;
        }

        public IRoom Copy() => (IRoom)MemberwiseClone();

        public void CopyFrom(IRoom other)
        {
            ID = other.ID;
            DormitoryID = other.DormitoryID;
            Number = other.Number;
        }

        public void CopyTo(IRoom other)
        {
            other.ID = ID;
            other.DormitoryID = DormitoryID;
            other.Number = Number;
        }

        public bool EqualValues(IRoom other)
            => other.ID == ID
            && other.DormitoryID == DormitoryID
            && other.Number == Number;

    }
}
