using UnityEngine;

namespace DataTransfering
{
    public class DataTransfer : MonoBehaviour
    {
        private static DataTransfer _instance;
        private int _currentLevel;

        public int CurrentLevel => _currentLevel;
        public static DataTransfer Instance => _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            
            DontDestroyOnLoad(gameObject);
        }

        public void SetCurrentLevel(int value)
        {
            _currentLevel = value;
        }
    }
}