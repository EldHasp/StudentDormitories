﻿using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace StDorModelLibrary
{
    /// <summary>Абстрактный базовый класс Модели</summary>
    public abstract class StDorModelBase : IStDorModel
    {

        public bool IsDisposable { get; protected set; } = true;
        public bool IsLoaded { get; protected set; } = false;

        /// <summary>Конструктор по умолчанию. Устанавливает IsDisposable = <see langword="false"/>.</summary>
        protected StDorModelBase() => IsDisposable = false;

        public event ChangedDormitoriesHandler ChangedDormitoriesEvent;
        /// <summary>Вспомогательный метод вызова события после удаления общежития</summary>
        /// <param name="dormitories">Удалённое общежитие</param>
        protected void OnRemoveDormitoriesEvent(ImmutableHashSet<DormitoryDTO> dormitories) => ChangedDormitoriesEvent?.Invoke(this, ActionChanged.Remove, dormitories);
        /// <summary>Вспомогательный метод вызова события после добавления общежития</summary>
        /// <param name="dormitories">Добавленное общежитие</param>
        protected void OnAddDormitoriesEvent(ImmutableHashSet<DormitoryDTO> dormitories) => ChangedDormitoriesEvent?.Invoke(this, ActionChanged.Add, dormitories);
        /// <summary>Вспомогательный метод вызова события после изменения общежития</summary>
        /// <param name="dormitories">Изменённое общежитие</param>
        protected void OnChangedDormitoriesEvent(ImmutableHashSet<DormitoryDTO> dormitories) => ChangedDormitoriesEvent?.Invoke(this, ActionChanged.Changed, dormitories);

        public event ChangedRoomsHandler ChangedRoomsEvent;
        /// <summary>Вспомогательный метод вызова события после удаления комнаты</summary>
        /// <param name="dormitories">Удалённая комната</param>
        protected void OnRemoveRoomsEvent(ImmutableHashSet<RoomDTO> rooms) => ChangedRoomsEvent?.Invoke(this, ActionChanged.Remove, rooms);
        /// <summary>Вспомогательный метод вызова события после добавления комнаты</summary>
        /// <param name="dormitories">Добавленная комната</param>
        protected void OnAddRoomsEvent(ImmutableHashSet<RoomDTO> rooms) => ChangedRoomsEvent?.Invoke(this, ActionChanged.Add, rooms);
        /// <summary>Вспомогательный метод вызова события после изменения комнаты</summary>
        /// <param name="dormitories">Изменённая комната</param>
        protected void OnChangedRoomsEvent(ImmutableHashSet<RoomDTO> rooms) => ChangedRoomsEvent?.Invoke(this, ActionChanged.Changed, rooms);

        public Task AddDormitoryAsync(DormitoryDTO dormitory) => Task.Factory.StartNew(() => AddDormitory(dormitory));
        /// <summary>Добавляет заданное общежитие</summary>
        /// <param name="dormitory">Общежитие которое надо добавить</param>
        /// <remarks>dormitory.ID игнорируется</remarks>
        protected abstract void AddDormitory(DormitoryDTO dormitory);

        public Task AddRoomAsync(RoomDTO room) => Task.Factory.StartNew(() => AddRoom(room));
        /// <summary>Добавляет заданную комнату</summary>
        /// <param name="room">Комната которую надо добавить</param>
        /// <remarks>room.ID игнорируется</remarks>
        protected abstract void AddRoom(RoomDTO room);

        public Task ChangeDormitoryAsync(DormitoryDTO dormitory) => Task.Factory.StartNew(() => ChangeDormitory(dormitory));
        /// <summary>Изменяет заданное общежитие</summary>
        /// <param name="dormitory">Новые данные для общежития с заданным ID</param>
        /// <exception cref="StDorModelException">Возникает когда нет общежития с таким ID</exception>
        protected abstract void ChangeDormitory(DormitoryDTO dormitory);

        public Task ChangeRoomAsync(RoomDTO room) => Task.Factory.StartNew(() => ChangeRoom(room));
        /// <summary>Изменяет заданную комнату</summary>
        /// <param name="room">Новые данные для комнаты с заданным ID</param>
        /// <exception cref="StDorModelException">Возникает когда нет комнаты с таким ID</exception>
        protected abstract void ChangeRoom(RoomDTO room);

        public Task CloseAsync() => Task.Factory.StartNew(Close);
        /// <summary>Закрытие источника данных и освобождение ресурсов</summary>
        protected virtual void Close()
        {
            Dispose();
            Source = null;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        ~StDorModelBase()
        {
            Dispose(false);
        }

        /// <summary>Выполняет определяемые приложением задачи, связанные с удалением, высвобождением
        /// или сбросом неуправляемых ресурсов</summary>
        /// <param name="disposing">Откуда осуществляется вызов метода:
        /// <see langword="true"/> из метода Dispose или <see langword="false"/> из метода завершения</param>
        protected virtual void Dispose(bool disposing) => IsLoaded = !(IsDisposable = true);

        public Task<ImmutableHashSet<DormitoryDTO>> GetDormitoriesAsync() => Task.Factory.StartNew(GetDormitories);
        /// <summary>Возвращает все общежития</summary>
        /// <returns>Множество общежитий</returns>
        protected abstract ImmutableHashSet<DormitoryDTO> GetDormitories();

        public Task<ImmutableHashSet<RoomDTO>> GetRoomsAsync() => Task.Factory.StartNew(GetRooms);
        /// <summary>Возвращает все комнаты всех общежитий</summary>
        /// <returns>Множество комнат</returns>
        protected abstract ImmutableHashSet<RoomDTO> GetRooms();

        public Task<ImmutableHashSet<RoomDTO>> GetRoomsAsync(DormitoryDTO dormitory) => Task.Factory.StartNew(() => GetRooms(dormitory));
        /// <summary>Возвращает все комнаты заданного общежития</summary>
        /// <returns>Множество комнат</returns>
        protected abstract ImmutableHashSet<RoomDTO> GetRooms(DormitoryDTO dormitory);


        public Task LoadAsync(string source) => Task.Factory.StartNew(() => Load(source));
        /// <summary>Загрузка данных</summary>
        /// <param name="source">Источник с данными</param>
        protected virtual void Load(string source)
        {
            IsLoaded = true;
            Source = source;
        }
        public string Source { get; protected set; } = null;


        public Task RemoveDormitoryAsync(DormitoryDTO dormitory) => Task.Factory.StartNew(() => RemoveDormitory(dormitory));
        /// <summary>Удаляет заданное общежитие</summary>
        /// <param name="dormitory">Общежитие которое надо удалить</param>
        /// <exception cref="StDorModelException">Возникает когда нет общежития с таким ID или когда его данные отличны</exception>
        protected abstract void RemoveDormitory(DormitoryDTO dormitory);

        public Task RemoveRoomAsync(RoomDTO room) => Task.Factory.StartNew(() => RemoveRoom(room));
        /// <summary>Удаляет заданную комнату</summary>
        /// <param name="room"></param>
        protected abstract void RemoveRoom(RoomDTO room);
    }
}
