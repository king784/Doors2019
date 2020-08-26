using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgramPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;

    public TextMeshProUGUI Title { get => title; set => title = value; }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        if(transform.hasChanged)
        {
            Debug.Log(GetComponent<RectTransform>().position.x);
        }
    }

    [ContextMenu("Debuggi")]
    public void Debugg()
    {
        Vector3[] corners = new Vector3[4];
        transform.root.GetComponent<RectTransform>().GetWorldCorners(corners);
        Debug.Log(corners[0]);
        Debug.Log(corners[1]);
        Debug.Log(corners[2]);
        Debug.Log(corners[3]);
    }
}
