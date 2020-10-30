using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _continueButton;

    private void Start()
    {
        Cursor.visible = true;

        if (PlayerPrefs.GetFloat("PowerCount") > 0)
        {
            _continueButton.SetActive(true);
        }
        else
        {
            _continueButton.SetActive(false);
        }
    }

    public void StartGameOver()
    {
        PlayerPrefs.DeleteKey("PowerCount");
        PlayerPrefs.DeleteKey("FoodCount");
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
