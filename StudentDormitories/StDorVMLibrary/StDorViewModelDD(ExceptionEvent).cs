using CommLibrary;
using StDorVMLibrary.Interfaces;
using System;
using System.Runtime.CompilerServices;

namespace StDorVMLibrary
{
    public partial class StDorViewModelDD : OnPropertyChangedClass, IStDorViewModel
    {
        public event ExceptionHandler ExceptionEvent;

        /// <summary>Вспомогательный метод для передачи сообщения об ошибке</summary>
        /// <param name="exc">Параметры ошибки</param>
        /// <param name="nameMetod">Метод отправивший сообщение</param>
        public void OnException(Exception exc, [CallerMemberName] string nameMetod = null)
            => ExceptionEvent?.Invoke(this, nameMetod, exc);
    }
}
