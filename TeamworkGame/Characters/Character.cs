using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TeamworkGame
{
    abstract class Character
    {
        //Fields
        private Bitmap[] animation; // all frames from the animation
        private int[] position; // position[0] for X axis and position[1] for Y axis
        private int health; // holds the current health of character
        private int moveSpeed; // holds the momevemnt speed of the character



        public Character(Bitmap[] animation, int[] position,int moveSpeedint ,int health = 500)
        {
            this.Animation = animation;
            this.Position = position;
            this.Health = health;
            this.MoveSpeed = moveSpeed;
        }

        public Bitmap[] Animation
        {
            get { return this.animation; }
            private set 
            {this.animation = value;}

        }

        public int[] Position
        {
            get { return this.position;}
            set
            {
                if (value[0]< 0 || value[1] < 0)
                {
                    throw new ArgumentOutOfRangeException("Char position cannot be below zero");
                }
                this.position = value;
            }
        }
        public int Health
        {
            get { return this.health; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Char health cannot be below  zero or zero!");
                }
                this.health = value;
            }
        }

        public int MoveSpeed
        {
            get { return this.moveSpeed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Char move speed cannnot be below zero!");
                }
                this.moveSpeed = value;
            }
        }

    }
}
