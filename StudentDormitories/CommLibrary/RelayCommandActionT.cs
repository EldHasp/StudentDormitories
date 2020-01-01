namespace CommLibrary
{
    #region Делегаты для методов WPF команд
    /// <summary>Делегат исполняющего метода с параметром любого типа</summary>
    /// <param name="parameter">Параметр метода типа <typeparamref name="T"/></param>
    public delegate void ExecuteActionHandler<in T>(T parameter);
    /// <summary>Делегат проверяющего метода с параметром любого типа</summary>
    /// <param name="parameter">Параметр метода <typeparamref name="T"/></param>
    public delegate bool CanExecuteActionHandler<in T>(T parameter);
    #endregion

    /// <summary>Класс принимающий в конструкторе делегаты с параметром любого типа</summary>
    public class RelayCommandAction<T> : RelayCommand
    {
        /// <summary>Конструктор с передачей только исполняющего метода</summary>
        /// <param name="execute">Исполняющий метод с одним параметром типа <typeparamref name="T"/></param>
        public RelayCommandAction(ExecuteActionHandler<T> execute)
                : base(p => execute(p is T t ? t : default)) { }

        /// <summary>Конструктор с передачей обоих методов</summary>
        /// <param name="execute">Исполняющий метод с одним параметром типа <typeparamref name="T"/></param>
        /// <param name="canExecute">Проверяющий метод с одним параметром типа <typeparamref name="T"/></param>
        public RelayCommandAction(ExecuteActionHandler<T> execute, CanExecuteActionHandler<T> canExecute)
                : base(p => execute(p is T t ? t : default), canExecute == null ? ((CanExecuteHandler)null) : p => p is T t && canExecute(t)) { }
    }
}
