using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    //L'InventoryManager à pour but de géré les information lié au points de vie du joueur, le temps, le ennemis et leur placement
    //du fait qu'il soit un manager, il est un singleton. | amélioration futur, le faire hérité d'une classe singleton

    protected InventoryManager() { }

    private int m_iLife = 10;
    public int m_iMaxLife = 10;
    public List<GameObject> weapons;

    
    //retire des points de vie
    public void removeLife(int lifetoremove)
    {
        m_iLife -= lifetoremove;

        if (m_iLife < 0)
            m_iLife = 0;
    }

    public void addLife(int life)
    {
        m_iLife += life;

        if (m_iLife > m_iMaxLife)
            m_iLife = m_iMaxLife;
    }

    public int getLife() {
        return m_iLife;
    }
}
