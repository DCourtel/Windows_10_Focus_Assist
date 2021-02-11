using System;
using System.Windows.Forms;
using FocusAssistLibrary;

namespace GetUserNotificationState
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGetState_Click(object sender, EventArgs e)
        {
            TxtBxState.Text = FocusAssistLib.GetFocusAssistState().ToString();
        }
    }
}
