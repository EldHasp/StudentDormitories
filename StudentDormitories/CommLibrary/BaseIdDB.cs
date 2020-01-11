using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommLibrary
{
    /// <summary>Базовый класс для типов Entity Framework и обменивающийся данными с DTO типом</summary>
    /// <typeparam name="TDto">Производный от BaseIdDTO тип</typeparam>
    public abstract class BaseIdDB<TDto> :IBaseID, IEquatableValues<TDto>
        where TDto : BaseIdDTO
    {
        /// <summary>Идентификатор экземпляра</summary>
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>Создание экземпляра DTO типа со скопированными значениями</summary>
        /// <returns>Новый экземпляр DTO типа</returns>
        public abstract TDto CopyDTO();

        /// <summary>Копирование значений из DTO типа</summary>
        /// <param name="dto">Экземпляр DTO типа</param>
        public abstract void CopyFromDTO(TDto dto);

        public abstract bool EqualValues(TDto dto);

        /// <summary>Безпараметрический конструктор</summary>
        protected BaseIdDB() { }
        /// <summary>Конструктор с передачей ID</summary>
        /// <param name="id">Значение ID</param>
        protected BaseIdDB(int id) => ID = id;
        /// <summary>Конструктор с передачей DTO типа</summary>
        /// <param name="dto">Экземпляр DTO типа</param>
        protected BaseIdDB(TDto dto) => ID = dto.ID;
    }
}
