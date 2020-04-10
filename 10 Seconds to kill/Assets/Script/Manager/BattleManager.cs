using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    protected BattleManager() { }

    private int time = 10;
    public List<Ennemi> ennemis;
    private float temptime;

    private void Update()
    {
        // le tempTime est là pour évité d'utilisé des vrai seconde est le remplacé par un temps "ralenti"
        // Amélioration : ajouté un paramètre permettant de changé le temps réel neccesaire pour faire passé une seconde dans le jeu
        if (temptime > 2)
        {
            time--;
            temptime = 0;
        }
        temptime += Time.deltaTime;
        if (time <= 0)
        {
            turnEnnemi();
            time = 10;
        }
    }

    //acceseur permetant de récupéré l'ennemi à une position
    public Ennemi GetEnnemiAtPosition(Vector2 pos)
    {
        foreach (Ennemi e in ennemis)
            if (e.m_v2Pos == pos)
                return e;

        return null;
    }

    //lance le tour des ennemis 
    public void turnEnnemi()
    {
        foreach (Ennemi e in ennemis)
            e.action();
    }

    //retire un nombre de seconde
    public bool removeTime(int timetoremove)
    {
        if (time < timetoremove)
            return false;

        time -= timetoremove;
        return true;
    }

    public int getTime()
    {
        return time;
    }

}
