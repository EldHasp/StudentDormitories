using CommLibrary;
using StDorVMLibrary.Interfaces;
using StDorVMLibrary.VMClasses;
using System.Collections.ObjectModel;

namespace StDorVMLibrary
{
    public partial class StDorViewModelDD : OnPropertyChangedClass, IStDorViewModel
    {
        public ObservableCollection<IDormitory> Dormitories { get; } = new ObservableCollection<IDormitory>();
        public IDormitory DormitorySelected { get => _dormitorySelected; set => SetProperty(ref _dormitorySelected, value); }
        public IDormitory DormitoryEdit { get => _dormitoryEdit; set => SetProperty(ref _dormitoryEdit, value); }

        public ObservableCollection<IRoom> Rooms { get; } = new ObservableCollection<IRoom>();
        public IRoom RoomSelected { get => _roomSelected; set => SetProperty(ref _roomSelected, value); }
        public IRoom RoomEdit { get => _roomEdit; set => SetProperty(ref _roomEdit, value); }

        public bool IsDormitoryModify
        {
            get => _isModeDormitoryModify;
#if ! DEBUG 
            private
#endif
                set => SetProperty(ref _isModeDormitoryModify, value);
        }
        public bool IsModeDormitoryEdit { get => _isModeDormitoryEdit; 
#if ! DEBUG 
            private 
#endif
                set => SetProperty(ref _isModeDormitoryEdit, value); }
        public bool IsModeDormitoryAdd { get => _isModeDormitoryAdd; 
#if ! DEBUG 
            private 
#endif
                set => SetProperty(ref _isModeDormitoryAdd, value); }

        public bool IsRoomModify { get => _isModeRoomModify;
#if ! DEBUG 
            private
#endif
                set => SetProperty(ref _isModeRoomModify, value); }
        public bool IsModeRoomEdit { get => _isModeRoomEdit; 
#if ! DEBUG 
            private
#endif
                set => SetProperty(ref _isModeRoomEdit, value); }
        public bool IsModeRoomAdd { get => _isModeRoomAdd; 
#if ! DEBUG 
            private 
#endif
                set => SetProperty(ref _isModeRoomAdd, value); }

        public bool AllFalseIsMode => !(IsModeDormitoryEdit || IsModeDormitoryAdd || IsModeRoomEdit || IsModeRoomAdd);

        #region Поля для хранения значений свойств
        private IDormitory _dormitorySelected;
        private IDormitory _dormitoryEdit;
        private IRoom _roomSelected;
        private IRoom _roomEdit;
        private bool _isModeDormitoryModify;
        private bool _isModeDormitoryEdit;
        private bool _isModeDormitoryAdd;
        private bool _isModeRoomModify;
        private bool _isModeRoomEdit;
        private bool _isModeRoomAdd;
        #endregion
    }
}
