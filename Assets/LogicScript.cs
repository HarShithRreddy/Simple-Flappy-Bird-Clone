using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int PlayerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool isGameOver = false;

    void Start()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    [ContextMenu("Add Score")]
    public void addScore(int score){
     PlayerScore=PlayerScore + score;
     scoreText.text=PlayerScore.ToString();
    }

   public void restartGame() 
   {
       isGameOver = false;
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void gameOver() 
   {
       gameOverScreen.SetActive(true);
       isGameOver = true;
   }
}
