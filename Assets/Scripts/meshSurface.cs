using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class meshSurface : MonoBehaviour
{
    public NavMeshSurface navSurface;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Mesh), 4);
        
        
    }

    // Update is called once per frame
  
     void Mesh()
    {
        navSurface.BuildNavMesh();

    }
}
