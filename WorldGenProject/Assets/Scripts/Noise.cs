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

    public static float[,] GenerateMoistureMap(int mapWidth, int mapHeight, int Moistseed, float Moistscale, int Moistoctaves, float Moistpersistance, float Moistlacunarity, Vector2 Moistoffset)
    {
        float[,] MoistempnoiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(Moistseed);
        Vector2[] MoistoctaveOffsets = new Vector2[Moistoctaves];
        for (int i = 0; i < Moistoctaves; i++)
        {
            float MoistoffsetX = prng.Next(-10000, 10000) + Moistoffset.x;
            float MoistoffsetY = prng.Next(-10000, 10000) + Moistoffset.y;
            MoistoctaveOffsets[i] = new Vector2(MoistoffsetX, MoistoffsetY);
        }

        if (Moistscale <= 0)
        {
            Moistscale = 0.001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                float Moistamplitude = 1;
                float Moistfrequency = 1;
                float MoistnoiseHeight = 0;
                for (int i = 0; i < Moistoctaves; i++)
                {
                    float sampleX = (x - halfWidth) / Moistscale * Moistfrequency + MoistoctaveOffsets[i].x;
                    float sampleY = (y - halfHeight) / Moistscale * Moistfrequency + MoistoctaveOffsets[i].y;

                    float perinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    MoistnoiseHeight += perinValue * Moistamplitude;

                    Moistamplitude *= Moistpersistance;
                    Moistfrequency *= Moistlacunarity;

                }

                if (MoistnoiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = MoistnoiseHeight;
                }
                else if (MoistnoiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = MoistnoiseHeight;
                }

                MoistempnoiseMap[x, y] = MoistnoiseHeight;
            }
        }
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                MoistempnoiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, MoistempnoiseMap[x, y]);
            }
        }
        return MoistempnoiseMap;
    }

    public static float[,] GenerateErosionMap(int mapWidth, int mapHeight, int Erosionseed, float Erosionscale, int Erosionoctaves, float Erosionpersistance, float Erosionlacunarity, Vector2 Erosionoffset)
    {
        float[,] ErosionnoiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(Erosionseed);
        Vector2[] ErosionoctaveOffsets = new Vector2[Erosionoctaves];
        for (int i = 0; i < Erosionoctaves; i++)
        {
            float ErosionoffsetX = prng.Next(-10000, 10000) + Erosionoffset.x;
            float ErosionoffsetY = prng.Next(-10000, 10000) + Erosionoffset.y;
            ErosionoctaveOffsets[i] = new Vector2(ErosionoffsetX, ErosionoffsetY);
        }

        if (Erosionscale <= 0)
        {
            Erosionscale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                float Erosionamplitude = 1;
                float Erosionfrequency = 1;
                float ErosionnoiseHeight = 0;
                for (int i = 0; i < Erosionoctaves; i++)
                {
                    float sampleX = (x - halfWidth) / Erosionscale * Erosionfrequency + ErosionoctaveOffsets[i].x;
                    float sampleY = (y - halfHeight) / Erosionscale * Erosionfrequency + ErosionoctaveOffsets[i].y;

                    float perinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    ErosionnoiseHeight += perinValue * Erosionamplitude;

                    Erosionamplitude *= Erosionpersistance;
                    Erosionfrequency *= Erosionlacunarity;

                }

                if (ErosionnoiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = ErosionnoiseHeight;
                }
                else if (ErosionnoiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = ErosionnoiseHeight;
                }

                ErosionnoiseMap[x, y] = ErosionnoiseHeight;
            }
        }
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                ErosionnoiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, ErosionnoiseMap[x, y]);
            }
        }
        return ErosionnoiseMap;
    }






}

