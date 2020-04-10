using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnnemi : Ennemi
{
    protected override void Start()
    {
        m_iMaxLife = 10;
        base.Start();
    }

    public override void action()
    {
        attractEnnemi(1);
        InventoryManager.instance.removeLife(1);
    }
}
