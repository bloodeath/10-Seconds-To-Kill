using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static object m_oLock = new object();
    private static T m_tInstance;
    private static bool m_bShuttingDown = false;

    public static T instance
    {
        get
        {
            if (m_bShuttingDown)
                return null;
            lock (m_oLock)
            {

                if (m_tInstance == null)
                {
                    m_tInstance = (T)FindObjectOfType(typeof(T));

                    if (m_tInstance == null)
                    {
                        GameObject go = new GameObject();
                        m_tInstance = go.AddComponent<T>();
                        go.name = typeof(T).ToString() + " (Singleton)";

                        DontDestroyOnLoad(go);
                    }
                }
                return m_tInstance;
            }
        }
    }

    private void OnApplicationQuit()
    {
        m_bShuttingDown = true;
    }

    private void OnDestroy()
    {
        m_bShuttingDown = true;
    }

    public static void Activate()
    {
        m_bShuttingDown = false;
    }
}
