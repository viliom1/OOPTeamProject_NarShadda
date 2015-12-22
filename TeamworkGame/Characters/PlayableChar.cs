using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using TeamworkGame.Item;


namespace TeamworkGame.Characters
{
    abstract class PlayableChar : Character, ICollidable, IMovable
    {
        //Fields
        private int gold; // hold the current state of gold
        private List<IItem> inventory = new List<IItem>();
        private bool isFirst;
        private long animationStart;
        private int lastPosition;
        private bool isDucking;
        private int attackRange;
        public bool IsDead { get; private set; }
        public bool  IsDucking { get; set; }
        public int AttackRange { get; private set; }


        //Constructor
        public PlayableChar(int[] position, int moveSpeed, int health)
            : base(position, moveSpeed, health)
        {
            this.AttackRange = 500;
            this.isFirst = true;
            this.animationStart = Environment.TickCount;
            this.lastPosition = this.Position[0];
            this.IsDucking = false;
            
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
        public IList<IItem> Inventory { get { return this.inventory; } }

        //Methods
        public bool IsColliding()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            if (!IsDucking)
            {
                if (this.Position[0] - this.MoveSpeed > 0)
                {
                    this.Position[0] -= this.MoveSpeed;
                }
            }
           
        }

        public void MoveRight()
        {
            if (!IsDucking)
            {
                if (this.Position[0] + this.MoveSpeed <= 1000)
                {
                    this.Position[0] += this.MoveSpeed;
                }
            }
           
            
        }

        public virtual void Attack()
        {
            
        }

        public void Jump()
        {
            throw new NotImplementedException();
        }

        public void Buy(IItem item)
        {
            if (inventory.Count < 6)
            {
                Gold -= item.Price;
                inventory.Add(item);
            }
            

        }
        public void Drink(IItem item)
        {
            if (item.Name == "Health potion")
            {
                this.Health += item.Increment;
                this.Inventory.Remove(item);
            }
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
            if (IsDucking)
            {
                return Resource1.RaynorSquat;
            }
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

        public void Duck()
        {
            if (IsDucking)
            {
                IsDucking = false;
            }
            else
            {
                IsDucking = true;
            }
        }

        public void CollectGold(int amount)
        {
            this.Gold += amount;
        }
    }
}
