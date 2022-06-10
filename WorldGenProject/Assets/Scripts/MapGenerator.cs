using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public enum DrawMode { NoiseMap, ColourMap, TempMap };
    public DrawMode drawMode;
    public int mapWidth;
    public int mapHeight;


    public float noiseScale;
    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;

    public float TnoiseScale;
    public int Toctaves;
    [Range(0, 1)]
    public float Tpersistance;
    public float Tlacunarity;
    public int Tseed;
    public Vector2 Toffset;






    public bool autoUpdate;





    [NonReorderable]
    public TerrainType[] regions;


    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
        float[,] TempnoiseMap = Noise.GenerateTempMap(mapWidth, mapHeight, Tseed, TnoiseScale, Toctaves, Tpersistance, Tlacunarity, Toffset);

        Color[] colourMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y]; 
                float currentTemp = TempnoiseMap[x, y] * 2f;
               /// float biome = currentHeight * currentTemp;
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentTemp <= regions[i].temp & currentHeight <= regions[i].height )
                    {
                        colourMap[y * mapWidth + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }
   

    MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.TempMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(TempnoiseMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
    display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
           }
    }

    void OnValidate()
{
    if (mapWidth < 1)
    {
        mapWidth = 1;
    }
    if (mapHeight < 1)
    {
        mapHeight = 1;
    }
    if (lacunarity < 1)
    {
        lacunarity = 1;
    }
    if (octaves < 0)
    {
        octaves = 0;
    }
}

}
[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public float temp;
    public Color colour;

}