namespace CommLibrary
{
    /// <summary>Базовый класс для типов VM с ID и обменивающийся данными с DTO типом</summary>
    /// <typeparam name="DTO">Производный от BaseIdDTO тип</typeparam>
    public abstract class BaseIdVM<DTO> : OnPropertyChangedClass, IEquatableValues<BaseIdVM<DTO>>
        where DTO : BaseIdDTO
    {
        /// <summary>Приватное поля для хранения значения свойства</summary>
        private int _id;

        /// <summary>Идентификатор</summary>
        public int ID { get => _id; set => SetProperty(ref _id, value); }

        /// <summary>Создание экземпляра DTO типа со скопированными значениями</summary>
        /// <returns>Новый экземпляр DTO типа</returns>
        public abstract DTO CopyDTO();

        /// <summary>Копирование значений из DTO типа</summary>
        /// <param name="dto">Экземпляр DTO типа</param>
        public abstract void CopyFromDTO(DTO dto);

        public bool EqualValues(BaseIdVM<DTO> other) => ID == other.ID;

        /// <summary>Безпараметрический конструктор</summary>
        protected BaseIdVM() { }
        /// <summary>Конструктор с передачей ID</summary>
        /// <param name="id">Значение ID</param>
        protected BaseIdVM(int id) => ID = id;
        /// <summary>Конструктор с передачей DTO типа</summary>
        /// <param name="dto">Экземпляр DTO типа</param>
        protected BaseIdVM(DTO dto) => ID = dto.ID;
    }
}
