using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBarCollection
{
    private Dictionary<Bar, Ennemi> m_dLifeBars = new Dictionary<Bar, Ennemi>();

    public void UpdateLifeBar()
    {
        foreach (Bar s in m_dLifeBars.Keys)
        {
            if (m_dLifeBars[s] == null)
            {
                m_dLifeBars.Remove(s);
                GameObject.Destroy(s.gameObject);
                break;
            }
            s.transform.position = new Vector3(0, 50, 0) + Camera.main.WorldToScreenPoint(m_dLifeBars[s].transform.position);
            s.Max = m_dLifeBars[s].getMaxLife();
            s.Value = m_dLifeBars[s].getLife();
        }
    }

    public void GenerateLifeBar(Bar lifeBar)
    {
        //pour chaque arme équipé
        foreach (Ennemi e in BattleManager.instance.ennemis)
        {
            //génération d'un bouton qui as une copie de la barre de vie en enfant
            Bar instance = GameObject.Instantiate<Bar>(lifeBar);

            //gestion de la hièrachie des objets générés
            instance.gameObject.transform.SetParent(UIManager.instance.canvas.transform);

            //placement et paramètrage de la barre de vie
            instance.transform.position = Camera.main.WorldToScreenPoint(e.transform.position);

            //définition des limites de la barre de vie
            instance.Max = e.getMaxLife();
            instance.Value = e.getLife();

            //ajout des données de la barre de vie à une collection
            m_dLifeBars.Add(instance, e);
        }
    }
}

