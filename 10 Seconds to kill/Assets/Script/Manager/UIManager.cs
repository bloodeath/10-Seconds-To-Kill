using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Canvas canvas;

    private WeaponCollection m_wcWeaponCollection;
    private LifeBarCollection m_lcLifeBarCollection;
    public TargetingCollection m_tcTargetingCollection;

    public Bar displayTime;
    public Bar displayLife;
    public Bar lifeBar;
    public Button button;
    public GameObject m_goInterfacePrefab;

    private Vector2 m_v2SelectedPos;

    private bool m_bIsSelected = false;

    //protection pour évité les instansations
    protected UIManager() { }

    private void Awake()
    {

        //Création des collections pour nos éléments d'UI
        m_wcWeaponCollection = new WeaponCollection();
        m_lcLifeBarCollection = new LifeBarCollection();
        m_tcTargetingCollection = new TargetingCollection(m_goInterfacePrefab);

        m_wcWeaponCollection.GenerateWeapon(button);
        m_lcLifeBarCollection.GenerateLifeBar(lifeBar);
        m_tcTargetingCollection.DisplayTargeting(false, Patern.none);

        displayLife.Max = InventoryManager.instance.m_iMaxLife;
    }

    private void Update()
    {
        displayTime.Value = BattleManager.instance.getTime() - (BattleManager.instance.getTempTime()/2.0f);
        displayLife.Value = InventoryManager.instance.getLife();
        m_wcWeaponCollection.UpdateWeapon();
        m_lcLifeBarCollection.UpdateLifeBar();
    }

    public bool requestPosition()
    {
        if (m_bIsSelected)
        {
            m_bIsSelected = false;
            return true;
        }
        return false;
    }

    public void selectPos(Vector2 pos)
    {
        if (pos.x >= 0 && pos.x <= 2 && pos.y >= 0 && pos.y <= 2)
        {
            m_v2SelectedPos = pos;
            m_bIsSelected = true;
        }
    }

    public Vector2 getPos()
    {
        return m_v2SelectedPos;
    }
}
