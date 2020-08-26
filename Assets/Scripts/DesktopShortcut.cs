using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopShortcut : MonoBehaviour
{
    [SerializeField] GameObject programPanel;
    List<GameObject> panels = new List<GameObject>();
    [SerializeField] string programTitle;

    public void CreatePanel()
    {
        GameObject newPanel = GameObject.Instantiate
        (
            programPanel, 
            Vector3.zero + new Vector3(panels.Count, -panels.Count, 0.0f), 
            Quaternion.identity, 
            transform.root
        );
        panels.Add(newPanel);
        newPanel.GetComponent<ProgramPanel>().Title.text = programTitle;
    }
}
