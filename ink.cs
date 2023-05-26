using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ink : MonoBehaviour
{
    [SerializeField] public int inkMax = 6;
    [SerializeField] public int CurrentInk;
    [SerializeField] private InkController inkController;

   // Start is called before the first frame update
    void Start()
    {
        CurrentInk = 5;
        inkController.SetMaxInk(CurrentInk);

    }

    // Update is called once per frame
    public void UpdateInk(int ink)
    {
        if(CurrentInk == inkMax)
        {
            CurrentInk = inkMax;
        }
        else
        {
            CurrentInk += ink;
        }

        inkController.SetMaxInk(CurrentInk);
    }
}
