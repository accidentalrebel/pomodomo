using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class ToDoForm : Form
    {
        public ToDoForm()
        {
            InitializeComponent();
        }

        private void tbx_taskEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the enter key is pressed
            if ( e.KeyChar == Convert.ToChar(13) )
            {
                //MessageBox.Show(tbx_taskEntry.Text);
                TDLItem tdlItem = new TDLItem(tbx_taskEntry.Text);
                //MessageBox.Show("The input is " + tdlItem.ToBeParsed);
            }
        }
    }
}
