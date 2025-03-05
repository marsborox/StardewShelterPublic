using UnityEngine;

public class MaterialSource : MonoBehaviour
{

    [SerializeField] public SO_GatheringMaterial resourceSO;
    
    string name;
    [SerializeField] MaterialSource_MiniSprite miniSprite0;
    [SerializeField] MaterialSource_MiniSprite miniSprite1;
    [SerializeField] MaterialSource_MiniSprite miniSprite2;
    [SerializeField] MaterialSource_MiniSprite miniSprite3;
    [SerializeField] MaterialSource_MiniSprite miniSprite4;
    [SerializeField] MaterialSource_MiniSprite miniSprite5;

    
    public void Start() 
    {   
        
        //SetMiniPictures(resourceSO.resource.itemIconNoBackground);
        SetMiniPictures();
    }
    public void SetName(string professionType)
    {
        name = resourceSO.name + professionType;
    }
    void SetMiniPictures(Sprite sprite)
    {
        if (resourceSO == null)
        {
            Debug.Log("materialSource.resourceSO is null");
        }
        if (resourceSO.resource == null)
        {
            Debug.Log("materialSource.resourceSO.resource is null");
        }
        if (resourceSO.resource.itemIconNoBackground == null)
        {
            Debug.Log("materialSource.resourceSO.resource.itemIconNoBackground is null");
        }
        else Debug.Log("materialSource.resourceSO.resource.itemIconNoBackground is NOT null");

        miniSprite0.spriteRenderer.sprite = sprite;
        miniSprite1.spriteRenderer.sprite = sprite;
        miniSprite2.spriteRenderer.sprite = sprite;
        miniSprite3.spriteRenderer.sprite = sprite;
        miniSprite4.spriteRenderer.sprite = sprite;
        miniSprite5.spriteRenderer.sprite = sprite;

    }

    public void SetMiniPictures()
    {//must be better way to do this
        miniSprite0.spriteRenderer.sprite = resourceSO.resource.itemIconNoBackground;
        miniSprite1.spriteRenderer.sprite = resourceSO.resource.itemIconNoBackground;
        miniSprite2.spriteRenderer.sprite = resourceSO.resource.itemIconNoBackground;
        miniSprite3.spriteRenderer.sprite = resourceSO.resource.itemIconNoBackground;
        miniSprite4.spriteRenderer.sprite = resourceSO.resource.itemIconNoBackground;
        miniSprite5.spriteRenderer.sprite = resourceSO.resource.itemIconNoBackground;
    }
    public void GatherResource(GameObject hero) 
    {
        hero.GetComponent<BackPack>().AddItemToBackPack(resourceSO.resource, resourceSO.ammount);
        Destroy(gameObject);
    }
    public virtual void Deactivate()
    { }

}
