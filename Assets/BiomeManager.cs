using System.Collections.Generic;
using UnityEngine;

public class BiomeManager : MonoBehaviour
{
    public List<GameObject> biomes;

    private GameObject currentBiome;

    void Start()
    {
        // Initialize the current biome (assuming player starts in the lava biome)
        TeleportToBiome(0);
    }

    public void SwitchBiome(GameObject newBiome)
    {
        if (currentBiome != null)
        {
            currentBiome.SetActive(false);
        }

        currentBiome = newBiome;
        currentBiome.SetActive(true);
    }

    public void TeleportToBiome(int biomeIndex)
    {
        foreach (GameObject biome in biomes)
        {
            biome.SetActive(false);

        }
        SwitchBiome(biomes[biomeIndex]);
    }
}
