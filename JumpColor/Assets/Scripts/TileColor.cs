using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileColor : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Color _defaultColor;
    [field: SerializeField] public Color _anotherColor;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (layerMaskUtil.layerMaskContainsLayer(groundLayerMask,collision.gameObject.layer))
        {
            ColorTitle(collision.gameObject.GetComponent<SpriteRenderer>());
        }
    }

    private void ColorTitle(SpriteRenderer spriteRenderer)
    {
        if (spriteRenderer.color == _defaultColor)
        {
            spriteRenderer.color = _anotherColor;
        }
        else
        {
            spriteRenderer.color = _defaultColor;
        }
    }
}
