using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAHeLP_Database_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //testing for the night, will uncomment soon

            SearchAndSort SaS = new SearchAndSort();
            string inputName = "johnson"; //eq15ip
            string inputEthnicGroup = "Batek";
            string inputVillageID = "n684972815913";
            string inputSex = "M";

            Dictionary<int, int> testDict = SaS.SearchDB(inputName, inputEthnicGroup, inputVillageID, inputSex);


            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI());
            */

        }
    }
}
