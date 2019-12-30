using System;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Тип для представления ошибок</summary>
    public class StDorModelException : Exception
    {
        /// <summary>Свойство со значением ошибки</summary>
        public StDorModelExceptionEnum ValueException { get; }

        #region Конструкторы
        public StDorModelException(string message)
            : base(message) { }
        public StDorModelException(StDorModelExceptionEnum valueException)
            => ValueException = valueException;
        public StDorModelException(string message, StDorModelExceptionEnum valueException)
            : base(message)
            => ValueException = valueException;
        #endregion
    }
}
