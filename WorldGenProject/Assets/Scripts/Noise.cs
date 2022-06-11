using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Noise
{
    
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-10000,10000) + offset.x;
            float offsetY = prng.Next(-10000,10000)+ offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;
                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (x-halfWidth) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y-halfHeight) / scale * frequency + octaveOffsets[i].y;

                    float perinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;

                }

                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[x,y] = noiseHeight;
            }
        }
        for (int y = 0; y < mapHeight; y++){
                for (int x = 0; x < mapWidth; x++)
                {
                    noiseMap[x,y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x,y]);
                }
        }
        return noiseMap;
    }


    public static float[,] GenerateTempMap(int mapWidth, int mapHeight, int Tseed, float Tscale, int Toctaves, float Tpersistance, float Tlacunarity, Vector2 Toffset)
    {
        float[,] TempnoiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(Tseed);
        Vector2[] ToctaveOffsets = new Vector2[Toctaves];
        for (int i = 0; i < Toctaves; i++)
        {
            float ToffsetX = prng.Next(-10000, 10000) + Toffset.x;
            float ToffsetY = prng.Next(-10000, 10000) + Toffset.y;
            ToctaveOffsets[i] = new Vector2(ToffsetX, ToffsetY);
        }

        if (Tscale <= 0)
        {
            Tscale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                float Tamplitude = 1;
                float Tfrequency = 1;
                float TnoiseHeight = 0;
                for (int i = 0; i < Toctaves; i++)
                {
                    float sampleX = (x - halfWidth) / Tscale * Tfrequency + ToctaveOffsets[i].x;
                    float sampleY = (y - halfHeight) / Tscale * Tfrequency + ToctaveOffsets[i].y;

                    float perinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    TnoiseHeight += perinValue * Tamplitude;

                    Tamplitude *= Tpersistance;
                    Tfrequency *= Tlacunarity;

                }

                if (TnoiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = TnoiseHeight;
                }
                else if (TnoiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = TnoiseHeight;
                }

                TempnoiseMap[x, y] = TnoiseHeight;
            }
        }
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                TempnoiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, TempnoiseMap[x, y]);
            }
        }
        return TempnoiseMap;
    }

    public static float[,] GenerateWaterMap(int mapWidth, int mapHeight, int Wtrseed, float Wtrscale, int Wtroctaves, float Wtrpersistance, float Wtrlacunarity, Vector2 Wtroffset)
    {
        float[,] WtrempnoiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(Wtrseed);
        Vector2[] WtroctaveOffsets = new Vector2[Wtroctaves];
        for (int i = 0; i < Wtroctaves; i++)
        {
            float WtroffsetX = prng.Next(-10000, 10000) + Wtroffset.x;
            float WtroffsetY = prng.Next(-10000, 10000) + Wtroffset.y;
            WtroctaveOffsets[i] = new Vector2(WtroffsetX, WtroffsetY);
        }

        if (Wtrscale <= 0)
        {
            Wtrscale = 0.001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                float Wtramplitude = 1;
                float Wtrfrequency = 1;
                float WtrnoiseHeight = 0;
                for (int i = 0; i < Wtroctaves; i++)
                {
                    float sampleX = (x - halfWidth) / Wtrscale * Wtrfrequency + WtroctaveOffsets[i].x;
                    float sampleY = (y - halfHeight) / Wtrscale * Wtrfrequency + WtroctaveOffsets[i].y;

                    float perinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    WtrnoiseHeight += perinValue * Wtramplitude;

                    Wtramplitude *= Wtrpersistance;
                    Wtrfrequency *= Wtrlacunarity;

                }

                if (WtrnoiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = WtrnoiseHeight;
                }
                else if (WtrnoiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = WtrnoiseHeight;
                }

                WtrempnoiseMap[x, y] = WtrnoiseHeight;
            }
        }
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                WtrempnoiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, WtrempnoiseMap[x, y]);
            }
        }
        return WtrempnoiseMap;
    }

}

