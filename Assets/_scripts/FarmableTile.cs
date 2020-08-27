using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileState { Dry, Tilled, Wet }
public class FarmableTile : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    public TileState tileState = TileState.Dry;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TillTile()
    {
        spriteRenderer.sprite = sprites[1];
        tileState = TileState.Tilled;
    }

    public void WaterTile()
    {
        if(tileState == TileState.Tilled)
        {
            spriteRenderer.sprite = sprites[2];
            tileState = TileState.Wet;
        }
    }
}