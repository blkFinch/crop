using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileState { Dry, Tilled, Wet }
public class FarmableTile : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    public TileState tileState = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TillTile()
    {
        spriteRenderer.sprite = sprites[1];
    }
}