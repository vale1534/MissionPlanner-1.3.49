using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner
{
    public partial class Con_Coord : Form
    {
        //Form criada para usuario entrar com IP e porta associada ao socket do coordenador

        public Con_Coord()
        {
            InitializeComponent();
        }

        public string IpAddress = "";
        public string Port = "";

        private void btnconnectcoord_Click(object sender, EventArgs e)
        {
            IpAddress = txtIP.Text.ToString();
            Port = txtPort.Text.ToString();

            this.Close();
        }
    }
}
