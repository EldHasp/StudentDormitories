using StDorModelLibrary.DTOClasses;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Интерфейс Модели для работы с комнатами</summary>
    public interface IRooms
    {
        /// <summary>Возвращает все комнаты всех общежитий</summary>
        /// <returns>Множество комнат</returns>
        Task<ImmutableHashSet<RoomDTO>> GetRoomsAsync();

        /// <summary>Возвращает все комнаты заданного общежития</summary>
        /// <returns>Множество комнат</returns>
        /// <exception cref="StDorModelException">Возникает когда нет общежития с таким ID или когда его данные отличны</exception>
        Task<ImmutableHashSet<RoomDTO>> GetRoomsAsync(DormitoryDTO dormitory);

        /// <summary>Удаляет заданную комнату</summary>
        /// <param name="room"></param>
        Task RemoveRoomAsync(RoomDTO room);

        /// <summary>Добавляет заданную комнату</summary>
        /// <param name="room">Комната которую надо добавить</param>
        /// <remarks>room.ID игнорируется</remarks>
        Task AddRoomAsync(RoomDTO room);

        /// <summary>Изменяет заданную комнату</summary>
        /// <param name="room">Новые данные для комнаты с заданным ID</param>
        /// <exception cref="StDorModelException">Возникает когда нет комнаты с таким ID</exception>
        Task ChangeRoomAsync(RoomDTO room);

        /// <summary>Событие о любых изменениях в коллекции комнат</summary>
        event ChangedRoomsHandler ChangedRoomsEvent;
    }
}
