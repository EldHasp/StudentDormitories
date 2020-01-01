namespace CommLibrary
{
    #region Делегаты для методов WPF команд
    /// <summary>Делегат исполняющего метода без параметров</summary>
    public delegate void ExecuteActionHandler();
    /// <summary>Делегат проверяющего метода без параметров</summary>
    public delegate bool CanExecuteActionHandler();
    #endregion

    /// <summary>Класс принимающий в конструкторе делегаты без параметра</summary>
    public class RelayCommandAction : RelayCommand
    {
        /// <summary>Конструктор с передачей только исполняющего метода</summary>
        /// <param name="execute">Исполняющий безпараметрический метод</param>
        public RelayCommandAction(ExecuteActionHandler execute)
                : base(_ => execute()) { }
        /// <summary>Конструктор с передачей обоих методов</summary>
        /// <param name="execute">Исполняющий безпараметрический метод</param>
        /// <param name="canExecute">Проверяющий безпараметрический метод</param>
        public RelayCommandAction(ExecuteActionHandler execute, CanExecuteActionHandler canExecute)
                : base(_ => execute(), canExecute == null ? (CanExecuteHandler)null : _ => canExecute()) { }
    }
}
