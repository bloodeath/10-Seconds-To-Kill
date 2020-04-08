using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : Weapon
{
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
        Ennemi ennemi = BattleManager.instance.GetEnnemiAtPosition(m_v2Target);
        if (ennemi && BattleManager.instance.removeTime(cost))
        {
            ennemi.removePV(dmg);
        }
        m_bInfirst = false;
        UIManager.instance.displayTargeting(false);
    }
}
