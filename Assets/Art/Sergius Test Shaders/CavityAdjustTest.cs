using UnityEngine;

public class CavityAdjust : MonoBehaviour
{
    public Color baseColor = new Color(0.2f, 0.2f, 0.2f, 1f);
    public Color wireColor = new Color(1f, 0.5f, 0f, 1f);
    [Range(0, 10)] public float wireGlow = 2f;
    [Range(0.001f, 0.1f)] public float wireThickness = 0.02f;

    private Material wireframeMaterial;

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null) return;

        // Generate barycentric data for wireframe effect
        Mesh newMesh = GenerateBarycentricMesh(meshFilter.mesh);
        meshFilter.mesh = newMesh;

        // Assign material with wireframe shader
        wireframeMaterial = new Material(Shader.Find("Custom/TrueWireframeGlow"));
        GetComponent<Renderer>().material = wireframeMaterial;

        UpdateMaterialProperties();
    }

    void Update()
    {
        UpdateMaterialProperties();
    }

    void UpdateMaterialProperties()
    {
        if (wireframeMaterial == null) return;

        wireframeMaterial.SetColor("_BaseColor", baseColor);
        wireframeMaterial.SetColor("_WireColor", wireColor);
        wireframeMaterial.SetFloat("_WireGlow", wireGlow);
        wireframeMaterial.SetFloat("_WireThickness", wireThickness);
    }

    // Generate barycentric coordinates for the mesh
    Mesh GenerateBarycentricMesh(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;
        Vector3[] barycentricCoords = new Vector3[vertices.Length];

        // Assign unique barycentric coordinates per triangle
        for (int i = 0; i < triangles.Length; i += 3)
        {
            barycentricCoords[triangles[i]] = new Vector3(1, 0, 0);
            barycentricCoords[triangles[i + 1]] = new Vector3(0, 1, 0);
            barycentricCoords[triangles[i + 2]] = new Vector3(0, 0, 1);
        }

        // Create a new mesh with barycentric data
        Mesh newMesh = new Mesh();
        newMesh.vertices = vertices;
        newMesh.triangles = triangles;
        newMesh.normals = mesh.normals;
        newMesh.uv = mesh.uv;
        newMesh.SetUVs(1, barycentricCoords); // Store barycentric coordinates in UV1

        return newMesh;
    }
}