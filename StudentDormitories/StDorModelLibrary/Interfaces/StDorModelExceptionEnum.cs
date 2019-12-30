namespace StDorModelLibrary.Interfaces
{
    /// <summary>Перечисление возможных ошибок</summary>
    public enum StDorModelExceptionEnum
    {
        /// <summary>Значение по умолчанию для необозначенных исключений</summary>
        Default,
        /// <summary>Такой ID уже имеется</summary>
        AlreadySuchID,
        /// <summary>Такой ID отсутствуют</summary>
        NoSuchID,
        /// <summary>Не совпадают значения</summary>
        DoNotMatch
    }
}
