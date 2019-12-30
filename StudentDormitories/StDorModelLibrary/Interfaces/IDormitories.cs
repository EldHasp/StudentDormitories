using StDorModelLibrary.DTOClasses;
using System;
using System.Collections.Generic;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Интерфейс Модели для работы с общежитиями</summary>
    public interface IDormitories
    {
        /// <summary>Возвращает все общежития</summary>
        /// <returns>Множество общежитий</returns>
        HashSet<DormitoryDTO> GetDormitories();

        /// <summary>Удаляет заданное общежитие</summary>
        /// <param name="dormitory">Общежитие которое надо удалить</param>
        /// <exception cref="StDorModelExceptionEnum">Возникает когда нет общежития с таким ID или когда его данные отличны</exception>
        void RemoveDormitoryAsync(DormitoryDTO dormitory);

        /// <summary>Добавляет заданное общежитие</summary>
        /// <param name="dormitory">Общежитие которое надо добавить</param>
        /// <remarks>dormitory.ID игнорируется</remarks>
        void AddDormitoryAsync(DormitoryDTO dormitory);

        /// <summary>Изменяет заданное общежитие</summary>
        /// <param name="dormitory">Новые данные для общежития с заданным ID</param>
        /// <exception cref="StDorModelExceptionEnum">Возникает когда нет общежития с таким ID</exception>
        void ChangeDormitoryAsync(DormitoryDTO dormitory);

        /// <summary>Событие о любых изменениях в коллекции общежитий</summary>
        event ChangedDormitoriesHandler ChangedDormitoriesEvent;

    }
}
