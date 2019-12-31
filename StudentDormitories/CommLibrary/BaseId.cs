using System;
using System.Collections.Generic;
using System.Linq;
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

        public override int GetHashCode() => ID.GetHashCode();

        public int GetHashCode(BaseId obj) => obj.GetHashCode();
        #endregion

        /// <summary>Метод нахождения нового уникального ID для заданного набора</summary>
        /// <param name="set">Набор</param>
        /// <returns>int ID неимеющийся в наборе</returns>
        public static int NewId<T>(HashSet<T> set) where T : BaseId
        {
            BaseId newId = new BaseId() { ID = set.Count };
            while (set.Contains(newId))
                newId.ID++;
            return newId.ID;
        }
    }
}
