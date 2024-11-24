using Core;
using DataTransfering;
using UnityEngine;

namespace UI.GameMenus
{
    public class GameMenus : MonoBehaviour
    {
        [SerializeField] private RectTransform victoryMenu;
        [SerializeField] private RectTransform defeatMenu;

        private void Start()
        {
            victoryMenu.gameObject.SetActive(false);
            defeatMenu.gameObject.SetActive(false);
        }

        public void ShowVictoryMenu()
        {
            victoryMenu.gameObject.SetActive(true);
        }

        public void ShowDefeatMenu()
        {
            defeatMenu.gameObject.SetActive(true);
        }

        public void PlayNext()
        {
            DataTransfer.Instance.SetCurrentLevel(DataTransfer.Instance.CurrentLevel + 1);
            SceneManager.LoadGameScene();
        }

        public void PlayAgain()
        {
            SceneManager.LoadGameScene();
        }

        public void Exit()
        {
            SceneManager.LoadMenuScene();
        }
    }
}
