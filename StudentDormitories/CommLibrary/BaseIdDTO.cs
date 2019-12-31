using System;
using System.Collections.Generic;

namespace CommLibrary
{
    /// <summary>Базовый класс для DTO типов с уникальным и неизменяемым ID</summary>
    public class BaseIdDTO: IEquatable<BaseIdDTO>, IEqualityComparer<BaseIdDTO>
    {
        /// <summary>Идентификатор экземпляра</summary>
        public int ID { get; }

        /// <summary>Конструктор задающий ID</summary>
        /// <param name="id">ID экземпляра</param>
        public BaseIdDTO(int id) => ID = id;

        #region Методы реализующие интерфейсы 
        public bool Equals(BaseIdDTO other) => ID == other.ID;
        public override bool Equals(object obj) => obj is BaseIdDTO other && Equals(other);

        public bool Equals(BaseIdDTO x, BaseIdDTO y) => x.Equals(y);

        public override int GetHashCode() => ID.GetHashCode();

        public int GetHashCode(BaseIdDTO obj) => obj.GetHashCode();
        #endregion
    }
}
