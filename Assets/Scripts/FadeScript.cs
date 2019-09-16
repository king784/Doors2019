using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Image>().material; 
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        float lerp = 0.0f;

        while(lerp <= 1.0f)
        {
            mat.SetFloat("_Cutoff", Mathf.Lerp(0.0f, 1.0f, lerp));
            lerp += Time.deltaTime;
            yield return null;
        }

        mat.SetFloat("_Cutoff", 1.0f);
    }

    public IEnumerator FadeIn()
    {
        float lerp = 0.0f;

        while(lerp <= 1.0f)
        {
            mat.SetFloat("_Cutoff", Mathf.Lerp(1.0f, 0.0f, lerp));
            lerp += Time.deltaTime;
            yield return null;
        }

        mat.SetFloat("_Cutoff", 0.0f);
    }
}
