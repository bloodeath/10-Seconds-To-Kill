using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnnemi : Ennemi
{
    protected override void Start()
    {
        m_iMaxLife = 11;
        base.Start();
    }

    public override void action()
    {
        move(Vector2.left);
        InventoryManager.instance.removeLife(1);
    }
}
