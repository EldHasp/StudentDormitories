﻿using StDorModelLibrary.DTOClasses;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Делегат события изменения Комнат</summary>
    /// <param name="sender">Объект где возникло событие</param>
    /// <param name="action">Какое было изменение</param>
    /// <param name="rooms">Список изменённых Комнат</param>
    public delegate void ChangedRoomsHandler(object sender, ActionChanged action, ImmutableHashSet<RoomDTO> rooms);
}
