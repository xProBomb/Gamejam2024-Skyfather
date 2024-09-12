using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public NavMeshSurface navMeshSurface;
    // Start is called before the first frame update
    void Start()
    {
        navMeshSurface.BuildNavMeshAsync();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
