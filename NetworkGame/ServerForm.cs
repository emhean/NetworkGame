using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkGame
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        public string IP { get; private set; }
        public string Port { get; private set; }
        public string ClientName { get; private set; }

        private void connectClientBtn_Click(object sender, EventArgs e)
        {
            IP = ipTbx.Text;
            Port = portTbx.Text;
            ClientName = nameTbx.Text;
        }

        private void startServerBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
