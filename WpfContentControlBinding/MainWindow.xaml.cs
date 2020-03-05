using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
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

namespace WpfContentControlBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetFestplattenPLatz();
        }

        public void GetFestplattenPLatz()
        {
            ManagementObjectSearcher query;

            ManagementObjectCollection queryCollection;

            System.Management.ObjectQuery oq;

            string stringMachineName = "localhost";


            //Connect to the remote computer

            ConnectionOptions co = new ConnectionOptions();


            //Point to machine

            System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + stringMachineName + "\\root\\cimv2", co);


            oq = new System.Management.ObjectQuery("SELECT * FROM Win32_LogicalDisk WHERE DeviceID = 'C:'");

            query = new ManagementObjectSearcher(ms, oq);

            queryCollection = query.Get();

            foreach (ManagementObject mo in queryCollection)
            {
                Console.WriteLine($"freier platz: {mo["FreeSpace"].ToString()}");
            }
        }
    }
}
