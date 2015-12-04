using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TeamworkGame
{
    public partial class GameWindow : Form
    {
        private Game game = new Game();
        public GameWindow()
        {
            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Canvas.CreateGraphics();
            this.game.StartGraphics(g);
        }

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.GameStop();
        }
        private void GameWindow_Load(Object sender,EventArgs e)
        {
            AllocConsole();
        }
        [DllImport("kernel32.dll",SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }

        
}
