using DataTransfering;
using Progress;
using UI.MainMenu;
using UnityEngine;

namespace Core
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private MainMenuPanel mainMenu;
        
        private void Start()
        {
            int currentLevel = ProgressSaveLoad.GetLastPassedLevel() + 1;
            DataTransfer.Instance.SetCurrentLevel(currentLevel); 
            mainMenu.SetLevel(currentLevel);
        }
    }
}
