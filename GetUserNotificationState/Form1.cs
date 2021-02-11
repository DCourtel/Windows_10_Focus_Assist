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
            if (ConcentrationWizardLibrary.GetConcentrationWizardName() == ConcentrationWizardLibrary.ConcentrationWizardName.Focus_Assist)
            { TxtBxState.Text = ConcentrationWizardLibrary.GetFocusAssistState().ToString(); }
            else
            { TxtBxState.Text = ConcentrationWizardLibrary.GetQuietHoursState().ToString(); }
        }

        private void BtnGetFeatureName_Click(object sender, EventArgs e)
        {
            TxtBxFeatureName.Text = ConcentrationWizardLibrary.GetConcentrationWizardName().ToString();
        }
    }
}
