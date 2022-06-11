using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public enum DrawMode { NoiseMap, ColourMap, TempMap, WtrMap };
    public DrawMode drawMode;
    public int mapWidth;
    public int mapHeight;

    public int seed;
    public int Tseed;
    public int Wtrseed;
    public bool autoUpdate;

        public float noiseScale;
        public int octaves;
        [Range(0, 1)]
        public float persistance;
        public float lacunarity;
        public Vector2 offset;
   
        public float TnoiseScale;
        public int Toctaves;
        [Range(0, 1)]
        public float Tpersistance;
        public float Tlacunarity;
        public Vector2 Toffset;

        public float WtrnoiseScale;
        public int Wtroctaves;
        [Range(0, 1)]
        public float Wtrpersistance;
        public float Wtrlacunarity;
        public Vector2 Wtroffset;



    public TerrainType[] regions;

    
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
        float[,] TempnoiseMap = Noise.GenerateTempMap(mapWidth, mapHeight, Tseed, TnoiseScale, Toctaves, Tpersistance, Tlacunarity, Toffset);
        float[,] WtrnoiseMap = Noise.GenerateWaterMap(mapWidth, mapHeight, Wtrseed, WtrnoiseScale, Wtroctaves, Wtrpersistance, Wtrlacunarity, Wtroffset);
        


        Color[] colourMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y]; 
                float currentTemp = TempnoiseMap[x, y];
                float currentWater = WtrnoiseMap[x, y];
               /// float biome = currentHeight * currentTemp;
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentTemp <= regions[i].temp & currentHeight <= regions[i].height & currentWater >= regions[i].water)
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
        }else if (drawMode == DrawMode.WtrMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(WtrnoiseMap));
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
    public float water;
    public Color colour;

}