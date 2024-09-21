using UnityEngine;
using YG;

public class YandexPlugin : MonoBehaviour
{
   private GameManager _score;
    private void Start()
    {
        _score = FindAnyObjectByType<GameManager>(); 
        LoadData();
    }

    public void ShowAdd()
    {
        YandexGame.FullscreenShow();
    }

   public void AddNewLiderboard()
   {
        YandexGame.NewLeaderboardScores("BestScore" , _score.bestScore);
   }

    
   public void LoadData()
   {
        _score.bestScore = YandexGame.savesData.BestScoreDataSave;
        Debug.Log(_score.bestScore);
   }

   public void SaveData()
   {
        YandexGame.savesData.BestScoreDataSave = _score.bestScore;
        Debug.Log(_score.bestScore);
   }
}
