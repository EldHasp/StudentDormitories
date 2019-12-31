using StDorModelLibrary.DTOClasses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StDorModelLibrary.Interfaces
{
    public interface IStDorModel : IDisposable, IDormitories, IRooms
    {
        /// <summary>Загрузка данных</summary>
        /// <param name="source">Источник с данными</param>
        Task LoadAsync(string source);

        /// <summary>Закрытие источника данных и освобождение ресурсов</summary>
        Task CloseAsync();

        /// <summary>Модель недоступна</summary>
        bool IsDisposable { get; }

        /// <summary>Данные загружены</summary>
        bool IsLoaded { get; }
    }

}
