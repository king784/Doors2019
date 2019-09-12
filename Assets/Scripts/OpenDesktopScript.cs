using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDesktopScript : MonoBehaviour
{
    private void OnEnable() 
    {
        FindObjectOfType<GameManager>().OpenDesktop();
    }
}
