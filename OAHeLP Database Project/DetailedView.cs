using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SubjectData.Models;
using System.Windows;

namespace OAHeLP_Database_Project
{
    public partial class DetailedView : Form
    {
        Subject subject;
        public DetailedView(Subject s)
        {
            subject = s;
            InitializeComponent();
            UpdateView();
        }

        public void UpdateSubject(Subject s)
        {
            subject = s;
        }

        public void UpdateView()
        {
            uxProjectIDLabel.Text = $"Project ID: {subject.OAHeLPID}";
            uxNameLabel.Text = $"Name: {subject.Names[0].FirstName} {subject.Names[0].MiddleNames} {subject.Names[0].LastName}";
            uxSexLabel.Text = $"Sex: {subject.Sex}";
            uxEthnicityLabel.Text = $"Ethnic Group: {subject.EthnicGroup}";
        }

        public void ClearView()
        {
            uxProjectIDLabel.Text = $"Project ID: ";
            uxNameLabel.Text = $"Name: ";
            uxSexLabel.Text = $"Sex: ";
            uxEthnicityLabel.Text = $"Ethnic Group: ";
        }
    }
}
