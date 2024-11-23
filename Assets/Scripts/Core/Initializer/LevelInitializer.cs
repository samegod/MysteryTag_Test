using System;
using SpaceShip;
using UI.GamePanel;
using UnityEngine;

namespace Core.Initializer
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private InfoPanel panel;
        [SerializeField] private AsteroidsSpawner spawner;
        [SerializeField] private Ship playerShip;
        
        private void Awake()
        {
            
        }
    }
}