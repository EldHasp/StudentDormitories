using System;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Тип для представления ошибок</summary>
    public class StDorModelException : Exception
    {
        /// <summary>Свойство со значением ошибки</summary>
        public StDorModelExceptionEnum ValueException { get; } = StDorModelExceptionEnum.Default;

        #region Конструкторы
        public StDorModelException(string message)
            : base(message) { }
        public StDorModelException(StDorModelExceptionEnum valueException)
            => ValueException = valueException;
        public StDorModelException(string message, StDorModelExceptionEnum valueException)
            : base(message)
            => ValueException = valueException;
        public StDorModelException(string message, Exception innerException)
            : base(message, innerException) { }
        public StDorModelException(StDorModelExceptionEnum valueException, Exception innerException)
            : base(null, innerException)
            => ValueException = valueException;
        public StDorModelException(string message, StDorModelExceptionEnum valueException, Exception innerException)
            : base(message, innerException)
            => ValueException = valueException;
        #endregion
    }
}
