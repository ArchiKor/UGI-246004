using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forms
{
    public partial class MainForm : Form
    {
        SecondForm seconfForm = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void openFormButton_Click(object sender, EventArgs e)
        {
            if (secondForm == null)
            
                secondForm = new SecondForm();
                secondForm.Show();
            
           
        }
    }
}
