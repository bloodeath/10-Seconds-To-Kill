using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ennemi : MonoBehaviour
{
    [SerializeField]
    private int pv;
    public Vector2 pos;

    public abstract void action();

    public void removePV(int pvtoless)
    {
        pv -= pvtoless;
        if (pv <= 0)
        {
            BattleManager.instance.ennemis.Remove(this);
            Destroy(gameObject);
        }
    }

    protected void Start()
    {
        updatePosition();
    }

    public void pushEnnemi(int push)
    {
        pos.x += push;
        if (pos.x > 2)
            pos.x = 2;
        updatePosition();
    }

    public void attractEnnemi(int push)
    {
        pos.x -= push;
        if (pos.x < 0)
            pos.x = 0;
        updatePosition();
    }

    public void rightShift(int push)
    {
        pos.y += push;
        if (pos.y > 2)
            pos.y = 2;
        updatePosition();
    }

    public void leftShift(int push)
    {
        pos.y -= push;
        if (pos.y < 0)
            pos.y = 0;
        updatePosition();
    }
    protected void updatePosition()
    {
        transform.position = new Vector3(1 + (3 * pos.x), 0.5f, -1 + (-2.5f * pos.y)) ;
    }
}
