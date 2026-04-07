using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager1 : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }
}