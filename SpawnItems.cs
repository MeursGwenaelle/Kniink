using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject piege;
    public GameObject healPotion;
    public int nbCol = 7;
    public int nbLigne = 4;
    public float chanceDeSpawn = 20f;
    public float pourcentageRemplissage = 30f;
    private ArrayList listeItems = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        //SpawnGridLoop();
        SpawnGridPercent();
    }

    private void SpawnGridLoop()
    {
        for (int x = 0; x < nbCol; x++)
        {
            for (int z = 0; z < nbLigne; z++)
            {
                if(Random.value*100 < chanceDeSpawn)
                {
                    Instantiate(piege, new Vector3(x, 0, z), Quaternion.identity);
                }
            }
        }
    }

    private void SpawnGridPercent()
    {
        int nbItemsToSpawn = Mathf.FloorToInt(nbCol * nbLigne * pourcentageRemplissage / 100f);
        int spawnedItems = 0;

        while (spawnedItems < nbItemsToSpawn)
        {
            int x = Mathf.FloorToInt(Random.value * nbCol);
            int z = Mathf.FloorToInt(Random.value * nbLigne);
            if(listeItems.IndexOf(x+"-"+z) == -1)
            {
                Instantiate(piege, new Vector3(x, 0, z), Quaternion.identity);
                listeItems.Add(x + "-" + z);
                spawnedItems++;
            }
        }
    }
}
