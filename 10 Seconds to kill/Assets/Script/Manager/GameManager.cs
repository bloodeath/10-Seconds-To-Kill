using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Le gameManager à pour but de géré les information lié au points de vie du joueur, le temps, le ennemis et leur placement
    //du fait qu'il soit un manager, il est un singleton. | amélioration futur, le faire hérité d'une classe singleton
    public int pv;

    private void Start()
    {
        _instance = this;  
    }

    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                _instance = go.AddComponent<GameManager>();
                Debug.Log(_instance);
            }
            return _instance;
        }
    }
    //fin du comportement singleton

    //retire des points de vie
    public void removeLife(int lifetoremove)
    {
        pv -= lifetoremove;

        if (pv < 0)
            pv = 0;
    }
}
