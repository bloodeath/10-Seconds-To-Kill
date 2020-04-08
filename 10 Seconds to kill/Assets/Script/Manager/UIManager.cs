using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas canvas;
    public List<GameObject> generetedButton;
    public Text displayTime;
    public Text displayLife;

    private void Start()
    {
        _instance = this;
        displayTargeting(false);
    }

    private void Update()
    {
        displayTime.text = BattleManager.instance.time.ToString();
        displayLife.text = GameManager.instance.pv.ToString();
    }

    private static UIManager _instance;

    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                _instance = go.AddComponent<UIManager>();
            }
            return _instance;
        }
    }

    public Vector2 selectedPos;
    private bool isSelected = false;

    public bool requestPosition()
    {
        if (isSelected)
        {
            isSelected = false;
            return true;
        }
        return false;
    }

    public void selectPos(Vector2 pos)
    {
        if (pos.x >= 0 && pos.x <= 2 && pos.y >= 0 && pos.y <= 2)
        {
            selectedPos = pos; 
            isSelected = true;
        }
    }

    public void displayTargeting(bool isActivate)
    {
        foreach(GameObject go in generetedButton)
        {
            go.SetActive(isActivate);
        }
    }
}
