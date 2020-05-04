using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int cost;
    protected bool m_bInfirst = false;
    protected Vector2 m_v2Target;
    public Patern patern;
    public List<WeaponParticularity> weaponParticularities;

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

    protected abstract IEnumerator doSomething();

    public Vector2 getTargets()
    {
        return m_v2Target;
    }

    public void setTarget(Vector2 target)
    {
        m_v2Target = target;
    }
}

public enum Patern
{
    point,
    line,
    column,
    cross,
    diagonalHtoL,
    diagonalLtoH,
    diagonal,
}

public enum WeaponParticularity
{
    damage,
    attract,
    repulse,
    shiftLeft,
    shiftRight,
    fire,
    electric,
    heal,
    stun,
    timeRestore
}