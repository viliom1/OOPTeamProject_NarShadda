using System;


namespace TeamworkGame.Characters
{
    class QuestGiver : Character
    {
        //Fields
        private string name;
        private string quest;
        //Constructor
        public QuestGiver(System.Drawing.Bitmap[] animation, int[] position)
            : base( position, 0, 500, 0)
        {
        }
        //Members
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }
                this.name = value;
            }
        }
        public string Quest
        {
            get { return this.quest; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Quest cannot be null!");
                }
                this.quest = value;
            }
        }
        //Methods
        public void Talk()
        {
            throw new NotImplementedException();
        }
    }
}
