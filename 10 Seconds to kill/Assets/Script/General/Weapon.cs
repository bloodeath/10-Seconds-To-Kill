using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Vector2 target;
    public int cost;
    protected bool infirst = false;
    public virtual void action()
    {
        if (BattleManager.instance.time < cost)
            return;
    }

    protected IEnumerator selectPos()
    {
        UIManager.instance.displayTargeting(true);
        yield return new WaitUntil(() => UIManager.instance.requestPosition());
        target = UIManager.instance.selectedPos;
        infirst = true;
    }

    protected abstract IEnumerator doSomething();
}
