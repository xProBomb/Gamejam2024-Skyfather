using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using TMPro.EditorUtilities;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    //instance of the grid manager

    public static GridManager Instance;

    [SerializeField] 
    private int _width;
    [SerializeField] 
    private int _height;

    [SerializeField]
    private Tile _tilePrefab;

    [SerializeField]
    private Transform _cam;

    [SerializeField]
    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Tile tile = Instantiate(_tilePrefab, new Vector3(x - _width/2, y - _height/2, 0), Quaternion.identity);
                tile.name = $"Tile {x}, {y}";
                tile.transform.SetParent(transform);

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                tile.Init(isOffset);
            }
        }
    }
}
