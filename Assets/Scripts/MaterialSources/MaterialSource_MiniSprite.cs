using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSource_MiniSprite : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteRenderer;

    public void SetSprite(Sprite insertedSprite)
    {
        spriteRenderer.sprite = insertedSprite;
    }


}
