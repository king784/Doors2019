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
}
