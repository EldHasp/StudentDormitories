using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StDorModel.XMLClases
{

    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class StudentDormitories
    {

        private StudentDormitoriesDormitory[] dormitoriesField;

        private StudentDormitoriesRoom[] roomsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Dormitory", IsNullable = false)]
        public StudentDormitoriesDormitory[] Dormitories
        {
            get
            {
                return this.dormitoriesField;
            }
            set
            {
                this.dormitoriesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Room", IsNullable = false)]
        public StudentDormitoriesRoom[] Rooms
        {
            get
            {
                return this.roomsField;
            }
            set
            {
                this.roomsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class StudentDormitoriesDormitory
    {

        private byte idField;

        private string titleField;

        private string addressField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class StudentDormitoriesRoom
    {

        private byte idField;

        private byte dormitoryIDField;

        private ushort numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte DormitoryID
        {
            get
            {
                return this.dormitoryIDField;
            }
            set
            {
                this.dormitoryIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }


}
