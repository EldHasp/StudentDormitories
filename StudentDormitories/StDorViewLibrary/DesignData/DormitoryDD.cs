using CommLibrary;
using StDorVMLibrary.Interfaces;

namespace StDorViewLibrary.DesignData
{
    public class DormitoryDD : OnPropertyChangedClass, IDormitory
    {
        private string _title;
        private string _address;
        private int _id;
        public string Title { get =>_title; set=>SetProperty(ref _title, value); }
        public string Address { get =>_address; set => SetProperty(ref _address, value); }
        public int ID { get =>_id; set => SetProperty(ref _id, value); }
    }
}
