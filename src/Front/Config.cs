using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SistemaGestionGanado.src.Front {
    public partial class Config: Form {
        private Main main;
        public Config() {
            InitializeComponent();
        }

        public Config(Main main) {
            this.main = main;
            InitializeComponent();
            this.txtConnectionString.Text = Properties.Settings.Default.DBConnectionString;
        }

        private void button1_Click(object sender, EventArgs e) {
            Back.Vaca.LimpiarEliminadas();
        }

        private void button2_Click(object sender, EventArgs e) {
            Back.Vaca.RestaurarEliminadas();
            this.main.actualizarGridView(true);
        }

        private void button3_Click(object sender, EventArgs e) {
            Properties.Settings.Default.DBConnectionString = this.txtConnectionString.Text;
            Properties.Settings.Default.Save();
            string currentExecutable = Application.ExecutablePath;
            Process.Start(currentExecutable);
            Application.Exit();
        }
    }
}
