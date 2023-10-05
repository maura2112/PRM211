using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [Header("Background Object")]
    [SerializeField] protected GameObject background;

    [Header("Background Scrolling")]
    [SerializeField] protected float scrollSpeed = 0.1f;
    [SerializeField] protected Material material;
    [SerializeField] protected Vector2 offSet = Vector2.zero;

    private void Start()
    {
        this.Scaler();
        this.getMaterialOffSet();
    }

    private void Update()
    {
        this.Scrolling();
    }
    protected void Reset()
    {
        this.LoadBackground();
        this.LoadMaterial();

    }
    protected virtual Transform getQuad()
    {
        return transform.parent.Find("Quad");
    }
    protected virtual void LoadBackground()
    {
        this.background = getQuad().gameObject;
    }
    protected virtual void Scaler()
    {
        var worldHeight = Camera.main.orthographicSize * 2f;
        var worldWidth = worldHeight * Screen.width / Screen.height;
        this.background.transform.localScale = new Vector3(worldWidth, worldHeight, 0f);
    }

    protected virtual void LoadMaterial()
    {
        this.material = getQuad().gameObject.GetComponent<MeshRenderer>().sharedMaterial;
    }

    protected virtual void getMaterialOffSet()
    {
        this.offSet = material.GetTextureOffset("_MainTex");
    }

    protected virtual void setMaterialOffSet()
    {
        material.SetTextureOffset("_MainTex", offSet);
    }

    protected void Scrolling()
    {
        offSet.y += scrollSpeed * Time.deltaTime;
        setMaterialOffSet();
    }

}
