using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Canvas canvas;
    public List<GameObject> generetedButton = new List<GameObject>();
    private List<Button> generatedWeapon = new List<Button>();
    private Dictionary<Slider,Ennemi> generetedLifeBar = new Dictionary<Slider, Ennemi>();
    public Text displayTime;
    public Slider displayLife;
    public Button button;
    public Slider lifeBar;
    public Vector2 selectedPos;
    public Patern patern;
    private bool isSelected = false;

    //protection pour évité les instansations
    protected UIManager() { }

    private void Awake()
    {
        //désactivation du ciblage des ennemis car aucune capacité n'est enclanché
        displayTargeting(false, Patern.point);

        generateWeapon();
        generateLifeBar();

        displayLife.maxValue = InventoryManager.instance.m_iMaxLife;
    }

    private void Update()
    {
        displayTime.text = BattleManager.instance.getTime().ToString();
        displayLife.value = InventoryManager.instance.getLife();
        updateLifeBar();
    }

    public bool requestPosition()
    {
        if (isSelected)
        {
            isSelected = false;
            return true;
        }
        return false;
    }

    public void selectPos(Vector2 pos)
    {
        if (pos.x >= 0 && pos.x <= 2 && pos.y >= 0 && pos.y <= 2)
        {
            selectedPos = pos; 
            isSelected = true;
        }
    }

    public void displayTargeting(bool isActivate, Patern patern)
    {
        Vector2 pos;
        foreach (GameObject go in generetedButton)
        {
            go.SetActive(isActivate);
            go.GetComponent<CaseButton>().interactable = true;
        }
        if (isActivate) {
            List<Graphic> target; 
            foreach (GameObject go in generetedButton)
            {
                target = new List<Graphic>();
                target.Add(go.GetComponent<Graphic>());
                pos = go.GetComponent<SelectCaseButton>().pos;
                switch (patern)
                {
                    case Patern.point:
                        go.GetComponent<CaseButton>().setTargets(target);
                        break;

                    case Patern.line:
                        foreach (GameObject go2 in generetedButton)
                            if (go2.GetComponent<SelectCaseButton>().pos.y == pos.y)
                                target.Add(go2.GetComponent<Graphic>());
                        go.GetComponent<CaseButton>().setTargets(target);
                        break;

                    case Patern.column:
                        foreach (GameObject go2 in generetedButton)
                            if (go2.GetComponent<SelectCaseButton>().pos.x == pos.x)
                                target.Add(go2.GetComponent<Graphic>());
                        go.GetComponent<CaseButton>().setTargets(target);
                        break;

                    case Patern.cross:
                        foreach (GameObject go2 in generetedButton)
                        {
                            Vector2 pos2 = go2.GetComponent<SelectCaseButton>().pos;
                            if (((pos2.x == pos.x + 1 || pos2.x == pos.x - 1) && pos2.y == pos.y) || ((pos2.y == pos.y + 1 || pos2.y == pos.y - 1) && pos2.x == pos.x))
                                target.Add(go2.GetComponent<Graphic>());
                        }
                        go.GetComponent<CaseButton>().setTargets(target);
                        break;

                    case Patern.diagonalHtoL:
                        if (pos.x == pos.y)
                        {
                            target.Add(go.GetComponent<Graphic>());
                            foreach (GameObject go2 in generetedButton)
                            {
                                Vector2 pos2 = go2.GetComponent<SelectCaseButton>().pos;
                                if (pos2.x == pos2.y)
                                    target.Add(go2.GetComponent<Graphic>());
                            }
                            go.GetComponent<CaseButton>().setTargets(target);
                        }
                        else
                            go.GetComponent<CaseButton>().interactable = false;
                        break;

                    case Patern.diagonalLtoH:
                        if (pos.x + pos.y == 2)
                        {
                            target.Add(go.GetComponent<Graphic>());
                            foreach (GameObject go2 in generetedButton)
                            {
                                Vector2 pos2 = go2.GetComponent<SelectCaseButton>().pos;
                                if (pos2.x + pos2.y == 2)
                                    target.Add(go2.GetComponent<Graphic>());
                            }
                            go.GetComponent<CaseButton>().setTargets(target);
                        }
                        else
                            go.GetComponent<CaseButton>().interactable = false;
                        break;

                    case Patern.diagonal:
                        target.Add(go.GetComponent<Graphic>());
                        if (pos.x + pos.y == 2)
                        {
                            foreach (GameObject go2 in generetedButton)
                            {
                                Vector2 pos2 = go2.GetComponent<SelectCaseButton>().pos;
                                if (pos2.x + pos2.y == 2)
                                    target.Add(go2.GetComponent<Graphic>());
                            }
                            go.GetComponent<CaseButton>().setTargets(target);
                        }
                        else if (pos.x == pos.y)
                        {
                            foreach (GameObject go2 in generetedButton)
                            {
                                Vector2 pos2 = go2.GetComponent<SelectCaseButton>().pos;
                                if (pos2.x == pos2.y)
                                    target.Add(go2.GetComponent<Graphic>());
                            }
                            go.GetComponent<CaseButton>().setTargets(target);
                        }
                        else if (pos.y == 1)
                        {
                            foreach (GameObject go2 in generetedButton)
                            {
                                Vector2 pos2 = go2.GetComponent<SelectCaseButton>().pos;
                                if (pos2.y == 1)
                                    target.Add(go2.GetComponent<Graphic>());
                            }
                            go.GetComponent<CaseButton>().setTargets(target);
                        }
                        else
                            go.GetComponent<CaseButton>().interactable = false;

                        break;
                }
            }
        }
    }

    public void updateLifeBar()
    {
        foreach(Slider s in generetedLifeBar.Keys)
        {
            if(generetedLifeBar[s] == null)
            {
                generetedLifeBar.Remove(s);
                Destroy(s.gameObject);
                break;
            }
            s.transform.position = new Vector3(0, 50, 0) + Camera.main.WorldToScreenPoint(generetedLifeBar[s].transform.position);
            s.maxValue = generetedLifeBar[s].getMaxLife();
            s.value = generetedLifeBar[s].getLife();
        }
    }

    private void generateWeapon()
    {
        int i = 0;

        //pour chaque arme équipé
        foreach (GameObject w in InventoryManager.instance.weapons)
        {
            //génération d'un bouton qui as une copie de l'arme en enfant
            Button instance = Instantiate<Button>(button);
            GameObject weaponInstance = Instantiate<GameObject>(w);

            //gestion de la hièrachie des objets générés
            instance.gameObject.transform.SetParent(canvas.transform);
            weaponInstance.gameObject.transform.SetParent(instance.transform);

            //placement et paramètrage de l'arme
            instance.transform.position = new Vector3(150, 50 + i * 30, 0);
            instance.GetComponentInChildren<Text>().text = w.name;

            //ajout d'un listener qui va activé l'action de l'arme
            instance.onClick.AddListener(() => weaponInstance.GetComponent<Weapon>().action());

            //ajout de l'arme à une collection
            generatedWeapon.Add(instance);

            i++;
        }
    }

    private void generateLifeBar()
    {
        //pour chaque arme équipé
        foreach (Ennemi e in BattleManager.instance.ennemis)
        {
            //génération d'un bouton qui as une copie de la barre de vie en enfant
            Slider instance = Instantiate<Slider>(lifeBar);

            //gestion de la hièrachie des objets générés
            instance.gameObject.transform.SetParent(canvas.transform);

            //placement et paramètrage de la barre de vie
            instance.transform.position = new Vector3(0, 50, 0) + Camera.main.WorldToScreenPoint(e.transform.position);

            //définition des limites de la barre de vie
            instance.maxValue = e.getMaxLife();
            instance.value = e.getLife();

            //ajout des données de la barre de vie à une collection
            generetedLifeBar.Add(instance,e);
        }
    }
}
