using TMPro;
using UnityEngine;

namespace UI.GamePanel
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelNumber;
        [SerializeField] private TMP_Text health;
        [SerializeField] private TMP_Text score;

        private const string LevelNumberPrefix = "Level: ";
        private const string HealthPrefix = "Health: ";
        private const string ScorePrefix = "Score: ";

        public void SetLevelNumber(int number)
        {
            levelNumber.text = LevelNumberPrefix + number;
        }

        public void SetHealth(int value)
        {
            health.text = HealthPrefix + value;
        }

        public void SetScore(int value)
        {
            score.text = ScorePrefix + value;
        }
    }
}
