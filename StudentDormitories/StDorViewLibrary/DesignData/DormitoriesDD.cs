using CommLibrary;
using StDorVMLibrary.Interfaces;
using System.Collections.ObjectModel;

namespace StDorViewLibrary.DesignData
{
    public class DormitoriesDD : DormitoryEditClass, IDormitoriesVM
    {
        IDormitory _dormitorySelected;
        bool _allFalseIsMode;
        public ObservableCollection<IDormitory> Dormitories { get; } = new ObservableCollection<IDormitory>();
        public IDormitory DormitorySelected { get => _dormitorySelected; set => SetProperty(ref _dormitorySelected, value); }
        public bool AllFalseIsMode { get => _allFalseIsMode; set => SetProperty(ref _allFalseIsMode, value); }
        public RelayCommand DormitoryAddCommand { get; }
        public RelayCommand DormitoryEditCommand { get; }
        public RelayCommand DormitoryRemoveCommand { get; }
        public RelayCommand DormitorySaveCommand { get; }
        public RelayCommand DormitoryCancelCommand { get; }

    }
}
