using DEEPP.Components.Characters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DEEPP.Model
{
    public class GameSession : MonoBehaviour
    {
        [field: SerializeField] public Player Player { get; private set; } 
        public static GameSession Instance;

        private void Awake()
        {
            Instance ??= this;
            LoadHUD();
        }

        private void LoadHUD()
        {
            SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
        }
    }
}