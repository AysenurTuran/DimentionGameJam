using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritechange : MonoBehaviour
{
    public Sprite basilmamissprite;

    private SpriteRenderer spritex;
    public Sprite basilmissprite;

    private BoxCollider2D boxCollider;


     
    public GameObject platformlar;

    Platform geciciplatform;

    void Start()
    {
        spritex = GetComponent<SpriteRenderer>();
        spritex.sprite = basilmamissprite;

        boxCollider = GetComponent<BoxCollider2D>();

        

    }

    public void Basildi()
    {
        
        spritex.sprite = basilmissprite;
        boxCollider.size = spritex.bounds.size/2;

        Platform gecicip = platformlar.GetComponent<Platform>();
        gecicip.Calistir();
        
    }
   
}
