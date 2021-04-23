using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Manager : MonoBehaviour
{
    vehicleControl player;
    List<Bomb> bombs;
    List<medkit> meds;
    List<PowerPacks> allItems;
    // Start is called before the first frame update
    void Start()
    {
        bombs = FindObjectsOfType<Bomb>().ToList();
        meds = FindObjectsOfType<medkit>().ToList();
        player = FindObjectOfType<vehicleControl>();

        allItems = FindObjectsOfType<PowerPacks>().ToList();
        foreach (PowerPacks item in allItems)
        {
            item.Iam(this);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        //print(Vector3.Distance(player.transform.position, bombs[0].transform.position));

        for(int i = 0; i < bombs.Count; i++) { 
            if(Vector3.Distance(player.transform.position, bombs[i].transform.position) < 20)
            {
                bombs[i].lockOn(player);
            }
        }
    }

    internal void IveBeenDestroyed(Bomb bomb)
    {
        bombs.Remove(bomb);
        allItems.Remove(bomb);
    }
    internal void IveBeenDestroyed(medkit med)
    {
        meds.Remove(med);
        allItems.Remove(med);
    }
}
