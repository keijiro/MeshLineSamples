using UnityEngine;
using System.Collections.Generic;

public sealed class Wave : MonoBehaviour
{
    const int N = 21;

    List<Vector3> _vertices;
    List<int> _indices;
    Mesh _mesh;

    void Start()
    {
        _vertices = new List<Vector3>();
        _indices = new List<int>();

        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
    }

    void Update()
    {
        var t = Time.time;

        _vertices.Clear();
        for (var row = 0; row < N; row++)
        {
            var z = (row - (N - 1) * 0.5f) / N;
            for (var col = 0; col < N; col++)
            {
                var x = (col - (N - 1) * 0.5f) / N;
                var y = Mathf.Sin(Mathf.Sqrt(x * x + z * z) * 20 - t * 3) * 0.05f;
                _vertices.Add(new Vector3(x, y, z));
            }
        }

        _indices.Clear();
        var index = 0;
        for (var row = 0; row < N; row++)
        {
            for (var col = 0; col < N - 1; col++)
            {
                _indices.Add(index);
                _indices.Add(index + 1);
                index++;
            }
            index++;
        }

        index = 0;
        for (var row = 0; row < N - 1; row++)
        {
            for (var col = 0; col < N; col++)
            {
                _indices.Add(index);
                _indices.Add(index + N);
                index++;
            }
        }

        _mesh.SetVertices(_vertices);
        _mesh.SetIndices(_indices, MeshTopology.Lines, 0);
    }
}
