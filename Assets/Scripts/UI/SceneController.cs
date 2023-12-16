using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UI
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private GameObject infoTextPanel;
        [SerializeField]
        private TextMeshProUGUI infoText;
        public void NextLevel()
        {
            PlayerPrefsController.SaveSceneIndex(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void NewGame()
        {
            
            PlayerPrefsController.Delete();
            PlayerPrefsController.SaveSceneIndex(1);
            SceneManager.LoadScene(1);
        }
        public void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void CloseGame()
        {
            Application.Quit();
        }

        public void LoadGame()
        {
            if (PlayerPrefsController.IsASave())
            {
                SceneManager.LoadScene(PlayerPrefsController.GetSceneIndex());
            }
            else
            {
                infoTextPanel.SetActive(true);
                infoText.text = "No existe una partida guardada";
            }
        }

        public void DeleteInfo()
        {
            PlayerPrefsController.Delete();
        }
    }
}
