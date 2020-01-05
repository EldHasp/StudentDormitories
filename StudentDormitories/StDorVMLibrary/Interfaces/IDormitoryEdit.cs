namespace StDorVMLibrary.Interfaces
{
    /// <summary>Интерфейс ViewModel</summary>
    public interface IDormitoryEdit
    {
        /// <summary>Редактируемое/добавляемое общежитие</summary>
        IDormitory DormitoryEdit { get; set; }

        /// <summary>В редактируемом/добавляемом общежитии есть изменения</summary>
        bool IsDormitoryModify { get; }
        /// <summary>Режим редактирования/добавления общежития</summary>
        bool IsModeDormitoryEdit { get; }
        /// <summary>Режим добавления общежития</summary>
        bool IsModeDormitoryAdd { get; }
    }
}