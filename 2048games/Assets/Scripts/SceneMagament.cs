using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public void  SceneRestart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
