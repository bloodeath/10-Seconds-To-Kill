using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnnemi : Ennemi
{
    public override void action()
    {
        attractEnnemi(1);
        GameManager.instance.removeLife(1);
    }
}
