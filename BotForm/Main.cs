using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BotDll;

namespace BotForm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void StartExpeditionButton_Click(object sender, EventArgs e)
        {
            var bot = new OgameBot();
            bot.Login(UsernameTextBox.Text, PasswordTextBox.Text);
            bot.SendExpedition(Convert.ToInt32(ExpeditionPieceTextBox.Text));       
        }
    }
}
