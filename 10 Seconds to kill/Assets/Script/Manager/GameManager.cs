using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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



}
