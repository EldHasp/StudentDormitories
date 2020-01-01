using CommLibrary;
using StDorModelLibrary.DTOClasses;

namespace StDorVMLibrary.VMClasses
{
    /// <summary>Класс VM для обещитий работающий с DTO типом DormitoryDTO</summary>
    public class DormitoryVM : BaseIdVM<DormitoryDTO>, ICopy<DormitoryVM>, IEquatableValues<DormitoryVM>
    {

        /// <summary>Приватное поля для хранения значения свойства</summary>
        private string _title;
        /// <summary>Название общежития</summary>
        public string Title { get => _title; set => SetProperty(ref _title, value); }

        /// <summary>Приватное поля для хранения значения свойства</summary>
        private string _address;
        /// <summary>Адрес общежития</summary>
        public string Address { get => _address; set => SetProperty(ref _address, value); }

        /// <summary>Безпараметрический конструктор</summary>
        public DormitoryVM() { }
        /// <summary>Конструктор с передачей ID</summary>
        /// <param name="id">Значение ID</param>
        public DormitoryVM(int id) : base(id) { }
        /// <summary>Конструктор с передачей DTO типа</summary>
        /// <param name="other">Экземпляр DTO типа</param>
        public DormitoryVM(DormitoryDTO dto) : base(dto) => CopyFromDTO(dto);
        /// <summary>Конструктор с передачей DormitoryVM</summary>
        /// <param name="other">Экземпляр DormitoryVM</param>
        public DormitoryVM(DormitoryVM other) => CopyFrom(other);

        public override DormitoryDTO CopyDTO()
            => new DormitoryDTO(ID, Title, Address);

        public override void CopyFromDTO(DormitoryDTO dto)
        {
            ID = dto.ID;
            Title = dto.Title;
            Address = dto.Address;
        }

        public DormitoryVM Copy() => (DormitoryVM)MemberwiseClone();

        public void CopyFrom(DormitoryVM other)
        {
            ID = other.ID;
            Title = other.Title;
            Address = other.Address;
        }

        public void CopyTo(DormitoryVM other)
        {
            other.ID = ID;
            other.Title = Title;
            other.Address = Address;
        }

        public bool EqualValues(DormitoryVM other)
            => other.ID == ID
            && other.Title == Title
            && other.Address == Address;
    }
}
