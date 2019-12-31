using StDorModelLibrary.DTOClasses;
using System.Collections.Immutable;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Делегат события изменения Общежитий</summary>
    /// <param name="sender">Объект где возникло событие</param>
    /// <param name="action">Какое было изменение</param>
    /// <param name="dormitories">Список изменённых Общежитий</param>
    public delegate void ChangedDormitoriesHandler(object sender, ActionChanged action, ImmutableHashSet<DormitoryDTO> dormitories);
}
