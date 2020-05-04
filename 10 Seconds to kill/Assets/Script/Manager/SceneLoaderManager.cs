using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : Singleton<SceneLoaderManager>
{
    protected SceneLoaderManager() { }

    private string m_sCurrentLevelName = string.Empty;
    private List<AsyncOperation> m_lLoadOperations = new List<AsyncOperation>();

    public void LoadLevel(string levelName)
    {
        if (!Application.CanStreamedLevelBeLoaded(levelName))
        {
            Debug.Log("level doesn't exist");
            return;
        }

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        ao.completed += OnLoadOperationComplete;

        m_lLoadOperations.Add(ao);

        m_sCurrentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        if (SceneManager.GetSceneByName(levelName).name == null)
        {
            Debug.Log("Level doesn't load");
            return;
        }

        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        ao.completed += OnUnloadOperationComplete;
        
        m_lLoadOperations.Add(ao);

        m_sCurrentLevelName = levelName;
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (m_lLoadOperations.Contains(ao))
            m_lLoadOperations.Remove(ao);
        Debug.Log("level load");
    }
    private void OnUnloadOperationComplete(AsyncOperation ao)
    {
        if (m_lLoadOperations.Contains(ao))
            m_lLoadOperations.Remove(ao);
        Debug.Log("level unload");
    }
}
