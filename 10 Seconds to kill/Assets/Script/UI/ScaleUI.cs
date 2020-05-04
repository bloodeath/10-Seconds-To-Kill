using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleUI : MonoBehaviour
{
    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();   
    }

    void Update()
    {
        float scale = Camera.main.pixelWidth / 928.0f;
        rect.localScale = new Vector3(scale, scale, 0);
    }
}
