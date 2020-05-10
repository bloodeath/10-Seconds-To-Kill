using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    /*
    public int cost;
    protected bool m_bInfirst = false;
    protected Vector2 m_v2Target;
    public Patern patern;

    public virtual void action()
    {
        if (BattleManager.instance.getTime() < cost)
            return;
    }

    protected IEnumerator selectPos()
    {
        UIManager.instance.m_tcTargetingCollection.DisplayTargeting(true, patern);
        yield return new WaitUntil(() => UIManager.instance.requestPosition());
        m_v2Target = UIManager.instance.getPos();
        m_bInfirst = true;
    }

    protected virtual IEnumerator doSomething() {

        yield return new WaitUntil(() => m_bInfirst);
        Ennemi ennemi = BattleManager.instance.GetEnnemiAtPosition(m_v2Target);
        ennemi.removeLife(dmg);
        m_bInfirst = false;
        UIManager.instance.m_tcTargetingCollection.DisplayTargeting(false, Patern.point);
    }

    protected virtual bool IsPossible()
    {
        bool isPossible = true;
        isPossible += (ennemi && BattleManager.instance.removeTime(cost));
        return isPossible;
    }

    public Vector2 getTargets()
    {
        return m_v2Target;
    }

    public void setTarget(Vector2 target)
    {
        m_v2Target = target;
    }*/
}

