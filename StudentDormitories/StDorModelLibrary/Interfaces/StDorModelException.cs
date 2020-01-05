using System;
using System.Runtime.Serialization;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Тип для представления ошибок</summary>
    [Serializable]
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

        public StDorModelException()
        {
        }

        protected StDorModelException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
