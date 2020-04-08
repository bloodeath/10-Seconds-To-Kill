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
        yield return new WaitUntil(() => infirst);
        Ennemi ennemi = BattleManager.instance.GetEnnemiAtPosition(target);
        if (ennemi && BattleManager.instance.removeTime(cost))
        {
            ennemi.removePV(dmg);
        }
        infirst = false;
        UIManager.instance.displayTargeting(false);
    }
}
