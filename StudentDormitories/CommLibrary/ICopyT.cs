namespace CommLibrary
{
    /// <summary>Поддерживает различные методы копирования</summary>
    /// <typeparam name="T">Тип экземпляра</typeparam>
    public interface ICopy<T>
    {
        /// <summary>Создаёт копию экземпляра в типе экземпляра</summary>
        /// <returns>Новый экземпляр <typeparamref name="T"/> со скопированными значениями</returns>
        T Copy();

        /// <summary>Копирует значения из другого экземпляра</summary>
        /// <param name="other">Другой экземпляр <typeparamref name="T"/></param>
        void CopyFrom(T other);

        /// <summary>Копирует значения в другой экземпляр</summary>
        /// <param name="other">Другой экземпляр <typeparamref name="T"/></param>
        void CopyTo(T other);
    }
}
