using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TeamworkGame.Characters
{
    abstract class PlayableChar : Character, ICollidable,IMovable
    {
        private int gold;
        private int attackPower;
        // private Item[] inventory = new Item[10];


        public PlayableChar(Bitmap[] animation,int[] position, int health, int moveSpeed) 
            : base(animation,position,health,moveSpeed)
        {

        }

        public bool IsColliding()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void Jump()
        {
            throw new NotImplementedException();
        }
    }
}
