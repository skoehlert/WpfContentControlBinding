using System.Management;

namespace WpfContentControlBinding.Models
{
    public class HomePage
    {
        public string PageTitle { get; set; }

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
                //Console.Writeline(mo["FreeSpace"].ToString());
            }
        }
    }    
}
