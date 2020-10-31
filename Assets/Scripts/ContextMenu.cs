using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContextMenu : MonoBehaviour
{
    [SerializeField] private OpenClosePanel _panelSwitcher;
    [SerializeField] private GameObject _contextPanel;

    [SerializeField] private KeyCode _contextMenuButtton = KeyCode.Escape;

    private void Awake()
    {
        CloseContextPanel();
    }

    public void OpenContextPanel()
    {
        _panelSwitcher.OpenPanel(_contextPanel);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void CloseContextPanel()
    {
        _panelSwitcher.ClosePanel(_contextPanel);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void BackMajorMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_contextMenuButtton))
        {
            OpenContextPanel();
        }
    }
}
