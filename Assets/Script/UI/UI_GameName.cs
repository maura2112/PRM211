using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameName : MonoBehaviour
{

    [Header("Color")]
    [SerializeField] protected Color borderColor;
    [SerializeField] protected Color textColor;

    //Border color hex: FEFF77
    //Text color hex: 6E00C0
    void Start()
    {
        this.Appearing();    }

    protected virtual void Appearing()
    {
        this.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            this.transform.GetComponent<Text>().DOColor(borderColor, 3f);
            this.transform.Find("Text").GetComponent<Text>().DOColor(textColor, 3f);
            this.transform.DOMoveY(transform.position.y + 775, 2f).SetEase(Ease.InBack).OnComplete(() =>
            {
                this.transform.DOScale(new Vector3(1.2f,1.2f,1.2f), 1f).SetLoops(-1, LoopType.Yoyo);
            });
            
        });
    }

}
