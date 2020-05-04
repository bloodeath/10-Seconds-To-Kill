using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class InfoLifeBar : MonoBehaviour
{
    private Slider m_sSlider;
    private Text m_tText;
    private void Start()
    {
        m_sSlider = GetComponent<Slider>();
        m_tText = GetComponentInChildren<Text>(true);
        m_sSlider.onValueChanged.AddListener(delegate { UpdateValue(); });
        UpdateValue();
    }

    private void UpdateValue()
    {
        m_tText.text = Mathf.FloorToInt(m_sSlider.value).ToString();
    }
}
