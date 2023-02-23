using UnityEngine;
using Unity.Mathematics;
using System.Collections.Generic;

public sealed class Wave2 : MonoBehaviour
{
    const int N = 8;

    Mesh _mesh;
    List<Vector3> _vertices = new List<Vector3>();

    void UpdateVertices(float t)
    {
        _vertices.Clear();

        for (var row = 0; row < N; row++)
        {
            var z = math.remap(0, N - 1, -1, 1, row);

            for (var column = 0; column < N; column++)
            {
                var x = math.remap(0, N - 1, -1, 1, column);

                var d = Mathf.Sqrt(x * x + z * z);
                var y = Mathf.Sin(d * 10 - t * 3) * 0.05f;

                _vertices.Add(new Vector3(x, y, z));
            }
        }

        _mesh.SetVertices(_vertices);
    }

    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;

        UpdateVertices(0);

        var indices = new List<int>();

        // Row lines
        var index = 0;
        for (var row = 0; row < N; row++)
        {
            for (var column = 0; column < N - 1; column++)
            {
                indices.Add(index);
                indices.Add(index + 1);
                index++;
            }
            index++;
        }

        // Column lines
        index = 0;
        for (var row = 0; row < N - 1; row++)
        {
            for (var column = 0; column < N; column++)
            {
                indices.Add(index);
                indices.Add(index + N);
                index++;
            }
        }

        _mesh.SetIndices(indices, MeshTopology.Lines, 0);
    }

    void Update()
      => UpdateVertices(Time.time);

    void OnDestroy()
      => Destroy(_mesh);
}
