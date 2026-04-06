using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }
}