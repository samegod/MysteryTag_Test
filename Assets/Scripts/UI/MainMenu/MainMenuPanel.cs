using Core;
using TMPro;
using UnityEngine;

namespace UI.MainMenu
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField] private GameStatsPanel statsPanel;
        [SerializeField] private TMP_Text levelText;

        private const string LevelPrefix = "LVL: ";
        
        private void Start()
        {
            CloseStatistic();
            statsPanel.GenerateStats();
        }

        public void SetLevel(int level)
        {
            levelText.text = LevelPrefix + level;
        }

        public void Play()
        {
            SceneManager.LoadGameScene();
        }

        public void OpenStatistic()
        {
            statsPanel.Enable();
        }

        public void CloseStatistic()
        {
            statsPanel.Disable();
        }
    }
}
