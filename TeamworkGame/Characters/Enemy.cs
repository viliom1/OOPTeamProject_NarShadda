using System;

using System.Drawing;

namespace TeamworkGame.Characters
{
    public class Enemy : Character, IMovable,ICollidable
    {
        //Fields
        private int goldToDrop;
        private long lastAttack;
        private long animationStart;
        private bool isFirst = true;
        private int lastPosition;
        private bool isDead = false;
        private bool firstDead = true;
        private bool secondDead = false;
        private bool thirdDead = false;
        private bool fourthDead = false;
        //Constructor
        public Enemy(int[] position)
            :base( position,5,10,10)
        {
            this.Animation = new Bitmap[2]{ Resource1.FrogMan1,Resource1.FrogMan2 };
            this.lastAttack = Environment.TickCount;
            this.animationStart = Environment.TickCount;
            this.lastPosition = this.Position[0];
            this.goldToDrop = 50;
            
            
        }

        public bool IsDead
        {
            get { return this.isDead; }
            set { this.isDead = value; }
        }
        //Methods
        public void Attack()
        {
            if (Environment.TickCount >= lastAttack + 2000)
            {
                this.lastAttack = Environment.TickCount;
                Game.EnemyBullets.Add(new Bullet(new[] { this.Position[0] + 20, this.Position[1] + 70}, this.AttackPower, Resource1.spit));
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
            if (isDead)
            {
                if (!fourthDead)
                {
                    this.Position[1] += 39;
                }
                if (Environment.TickCount >= animationStart + 220)
                {
                    
                    this.animationStart = Environment.TickCount;
                    if (firstDead)
                    {
                        firstDead = false;
                        secondDead = true;
                        return Resource1.FrogMan3;
                    }
                    else if (secondDead)
                    {
                        secondDead = false;
                        thirdDead = true;
                        
                        return Resource1.FrogMan4;
                    }
                    else if (thirdDead)
                    {
                        thirdDead = false;
                        fourthDead = true;
                        
                        return Resource1.FrogMan5;
                    }
                    else if (fourthDead)
                    {
                        return Resource1.FrogMan6;
                    }
                }
                else
                {
                    if (firstDead)
                    {
                        firstDead = false;
                        secondDead = true;
                        return Resource1.FrogMan3;
                    }
                    else if (secondDead)
                    {
                        secondDead = false;
                        thirdDead = true;
                        return Resource1.FrogMan4;
                    }
                    else if (thirdDead)
                    {
                        thirdDead = false;
                        fourthDead = true;
                        return Resource1.FrogMan5;
                    }
                    else if (fourthDead)
                    {
                        return Resource1.FrogMan6;
                    }
                }
            }
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
            if (this.Health - dmg <= 0)
            {
                this.Health -= dmg;
                IsDead = true;
            }
            else
            {
                this.Health -= dmg;
            }
        }

        public int DropGold()
        {
           Random rnd = new Random();
            if (rnd.Next(100) <= 10)
            {
                return 100;
            }
            else
            {
                return 50;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} health left", this.Health);
        }
    }
}
