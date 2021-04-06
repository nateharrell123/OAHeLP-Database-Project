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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SearchAndSort sas = new SearchAndSort();

            string exampleInput;
            string exampleDB;
            int exampleDistance;


            exampleInput = "Jack";
            exampleDB = "Zack";

            exampleDistance = sas.nameMatch(exampleInput, exampleDB);

            Console.WriteLine(exampleDistance);


            Application.Run(new UI());






        }
    }
}
