using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public enum DrawMode { NoiseMap, ColourMap, TempMap, WtrMap, Moistmap };
    public DrawMode drawMode;
    public int mapWidth;
    public int mapHeight;

    public int seed;
    public int Tseed;
    public int Wtrseed;
    public int Moistseed;
    public int Erosionseed;
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

        public float MoistnoiseScale;
        public int Moistoctaves;
        [Range(0, 1)]
        public float Moistpersistance;
        public float Moistlacunarity;
        public Vector2 Moistoffset;

        public float ErosionnoiseScale;
        public int Erosionoctaves;
        [Range(0, 1)]
        public float Erosionpersistance;
        public float Erosionlacunarity;
        public Vector2 Erosionoffset;



    public TerrainType[] regions;

    
    public void GenerateMap()
    {

        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
        float[,] TempnoiseMap = Noise.GenerateTempMap(mapWidth, mapHeight, Tseed, TnoiseScale, Toctaves, Tpersistance, Tlacunarity, Toffset);
        float[,] WtrnoiseMap = Noise.GenerateWaterMap(mapWidth, mapHeight, Wtrseed, WtrnoiseScale, Wtroctaves, Wtrpersistance, Wtrlacunarity, Wtroffset);
        float[,] MoistnoiseMap = Noise.GenerateMoistureMap(mapWidth, mapHeight, Moistseed, MoistnoiseScale, Moistoctaves, Moistpersistance, Moistlacunarity, Moistoffset);
        float[,] ErosionnoiseMap = Noise.GenerateErosionMap(mapWidth, mapHeight, Erosionseed, ErosionnoiseScale, Erosionoctaves, Erosionpersistance, Erosionlacunarity, Erosionoffset);

        Color[] colourMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y]; 
                float currentTemp = TempnoiseMap[x, y];
                float currentWater = WtrnoiseMap[x, y];
                float currentMoist = MoistnoiseMap[x, y];
                float currentErosion = ErosionnoiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentTemp <= regions[i].temp & currentHeight <= regions[i].height & currentWater >= regions[i].water & currentErosion <= regions[i].erosion & currentMoist <= regions[i].moisture)
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
        else if (drawMode == DrawMode.Moistmap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(MoistnoiseMap));
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
    public float moisture;
    public float erosion;
    public Color colour;

}