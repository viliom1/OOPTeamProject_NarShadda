using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TeamworkGame.Characters
{
    class Enemy : Character, IMovable
    {
        //Fields
        private int goldToDrop;
        //Constructor
        public Enemy(Bitmap[] animation, int[] position, int moveSpeed, int health, int attackPower)
            : base( position, moveSpeed, health, attackPower)
        {
        }
        //Methods
        public void Attack()
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
