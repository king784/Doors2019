using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopShortcut : MonoBehaviour
{
    [SerializeField] GameObject programPanel;
    [SerializeField] string programTitle;

    public void CreatePanel()
    {
        GameObject newPanel = GameObject.Instantiate(programPanel, transform.root);
        newPanel.GetComponent<ProgramPanel>().Title.text = programTitle;
    }
}
