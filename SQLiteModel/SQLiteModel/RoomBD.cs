using CommLibrary;
using StDorModelLibrary.DTOClasses;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteModel
{
    /// <summary>Класс для представления Комнаты из БД</summary>
    [Table("Rooms")]
    public class RoomBD : ICopy<RoomDTO>
    {
        /// <summary>Идентификатор</summary>
        [Key]
        [Column("ID")]
        public int ID { get; set; }

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

        public RoomDTO Copy() => new RoomDTO(ID, DormitoryID, Number);

        public void CopyFrom(RoomDTO other)
        {
            ID = other.ID;
            DormitoryID = other.DormitoryID;
            Number = other.Number;
        }

        public void CopyTo(RoomDTO other)
        {
            throw new NotImplementedException();
        }
    }
}
