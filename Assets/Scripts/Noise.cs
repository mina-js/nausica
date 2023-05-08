using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
  public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistence, float lacunarity, Vector2 offset)
  {
    float[,] noiseMap = new float[mapWidth, mapHeight];

    System.Random prng = new System.Random(seed);
    Vector2[] octaveOffsets = new Vector2[octaves];

    for (int i = 0; i < octaves; i++)
    {
      float offsetX = prng.Next(-100000, 100000) + offset.x; //this range is specific to the tutorial
      float offsetY = prng.Next(-100000, 100000) + offset.y;

      octaveOffsets[i] = new Vector2(offsetX, offsetY);
    }

    float maxNoiseHeight = float.MinValue;
    float minNoiseHeight = float.MaxValue;

    if (scale <= 0) scale = 0.0001f;

    float halfWidth = mapWidth / 2f;
    float halfHeight = mapHeight / 2f;


    for (int y = 0; y < mapHeight; y++)
    {
      for (int x = 0; x < mapWidth; x++)
      {

        float amplitude = 1f;
        float frequency = 1f;

        float noiseHeight = 0f;

        for (int i = 0; i < octaves; i++)
        {
          float sampleX = (x - halfWidth) / scale * frequency + octaveOffsets[i].x;
          float sampleY = (y - halfHeight) / scale * frequency + octaveOffsets[i].y;

          float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1; //this lil number gives it range -1 to 1 instead of 0 to 1
          noiseHeight += perlinValue * amplitude;
          amplitude *= persistence;
          frequency *= lacunarity; //frequency increases each octave

          if (noiseHeight > maxNoiseHeight)
          {
            maxNoiseHeight = noiseHeight;
          }
          else if (noiseHeight < minNoiseHeight)
          {
            minNoiseHeight = noiseHeight;
          }

          noiseMap[x, y] = noiseHeight;
        }

      }
    }

    for (int y = 0; y < mapHeight; y++)
    {
      for (int x = 0; x < mapWidth; x++)
      {
        noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]); //this is for normalizing it
      }
    }

    return noiseMap;
  }
}
