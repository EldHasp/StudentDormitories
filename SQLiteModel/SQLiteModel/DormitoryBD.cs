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
    public class DormitoryBD : BaseIdDB<DormitoryDTO>, IEquatableValues<DormitoryBD>
    {
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

        public override DormitoryDTO CopyDTO() => new DormitoryDTO(ID, Title, Address);

        public override void CopyFromDTO(DormitoryDTO dto)
        {
            ID = dto.ID;
            Title = dto.Title;
            Address = dto.Address;
        }

        public bool EqualValues(DormitoryBD other)
         => ID == other.ID
         && Title == other.Title
         && Address == other.Address;

        public override bool EqualValues(DormitoryDTO dto)
         => ID == dto.ID
         && Title == dto.Title
         && Address == dto.Address;


        /// <summary>Безпараметрический конструктор</summary>
        public DormitoryBD() { }
        /// <summary>Конструктор с передачей значений</summary>
        /// <param name="id">Значение ID</param>
        /// <param name="title">Название</param>
        /// <param name="address">Адрес</param>
        public DormitoryBD(int id, string title, string address)
            : base(id)
        {
            Title = title;
            Address = address;
        }
        /// <summary>Конструктор с передачей DTO типа</summary>
        /// <param name="dto">Экземпляр DTO типа</param>
        public DormitoryBD(DormitoryDTO dto) : this(dto.ID, dto.Title, dto.Address) { }
    }
}
