using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class MapBake : MonoBehaviour
{
    private NavMeshSurface[] surfaces;

    void Start()
    {
        surfaces = GetComponents<NavMeshSurface>();
        foreach (NavMeshSurface surface in surfaces)
        {
            surface.BuildNavMesh();
        }
    }
}
