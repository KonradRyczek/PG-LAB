using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{

    public void openExitMenu()
    {
        gameObject.SetActive(true);
    }

    public void closeExitMenu()
    {
        gameObject.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
