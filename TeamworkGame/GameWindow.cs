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
        
        public GameWindow()
        {
            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Canvas.CreateGraphics();
            Game.StartGraphics(g);
        }

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.GameStop();
        }
        private void GameWindow_Load(Object sender,EventArgs e)
        {
            AllocConsole();
        }
        [DllImport("kernel32.dll",SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void GameWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString().ToLower())
            {
                case "d":
                    Game.MoveRight();
                    break;
                case "a":
                    Game.MoveLeft();
                    break;
                case "k": Game.Attack();
                    break;
                case "e":
                    if (Game.QuestGiver != null)
                    {
                        if (Game.QuestGiver.Position[0] - Game.Character.Position[0] <= 200)
                        {
                            Game.QuestGiver.Interact();
                        }
                    }
                    
                    //if (Math.Abs(Game.Vendor.Position[0] - Game.Character.Position[0]) <= 100)
                    //{
                        
                    //}
                    
                    break;
            }

        }
    }

        
}
