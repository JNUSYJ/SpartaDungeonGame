namespace SpartaDungeonGame
{
    internal class Program
    {
        public static Program prog;
        public static Character character;
        public static Shop shop;
        public static Dungeons dungeons;
        public static SceneManager sceneManager;
        public static SystemMessage systemMessage;

        static void Main(string[] args)
        {
            prog = new Program();
            character = new Character();
            shop = new Shop();
            dungeons = new Dungeons();
            sceneManager = new SceneManager();
            systemMessage = new SystemMessage();
            sceneManager.ChangeScene("StartScene");
        }
    }
}
