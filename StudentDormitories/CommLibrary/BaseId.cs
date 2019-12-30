using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CommLibrary
{
    /// <summary>Базовый класс для типов с уникальным ID</summary>
    [Serializable]
    public class BaseId : IEquatable<BaseId>, IEqualityComparer<BaseId>
    {
        /// <summary>Идентификатор экземпляра</summary>
        [XmlAttribute()]
        public int ID { get; set; }

        #region Методы реализующие интерфейсы 
        public bool Equals(BaseId other) => ID == other.ID;
        public override bool Equals(object obj) => obj is BaseId other && Equals(other);

        public bool Equals(BaseId x, BaseId y) => x.Equals(y);

        public override int GetHashCode()=> ID.GetHashCode();

        public int GetHashCode(BaseId obj) => obj.GetHashCode();
        #endregion
    }
}
