using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TeamworkGame.Characters.Interface;

namespace TeamworkGame.Characters
{
    abstract class PlayableChar : Character, ICollidable, IMovable
    {
        //Fields
        private int gold; // hold the current state of gold
        // private Item[] inventory = new Item[10];

        //Constructor
        public PlayableChar( int[] position, int health, int moveSpeed)
            : base(position, health, moveSpeed)
        {
        }
        //Members
        public int Gold
        {
            get { return this.gold; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Gold cannot drop below zero!");
                }
                this.gold = value;
            }
        }


        //Methods
        public bool IsColliding()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            this.Position[0] -= 5;
        }

        public void MoveRight()
        {
            this.Position[0] += 5;
        }

        public void Jump()
        {
            throw new NotImplementedException();
        }
        public void Drink()
        {
            throw new NotImplementedException();
        }
        public void Equip()
        {
            throw new NotImplementedException();
        }
        public void Unequip()
        {
            throw new NotImplementedException();
        }
    }
}
