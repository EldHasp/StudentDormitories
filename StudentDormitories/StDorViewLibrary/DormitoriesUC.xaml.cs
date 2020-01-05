using StDorVMLibrary;
using StDorVMLibrary.Interfaces;
using StDorVMLibrary.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StDorViewLibrary
{
    /// <summary>
    /// Логика взаимодействия для MainUS.xaml
    /// </summary>
    public partial class DormitoriesUC : UserControl
    {
        public DormitoriesUC()
        {
            InitializeComponent();

            //var vm = new StDorViewModelDD();
            //vm.Dormitories.Add(new DormitoryVM() );
        }
    }
}
