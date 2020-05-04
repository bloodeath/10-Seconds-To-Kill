using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ennemi : MonoBehaviour
{
    [SerializeField]
    protected int m_iLife;
    protected int m_iMaxLife;
    public Vector2 m_v2Pos;

    public abstract void action();

    public void removeLife(int life)
    {
        m_iLife -= life;
        if (m_iLife <= 0)
        {
            BattleManager.instance.ennemis.Remove(this);
            Destroy(gameObject);
        }
    }

    public void addLife(int life)
    {
        m_iLife += life;
        if (m_iLife > m_iMaxLife)
            m_iLife = m_iMaxLife;
    }

    protected virtual void Start()
    {
        updatePosition();
        m_iLife = m_iMaxLife;
    }
    
    public void move(Vector2 push)
    {
        Ennemi ennemi = BattleManager.instance.GetEnnemiAtPosition(m_v2Pos + push);
        if (!ennemi)
        {
            m_v2Pos += push;

            if (m_v2Pos.y < 0)
                m_v2Pos.y = 0;
            else if (m_v2Pos.y > 2)
                m_v2Pos.y = 2;

            if (m_v2Pos.x < 0)
                m_v2Pos.x = 0;
            else if (m_v2Pos.x > 2)
                m_v2Pos.x = 2;
        }
        updatePosition();
    }

    public int getLife() {
        return m_iLife;
    }

    public int getMaxLife()
    {
        return m_iMaxLife;
    }

    protected void updatePosition()
    {
        transform.position = new Vector3(1 + (3 * m_v2Pos.x), 0.5f, -1 + (-2.5f * m_v2Pos.y)) ;
    }
}
