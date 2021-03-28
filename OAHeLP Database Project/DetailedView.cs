using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAHeLP_Database_Project
{
    public partial class DetailedView : Form
    {
        public DetailedView(string item1, string item2, string item3)
        {
            InitializeComponent();
            label2.Text = $"{item1}'s detailed view";
        }
    }
}
