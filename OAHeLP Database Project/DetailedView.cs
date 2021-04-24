﻿using SubjectData.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            uxResidenceHistory.DataSource = subject.Residences;
            if (subject.DOB != null)
            {
                DateTimeOffset now = System.DateTimeOffset.UtcNow;
                TimeSpan ts = now - (DateTimeOffset)subject.DOB;
                int age = ts.Days / 365;
                uxAgeLabel.Text = $"Age: {age}";
            }
            else uxAgeLabel.Text = "Age: UNKNOWN";
            if (subject.photoFileName != null)
            {
                try
                {
                    uxPictureBox.Image = Image.FromFile($"C:\\Users\\haler\\source\\repos\\OAHeLP-Database-Project\\OAHeLP Database Project\\Images\\{subject.photoFileName}");
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    uxPictureBox.Image = Image.FromFile($"C:\\Users\\haler\\source\\repos\\OAHeLP-Database-Project\\OAHeLP Database Project\\Images\\default.jpg");
                }
            }

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
