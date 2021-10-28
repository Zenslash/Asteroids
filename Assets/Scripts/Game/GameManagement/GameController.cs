
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameController : Singleton<GameController>
    {
        
        #region Fields

        [SerializeField] private GameObject _endGameWnd;
        [SerializeField] private TextMeshProUGUI _scoreLbl;

        #endregion
        
        #region Methods

        public void ShowEndGameWnd()
        {
            _scoreLbl.text = GameStats.score.ToString();
            _endGameWnd.SetActive(true);
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }

        public void RestartGame()
        {
            GameStats.score = 0;
            SceneManager.LoadScene(0);
        }
        
        #endregion

    }
}
