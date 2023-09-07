using UnityEngine;
using UnityEngine.SceneManagement;

namespace DEEPP.Model
{
    public class GameSettings : MonoBehaviour
    {
        private void Awake()
        {
            LoadHUD();
            //SetCursorSettings();
        }

        private void LoadHUD()
        {
            SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
        }

        private void SetCursorSettings()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}