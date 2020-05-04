using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetingCollection
{
    private List<GameObject> m_lButtons = new List<GameObject>();

    public TargetingCollection(GameObject buttons)
    {
        GameObject instance = GameObject.Instantiate(buttons);
        instance.transform.SetParent(UIManager.instance.canvas.transform);
        for(int i = 0; i < instance.transform.childCount; i++)
            m_lButtons.Add(instance.transform.GetChild(i).gameObject);
    }

    public void DisplayTargeting(bool isActivate, Patern patern) {
        Vector2 pos;
        foreach (GameObject go in m_lButtons)
        {
            go.SetActive(isActivate);
            go.GetComponent<CaseButton>().interactable = true;
        }

        if (isActivate)
        {
            List<Graphic> target;
            foreach (GameObject go in m_lButtons)
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
                        foreach (GameObject go2 in m_lButtons)
                            if (go2.GetComponent<SelectCaseButton>().pos.y == pos.y)
                                target.Add(go2.GetComponent<Graphic>());
                        go.GetComponent<CaseButton>().setTargets(target);
                        break;

                    case Patern.column:
                        foreach (GameObject go2 in m_lButtons)
                            if (go2.GetComponent<SelectCaseButton>().pos.x == pos.x)
                                target.Add(go2.GetComponent<Graphic>());
                        go.GetComponent<CaseButton>().setTargets(target);
                        break;

                    case Patern.cross:
                        foreach (GameObject go2 in m_lButtons)
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
                            foreach (GameObject go2 in m_lButtons)
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
                            foreach (GameObject go2 in m_lButtons)
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
                            foreach (GameObject go2 in m_lButtons)
                            {
                                Vector2 pos2 = go2.GetComponent<SelectCaseButton>().pos;
                                if (pos2.x + pos2.y == 2)
                                    target.Add(go2.GetComponent<Graphic>());
                            }
                            go.GetComponent<CaseButton>().setTargets(target);
                        }
                        else if (pos.x == pos.y)
                        {
                            foreach (GameObject go2 in m_lButtons)
                            {
                                Vector2 pos2 = go2.GetComponent<SelectCaseButton>().pos;
                                if (pos2.x == pos2.y)
                                    target.Add(go2.GetComponent<Graphic>());
                            }
                            go.GetComponent<CaseButton>().setTargets(target);
                        }
                        else if (pos.y == 1)
                        {
                            foreach (GameObject go2 in m_lButtons)
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
}
