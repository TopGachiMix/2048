using UnityEngine;
using System.Collections;
using TMPro;
public class GameManager : MonoBehaviour
{   [Header("GameManager")]
    public CanvasGroup GameOverPanel;
    public TileBoard board;
    public GameObject ScoreButtons;
    public int bestScore;
    private YandexPlugin yg;
    
    [Header("Text")]
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI BestText;
    [SerializeField] private int _score;
    private void Start()
    {
        NewGame();
        yg = FindAnyObjectByType<YandexPlugin>();
    }

    public void NewGame()
    {   
        GameOverPanel.alpha = 0f;
        GameOverPanel.interactable = false;
        board.ClearBoard();
        board.enabled = true;
        for(int i = 0 ; i < 2 ; i++)
        {
            board.CreateTile();
        }
        SetScore(0);
        BestText.text = LoadBestScore().ToString();
        


    }

    public void IncreaseScore(int points)
    {
        SetScore(_score + points);
    }

   private void SetScore(int _score)
   {
        this._score = _score;
        ScoreText.text = _score.ToString();
        SaveBestScore();
   }
   private void SaveBestScore()
   {
        bestScore = LoadBestScore();

        if(_score > bestScore)
        {
            yg.SaveData();
            PlayerPrefs.SetInt("bestScore", _score);

        }
   }

   private int LoadBestScore()
   {    return PlayerPrefs.GetInt("bestScore" , 0);
        
   }
    

    public void GameOver()
    {
        board.enabled = false;
        GameOverPanel.interactable = true;

        StartCoroutine(Fade(GameOverPanel , 1f , 1f));
        ScoreButtons.SetActive(false);
       


    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to , float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while(elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from , to , elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = to;
    }
}
