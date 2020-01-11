using CommLibrary;
using StDorModelLibrary.DTOClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteModel
{
    /// <summary>Класс для представления Комнаты из БД</summary>
    [Table("Rooms")]
    public class RoomBD : BaseIdDB<RoomDTO>, IEquatableValues<RoomBD>
    {
        /// <summary>ID Общежития - Внешний ключ</summary>
        [Required]
        [Column("DormitoryID")]
        [ConcurrencyCheck]
        [Index]
        [ForeignKey("Dormitory")]
        public int DormitoryID { get; set; }

        /// <summary>Номер комнаты</summary>
        [Required]
        [Column("Number")]
        [ConcurrencyCheck]
        public int Number { get; set; }

        /// <summary>Связанное общежитие - Свойство навигации</summary>
        [ForeignKey("DormitoryID")]
        public DormitoryBD Dormitory { get; set; }

        public override RoomDTO CopyDTO() => new RoomDTO(ID, DormitoryID, Number);

        public override void CopyFromDTO(RoomDTO dto)
        {
            ID = dto.ID;
            DormitoryID = dto.DormitoryID;
            Number = dto.Number;
        }

        public override bool EqualValues(RoomDTO dto)
            => ID == dto.ID
            && DormitoryID == dto.DormitoryID
            && Number == dto.Number;

        public bool EqualValues(RoomBD other)
            => ID == other.ID
            && DormitoryID == other.DormitoryID
            && Number == other.Number;

        /// <summary>Безпараметрический конструктор</summary>
        public RoomBD() { }
        /// <summary>Конструктор с передачей значений</summary>
        /// <param name="id">Значение ID</param>
        /// <param name="dormitoryID">Связанное общежитие</param>
        /// <param name="number">Номер комнаты</param>
        public RoomBD(int id, int dormitoryID, int number)
        : base(id)
        {
            DormitoryID = dormitoryID;
            Number = number;
        }
        /// <summary>Конструктор с передачей DTO типа</summary>
        /// <param name="dto">Экземпляр DTO типа</param>
        public RoomBD(RoomDTO dto) : this(dto.ID, dto.DormitoryID, dto.Number) { }
    }
}
