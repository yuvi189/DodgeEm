using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCollisionWithObjects : MonoBehaviour
{
    public Text gameEndText; 
    public AudioClip gameOverSound; 
    public Button restartButton;
    private bool gameEnded = false;
    private float originalTimeScale;
    private void Start()
    {
        gameEndText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        originalTimeScale = Time.timeScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RandomObject") && !gameEnded)
        {
           
            gameEndText.text = "Game Over!"; 

            
            gameEndText.gameObject.SetActive(true);

            AudioSource.PlayClipAtPoint(gameOverSound, transform.position);

            restartButton.gameObject.SetActive(true);
            
            Time.timeScale = 0;
            
            gameEnded = true;
        }
    }
    public void RestartGame()
    {
        
        // Reload the current scene to restart the game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = originalTimeScale;
    }
}
