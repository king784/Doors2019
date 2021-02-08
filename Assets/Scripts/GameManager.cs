using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OpenDesktop()
    {
        StartCoroutine(OpenDesktopCO());
    }

    IEnumerator OpenDesktopCO()
    {
        Cursor.visible = false;
        StartCoroutine(FindObjectOfType<FadeScript>().FadeOut());
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Desktop");
    }
}
