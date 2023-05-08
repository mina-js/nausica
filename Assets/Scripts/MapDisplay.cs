using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
  public Renderer textureRenderer;
  public MeshFilter meshFilter;
  public MeshRenderer meshRenderer;

  public void DrawTexture(Texture2D texture)
  {
    int width = texture.width;
    int height = texture.height;

    textureRenderer.sharedMaterial.mainTexture = texture;
    textureRenderer.transform.localScale = new Vector3(width, 1, height);
  }

  public void DrawMesh(MeshData meshData, Texture2D texture)
  {
    meshFilter.sharedMesh = meshData.CreateMesh();
    meshRenderer.sharedMaterial.mainTexture = texture;
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
