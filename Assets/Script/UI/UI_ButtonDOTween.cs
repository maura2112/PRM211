using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_ButtonDOTween : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] protected GameObject UIPanel;
    [SerializeField] protected GameObject UIButton;
    private Transform panelTrf;
    private Transform buttonTrf;

    private void Start()
    {
        if (UIPanel != null)
        {
            panelTrf = this.UIPanel.transform;

        }
        if (UIButton != null)
        {
            buttonTrf = this.UIButton.transform;

        }
    }

    public void GamePause()
    { 
        this.transform.DOMoveY(transform.position.y + 150, .25f).SetEase(Ease.InBack).OnComplete(() =>
        {
            panelTrf.transform.DOScale(Vector3.one, 1f);
            panelTrf.DOMoveY(panelTrf.position.y - 250, .25f).SetEase(Ease.InBack);

        });
    }

    public void GameContinue()
    {
        panelTrf.DOScale(Vector3.zero, .5f).OnComplete(() =>
        {
            buttonTrf.transform.DOMoveY(buttonTrf.transform.position.y - 150, .5f).OnComplete(() =>
            {
                panelTrf.DOMoveY(panelTrf.position.y + 250, .25f);
            });
        });
    }

}
