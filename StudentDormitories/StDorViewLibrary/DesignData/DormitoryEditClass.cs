using CommLibrary;
using StDorVMLibrary.Interfaces;

namespace StDorViewLibrary.DesignData
{
    public class DormitoryEditClass : OnPropertyChangedClass ,IDormitoryEdit
    {
        private IDormitory _dormitoryEdit;
        private bool _isDormitoryModify;
        private bool _isModeDormitoryEdit;
        private bool _isModeDormitoryAdd;
        public IDormitory DormitoryEdit { get => _dormitoryEdit; set => SetProperty(ref _dormitoryEdit, value); }
        public bool IsDormitoryModify { get=> _isDormitoryModify; set => SetProperty(ref _isDormitoryModify, value); }
        public bool IsModeDormitoryEdit { get=> _isModeDormitoryEdit; set => SetProperty(ref _isModeDormitoryEdit, value); }
        public bool IsModeDormitoryAdd { get=> _isModeDormitoryAdd; set => SetProperty(ref _isModeDormitoryAdd, value); }
    }
}
