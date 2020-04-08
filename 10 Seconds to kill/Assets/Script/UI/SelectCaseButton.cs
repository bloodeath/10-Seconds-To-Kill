using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCaseButton : MonoBehaviour
{
    public Vector2 pos;
    public void setPosition()
    {
        UIManager.instance.selectPos(pos);
    }
}
