using System.Collections.Generic;
using Core.GameStatistics;
using UnityEngine;

namespace UI.MainMenu
{
    public class GameStatsPanel : MonoBehaviour
    {
        [SerializeField] private StatElement statElementPrefab;
        [SerializeField] private RectTransform statsParent;

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
        
        public void GenerateStats()
        {
            List<GameStat> stats = GameStatsSaveLoad.LoadGameStats();

            if (stats == null)
            {
                return;
            }
            
            for (int i = 0; i < stats.Count; i++)
            {
                if (stats[i] == null)
                {
                    Debug.Log("Game stat is null at " + i);
                    continue;
                }
                
                StatElement element = Instantiate(statElementPrefab, statsParent);
                element.SetValues(stats[i]);
            }
        }
    }
}
