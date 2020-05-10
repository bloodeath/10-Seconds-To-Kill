using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCollection
{
    private List<Button> m_lWeapons = new List<Button>();

    public void UpdateWeapon()
    {
        foreach (Button w in m_lWeapons)
            w.interactable = (w.GetComponentInChildren<NewWeapon>().IsPossible());
    }

    public void GenerateWeapon(Button button) {
        int i = 0;

        //pour chaque arme équipé
        foreach (GameObject w in InventoryManager.instance.weapons)
        {
            //génération d'un bouton qui as une copie de l'arme en enfant
            Button instance = GameObject.Instantiate<Button>(button);
            GameObject weaponInstance = GameObject.Instantiate<GameObject>(w);

            //gestion de la hièrachie des objets générés
            instance.gameObject.transform.SetParent(UIManager.instance.canvas.transform);
            weaponInstance.gameObject.transform.SetParent(instance.transform);

            //placement et paramètrage de l'arme
            instance.transform.position = new Vector3(150, 50 + i * 40, 0);
            instance.GetComponentInChildren<Text>().text = w.name;

            //ajout d'un listener qui va activé l'action de l'arme
            instance.onClick.AddListener(() => weaponInstance.GetComponent<NewWeapon>().Action());

            //ajout de l'arme à une collection
            m_lWeapons.Add(instance);

            i++;
        }
    }
}
