using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerForm.Firebase;

namespace ServerForm.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FirestoreService.Initialize();  
        }

        private void btnQuizManager_Click(object sender, EventArgs e)
        {
            new QuizManagerForm().Show();
        }

        private void btnRoomManager_Click(object sender, EventArgs e)
        {
            new RoomManagerForm().Show();
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            new MonitorForm().Show();
        }
    }
}