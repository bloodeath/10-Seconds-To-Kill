using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLine : Weapon
{/*
    public int dmg;

    public override void action()
    {
        base.action();
        StartCoroutine(selectPos());
        StartCoroutine(doSomething());
    }

    protected override IEnumerator doSomething()
    {
        yield return new WaitUntil(() => m_bInfirst);
        if (BattleManager.instance.removeTime(cost))
            for (int y = 0; y < 3; y++)
            {
                Ennemi ennemi = BattleManager.instance.GetEnnemiAtPosition(new Vector2(m_v2Target.x, y));
                if (ennemi)
                    ennemi.removeLife(dmg);
            
            }
        m_bInfirst = false;
        UIManager.instance.m_tcTargetingCollection.DisplayTargeting(false, Patern.point);
    }*/
}
