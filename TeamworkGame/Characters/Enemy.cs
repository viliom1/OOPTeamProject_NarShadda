using System;

using System.Drawing;

namespace TeamworkGame.Characters
{
    class Enemy : Character, IMovable
    {
        //Fields
        private int goldToDrop;
        private long lastAttack;
        private long animationStart;
        private bool isFirst = true;
        private int lastPosition;
        //Constructor
        public Enemy(int[] position)
            :base( position, 5, 100, 10)
        {
            this.Animation = new Bitmap[2]{ Resource1.FrogMan1,Resource1.FrogMan2 };
            this.lastAttack = Environment.TickCount;
            this.animationStart = Environment.TickCount;
            this.lastPosition = this.Position[0];
        }
        //Methods
        public void Attack()
        {
            if (Environment.TickCount >= lastAttack + 2000)
            {
                this.lastAttack = Environment.TickCount;
                Game.EnemyBullets.Add(new Bullet(new[] { this.Position[0] + 20, this.Position[1] + 70}, 20, Resource1.spit));
            }
            
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
            if (this.Position[0] + this.MoveSpeed <= 1200)
            {
                this.Position[0] += this.MoveSpeed;
            }
            
        }

        public void Jump()
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
    }
}
