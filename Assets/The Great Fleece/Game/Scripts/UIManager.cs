using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;

    public static UIManager Instance
    {

        get
        {
            if (_instance == null)
            {

                Debug.LogError("UIManager is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

    }

    public void Restart()
    {
        EditorSceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();

    }
}
