using CommLibrary;
using StDorModelLibrary.DTOClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteModel
{
    /// <summary>Класс для представления Общежития из БД</summary>
    [Table("Dormitories")]
    public class DormitoryBD : ICopy<DormitoryDTO>
    {
        /// <summary>Идентификатор</summary>
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>Название</summary>
        [Required]
        [Column("Title")]
        [ConcurrencyCheck]
        [Index]
        public string Title { get; set; }

        /// <summary>Адрес</summary>
        [Required]
        [Column("Address")]
        [ConcurrencyCheck]
        public string Address { get; set; }

        /// <summary>Коллекция комнат</summary>
        public ICollection<RoomBD> Rooms { get; set; } = new List<RoomBD>();

        public DormitoryDTO Copy() => new DormitoryDTO(ID, Title, Address);

        public void CopyFrom(DormitoryDTO other)
        {
            ID = other.ID;
            Title = other.Title;
            Address = other.Address;
        }

        public void CopyTo(DormitoryDTO other)
        {
            throw new NotImplementedException();
        }
    }
}
