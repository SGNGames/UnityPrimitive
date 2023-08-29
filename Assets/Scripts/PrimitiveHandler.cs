using System;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveHandler : MonoBehaviour
{
    [SerializeField] private Material cubeMaterial;
    
    private void Start()
    {
        CreatePrimitive();
    }

    private void CreatePrimitive()
    {
        var cubeGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeGO.GetComponent<MeshRenderer>().material = cubeMaterial;
        var mesh = cubeGO.GetComponent<MeshFilter>().sharedMesh;
        mesh.uv = GetMeshUV().ToArray();
        mesh.RecalculateNormals();
    }

    private List<Vector2> GetMeshUV()
    {
        var retutnValue = new List<Vector2>();

        for (var i = 0; i < Enum.GetValues(typeof(Direction)).Length; i++)
        {
            retutnValue.AddRange(GetFaceUV((Direction)i));
        }

        return retutnValue;
    }

    private List<Vector2> GetFaceUV(Direction direction)
    {
        var returnValue = new List<Vector2>();

        switch (direction)
        {
            case Direction.Front:
                returnValue.Add(new Vector2(0, 0));
                returnValue.Add(new Vector2(1, 0));
                returnValue.Add(new Vector2(0, 1));
                returnValue.Add(new Vector2(1, 1));
                break;
            case Direction.Up:
                returnValue.Add(new Vector2(0, 0)); // Up vertex 2
                returnValue.Add(new Vector2(1, 0)); // Up vertex 3
                returnValue.Add(new Vector2(0, 0)); // Back vertex 2
                returnValue.Add(new Vector2(1, 0)); // Back vertex 3
                break;
            case Direction.Back:
                returnValue.Add(new Vector2(0, 1)); // Up vertex 0
                returnValue.Add(new Vector2(1, 1)); // Up vertex 1
                returnValue.Add(new Vector2(0, 1)); // Back vertex 0
                returnValue.Add(new Vector2(1, 1)); // Back vertex 1
                break;
            case Direction.Down:
                returnValue.Add(new Vector2(0, 0));
                returnValue.Add(new Vector2(0, 1));
                returnValue.Add(new Vector2(1, 1));
                returnValue.Add(new Vector2(1, 0));
                break;
            case Direction.Left:
                returnValue.Add(new Vector2(0, 0));
                returnValue.Add(new Vector2(0, 1));
                returnValue.Add(new Vector2(1, 1));
                returnValue.Add(new Vector2(1, 0));
                break;
            case Direction.Right:
                returnValue.Add(new Vector2(0, 0));
                returnValue.Add(new Vector2(0, 1));
                returnValue.Add(new Vector2(1, 1));
                returnValue.Add(new Vector2(1, 0));
                break;
        }

        return returnValue;
    }
}