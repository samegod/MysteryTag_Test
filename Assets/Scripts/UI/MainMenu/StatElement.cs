using Core.GameStatistics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class StatElement : MonoBehaviour
    {
        [SerializeField] private Color victoryColor;
        [SerializeField] private Color defeatColor;
        [SerializeField] private Image background;
        [SerializeField] private TMP_Text levelNumber;
        [SerializeField] private TMP_Text time;
        [SerializeField] private TMP_Text score;

        private const string LevelPrefix = "Level: ";
        private const string TimePrefix = "Time: ";
        private const string ScorePrefix = "Score: ";
        
        public void SetValues(GameStat stat)
        {
            levelNumber.text = LevelPrefix + stat.LevelNumber;
            time.text = TimePrefix + stat.Time;
            score.text = ScorePrefix + stat.Score;
            
            background.color = stat.Victory ? victoryColor : defeatColor;
        }
    }
}
