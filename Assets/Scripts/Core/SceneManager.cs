namespace Core
{
    public static class SceneManager
    {
        private const int MenuSceneIndex = 0;
        private const int GameSceneIndex = 1;

        public static void LoadMenuScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(MenuSceneIndex);
        }
        
        public static void LoadGameScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(GameSceneIndex);
        }
    }
}