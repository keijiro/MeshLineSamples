using UnityEngine;

public sealed class Triangle : MonoBehaviour
{
    void Start()
    {
        var mesh = new Mesh();

        var vertices = new [] { new Vector3(0, 0, 0),
                                new Vector3(1, 0, 0),
                                new Vector3(0, 1, 0) };
        mesh.SetVertices(vertices);

        var indices = new [] { 0, 1,   1, 2,   2, 0 };
        mesh.SetIndices(indices, MeshTopology.Lines, 0);

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
