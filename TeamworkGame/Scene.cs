using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamworkGame.Characters;
using System.Drawing;

namespace TeamworkGame
{
    public class Scene
    {
        private QuestGiver questgiver;
        private Vendor vendor;
        private List<Enemy> enemies;
        private Bitmap background;

        public Scene()
        {
            Enemies = new List<Enemy>();
            DeadEnemies = new List<Enemy>();
            
        }
        public QuestGiver QuestGiver { get; private set; }
        public Vendor Vendor { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public Bitmap Background { get; private set; }
        public List<Enemy> DeadEnemies { get; set; }

        public static Scene LoadFirstScene()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Pss-st, hey you...Welcome to StarCraft Adventure. My name is Mysterious Man and I'm here");
            sb.AppendLine("to help you! I believe I saw some of your friend zerglings being kidnapped by the evil ");
            sb.AppendLine("Frogman. Your friends are in great danger! Zerglings are the Evil Frogman's favourite snack.");
            sb.AppendLine("You better run before it's too late for them... Oh, and watch out for his evil minions. They");
            sb.AppendLine("would do everything to stop you. Be aware of their toxic spit – it can go right trough your");
            sb.AppendLine("armor and kill you!");
            Scene scene = new Scene();
            scene.QuestGiver = new QuestGiver(new Bitmap[] { Resource1.QuestGiver1 }, new int[] { 600, 350 });
            scene.Background = Resource1.Background;
            scene.QuestGiver.Quest = sb.ToString();
            return scene;
        }

        public static Scene LoadSecondScene()
        {
            Scene scene = new Scene();
            scene.Vendor = new Vendor(new Bitmap[]{Resource1.Shop1} , new int[] {600, 250});
            scene.Background = Resource1.Background;
            return scene;
            
        }

        public static Scene LoadThirdScene()
        {
            Scene scene = new Scene();
            scene.Background = Resource1.Background;
            scene.Enemies = new List<Enemy>();
            scene.Enemies.Add(new Enemy(new int[]{1000, 330}));
            return scene;
        }

        public static Scene LoadFourthScene()
        {
            Scene scene = new Scene();
            scene.Background = Resource1.Background;
            scene.Enemies = new List<Enemy>();
            scene.Enemies.Add(new Enemy(new int[] { 700, 330 }));
            scene.Enemies.Add(new Enemy(new int[] { 1000, 330 }));
            
            return scene;
        }

        public static Scene LoadFifthScene()
        {
            Scene scene = new Scene();
            scene.Background = Resource1.Background;
            scene.Enemies = new List<Enemy>();
            scene.Enemies.Add(new Enemy(new int[] { 500, 330 }));
            scene.Enemies.Add(new Enemy(new int[] { 700, 330 }));
            scene.Enemies.Add(new Enemy(new int[] { 1000, 330 }));
            
            
            return scene;
        }

        public static Scene loadSixthScene()
        {
            Scene scene = new Scene();
            scene.Background = Resource1.Background;
            scene.Enemies.Add(new Enemy(new int[]{1000,320},100));
            return scene;
        }



    }
}
