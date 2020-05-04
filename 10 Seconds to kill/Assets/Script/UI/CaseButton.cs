using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(Collider2D))]
public class CaseButton : Button, ICanvasRaycastFilter
{
    private Collider2D m_cCollider;
    private RectTransform m_rtRectTransform;
    private List<Graphic> m_gGraphics = new List<Graphic>();
    protected List<Graphic> graphics
    {
        get
        {
            if (m_gGraphics == null)
            {
                m_gGraphics.Add(GetComponent<Graphic>());
            }
            return m_gGraphics;
        }
    }

    protected override void Awake()
    {
        m_cCollider = GetComponent<Collider2D>();
        m_rtRectTransform = GetComponent<RectTransform>();
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        Color color;

        switch (state)
        {
            case Selectable.SelectionState.Normal:
                color = this.colors.normalColor;
                break;
            case Selectable.SelectionState.Highlighted:
                color = this.colors.highlightedColor;
                break;
            case Selectable.SelectionState.Pressed:
                color = this.colors.pressedColor;
                break;
            case Selectable.SelectionState.Disabled:
                color = this.colors.disabledColor;
                break;
            default:
                color = Color.black;
                break;
        }
        if (base.gameObject.activeInHierarchy)
        {
            switch (this.transition)
            {
                case Selectable.Transition.ColorTint:
                    colorTween(color * this.colors.colorMultiplier, instant);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        base.DoStateTransition(state, instant);
    }

    public void setTargets(List<Graphic> graphics)
    {
        m_gGraphics = graphics;
    }

    public void resetTarget()
    {
        m_gGraphics.Clear();
    }

    private void colorTween(Color targetColor, bool instant)
    {
        if (this.targetGraphic == null)
            return;
        foreach (Graphic g in this.graphics)
            g.CrossFadeColor(targetColor, (instant) ? 0f : this.colors.fadeDuration, true, true);
    }

    #region ICanvasRaycastFilter implementation
    public bool IsRaycastLocationValid(Vector2 screenPos, Camera eventCamera)
    {
        var worldPoint = Vector3.zero;
        var isInside = RectTransformUtility.ScreenPointToWorldPointInRectangle(
            m_rtRectTransform,
            screenPos,
            eventCamera,
            out worldPoint
        );
        if (isInside)
            isInside = m_cCollider.OverlapPoint(worldPoint);
        return isInside;
    }
    #endregion
}
