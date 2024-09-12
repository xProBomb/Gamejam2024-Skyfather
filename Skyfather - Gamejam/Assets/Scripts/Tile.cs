using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine.AI;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Color _baseColor;
    [SerializeField]
    private Color _offsetColor;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private GameObject _tileHighlight;

    [SerializeField]
    private GameObject _wall;

    public void Init(bool isOffset)
    {
        _spriteRenderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        _tileHighlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _tileHighlight.SetActive(false);
    }

    void OnMouseDown()
    {
        Instantiate(_wall, transform.position, Quaternion.identity, transform);
    }
}
