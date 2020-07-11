using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels;

namespace TestCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ShipmentRegistration datacontobj = new ShipmentRegistrationVM();
            //datacontobj.GetAll();
        }
        private void ShipmentRegistrationViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShipmentRegistrationVM ShipmentRegistrationModelObject =
               new ShipmentRegistrationVM();

            ShipmentRegistrationViewControl.DataContext = ShipmentRegistrationModelObject;
        }
    }
}
