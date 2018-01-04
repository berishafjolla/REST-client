using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Swensen.Ior.Forms
{
    public partial class BasicAuthentication : Form
    {
        public BasicAuthentication()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void basicSubmit_Click(object sender, EventArgs e)
        {
            var credentialsString = basicUsername.Text + ":" + basicPassword.Text;
            var credentialBytes = Encoding.UTF8.GetBytes(credentialsString);
            var base64String = Convert.ToBase64String(credentialBytes);
            mainForm.AddHeader("Authorization", "Basic " + base64String);
            this.Dispose();
        }

        MainForm mainForm;

        public void SetMainForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }
    }
}
