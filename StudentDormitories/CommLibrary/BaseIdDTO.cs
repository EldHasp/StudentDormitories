using System;
using System.Collections.Generic;

namespace CommLibrary
{
    /// <summary>Базовый класс для DTO типов с уникальным и неизменяемым ID</summary>
    public class BaseIdDTO: IEquatable<BaseId>, IEqualityComparer<BaseId>
    {
        /// <summary>Идентификатор экземпляра</summary>
        public int ID { get; }

        /// <summary>Конструтор задающий ID</summary>
        /// <param name="id">ID экземпляра</param>
        public BaseIdDTO(int id) => ID = id;

        #region Методы реализующие интерфейсы 
        public bool Equals(BaseId other) => ID == other.ID;
        public override bool Equals(object obj) => obj is BaseId other && Equals(other);

        public bool Equals(BaseId x, BaseId y) => x.Equals(y);

        public override int GetHashCode() => ID.GetHashCode();

        public int GetHashCode(BaseId obj) => obj.GetHashCode();
        #endregion
    }
}
