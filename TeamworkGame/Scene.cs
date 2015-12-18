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
            Scene scene = new Scene();
            scene.QuestGiver = new QuestGiver(new Bitmap[] { Resource1.QuestGiver1 }, new int[] { 600, 350 });
            scene.Background = Resource1.Background;
            scene.QuestGiver.Quest = "Raynor, sir!";
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



    }
}
