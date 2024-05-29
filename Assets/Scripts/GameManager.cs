using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameWin()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Win");
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
