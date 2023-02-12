using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class PerlinNoiseIslands : MonoBehaviour
{

    public static int[,] islandNoise(int mapWidth, int mapHeight, float modifier)
    {
        float[,] perlinSample = calcNoise(mapWidth, mapHeight, modifier);

        int[,] islandNoiseArray = new int[perlinSample.GetLength(0),perlinSample.GetLength(1)];


        for (int i = 0; i < perlinSample.GetLength(0); i++)
        {
            for (int j = 0; j < perlinSample.GetLength(1); j++)
            {
                if (perlinSample[i,j] > .6)
                {
                    islandNoiseArray[i,j] = 1;
                } 
                else
                {
                    islandNoiseArray[i,j] = 0;
                }
            }
        }
        return islandNoiseArray;
    }
    private static float[,] calcNoise(int mapWidth, int mapHeight, float modifier)
    {
        double Seed = UnityEngine.Random.Range(-100000, 100000);

        float[,] noiseArray = new float[mapHeight,mapWidth];
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                noiseArray[i,j] = Mathf.PerlinNoise((float) ((i*modifier) + Seed), (float)((j*modifier) + Seed));
            }
        }
        return noiseArray;
    }
}
