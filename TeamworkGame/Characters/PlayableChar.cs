using System;
using System.Drawing;


namespace TeamworkGame.Characters
{
    abstract class PlayableChar : Character, ICollidable, IMovable
    {
        //Fields
        private int gold; // hold the current state of gold
        // private Item[] inventory = new Item[6];
        private bool isFirst;
        private long animationStart;
        private int lastPosition;
        public bool IsDead { get; private set; }

        //Constructor
        public PlayableChar(int[] position, int moveSpeed, int health)
            : base(position, moveSpeed, health)
        {
            this.isFirst = true;
            this.animationStart = Environment.TickCount;
            this.lastPosition = this.Position[0];
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
            if (this.Position[0] - this.MoveSpeed > 0)
            {
                this.Position[0] -= this.MoveSpeed;

            }
        }

        public void MoveRight()
        {
            if (this.Position[0] + this.MoveSpeed < 1000 )
            {
                this.Position[0] += this.MoveSpeed;
            }
            
        }

        public virtual void Attack()
        {
            
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
        public Bitmap GetAnimation()
        {
            bool isMoving = lastPosition == this.Position[0];
            if (isMoving)
            {
                return this.Animation[0];
            }
            else
            {
                this.lastPosition = this.Position[0];
                if (this.isFirst)
                {
                    if (Environment.TickCount >= animationStart + 220)
                    {
                        this.isFirst = false;
                        this.animationStart = Environment.TickCount;
                    }
                    return this.Animation[0];
                }
                else
                {
                    if (Environment.TickCount >= animationStart + 220)
                    {
                        this.isFirst = true;
                        this.animationStart = Environment.TickCount;
                    }
                    return this.Animation[1];
                }
            }


        }

        public void Collide(int dmg)
        {
            if (Health - dmg > 0)
            {
                Health -= dmg;
            }
            else
            {
                Health -= dmg;
                IsDead = true;
            }
        }
    }
}
