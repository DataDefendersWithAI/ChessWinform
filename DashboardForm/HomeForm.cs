﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_chat.DashboardForm
{
    
    public partial class HomeForm : Form
    {
        public event EventHandler ChildPvEButton_Click;
        public event EventHandler ChildPvPButton_Click;
        public HomeForm()
        {
            InitializeComponent();
            
        }

        private void PvEButton_Click(object sender, EventArgs e)
        {
            ChildPvEButton_Click?.Invoke(this, e);
        }

        private void PvPButton_Click(object sender, EventArgs e)
        {
            ChildPvPButton_Click?.Invoke(this, e);
        }
    }
}
