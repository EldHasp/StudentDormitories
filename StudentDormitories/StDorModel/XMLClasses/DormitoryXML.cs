using CommLibrary;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace StDorModel.XMLClasses
{
    /// <summary>Класс для десериализации из XML одного Обшежития</summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DormitoryXML : BaseId
    {

        /// <summary>Название общежития</summary>
        [XmlAttribute()]
        public string Title { get; set; }

        /// <summary>Адрес общежития</summary>
        [XmlAttribute()]
        public string Address { get; set; }
    }
}
