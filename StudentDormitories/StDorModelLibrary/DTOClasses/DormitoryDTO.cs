using CommLibrary;

namespace StDorModelLibrary.DTOClasses
{
    /// <summary>Класс для одного Общежития</summary>
    public class DormitoryDTO : BaseIdDTO
    {

        /// <summary>Название общежития</summary>
        public string Title { get; set; }

        /// <summary>Адрес общежития</summary>
        public string Address { get; set; }

        /// <summary>Конструктор задающий значения</summary>
        /// <param name="id">ID экземпляра</param>
        /// <param name="title">Название общежития</param>
        /// <param name="address">Адрес общежития</param>
        public DormitoryDTO(int id, string title, string address)
            : base(id)
        {
            Title = title;
            Address = address;
        }
    }
}
