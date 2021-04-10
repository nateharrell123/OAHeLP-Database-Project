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
        public DetailedView(string item1, int id, string item3)
        {
            InitializeComponent();
            uxProjectIDLabel.Text = $"Project ID: {id}";
        }
    }
}
