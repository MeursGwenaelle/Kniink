using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    

    public List<GameObject> content = new List<GameObject>();

    public GameObject Clebleu;

    public GameObject Clerouge;

    public GameObject Clevert;

    public GameObject Clenoire;

    public GameObject Parchemin;

    public GameObject InventaireUI;

    private void Awake()
    {
        InventaireUI.SetActive(false);

       
    }

    public void StoreObjectIntoInventory(GameObject objetToStore)
    {
        content.Add(objetToStore);
    }

    private void Update()
    {
        if (ContainsObjects("Key blue"))
        {
            Clebleu.SetActive(true);

        }

        if (ContainsObjects("Key red"))
        {
            Clerouge.SetActive(true);

        }

        if (ContainsObjects("Key green"))
        {
            Clevert.SetActive(true);

        }

        if (ContainsObjects("Key black"))
        {
            Clenoire.SetActive(true);

        }

        if (ContainsObjects("Parchemin"))
        {
            Parchemin.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            InventaireUI.SetActive(true);
            Time.timeScale = 0;


        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            InventaireUI.SetActive(false);
            Time.timeScale = 1;

        }
    }

    public bool ContainsObjects(string _name)
    {
        foreach (GameObject obj in content)
        {
            if (obj.name == _name)
            {

                return true;
            }

        }
        return false;
    }

}
