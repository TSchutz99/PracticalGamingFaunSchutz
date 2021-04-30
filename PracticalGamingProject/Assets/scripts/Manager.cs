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
    public GameObject bomb_template;
    public GameObject medkit_template;
    // Start is called before the first frame update
    void Start()
    {
        bombs = FindObjectsOfType<Bomb>().ToList();
        meds = FindObjectsOfType<medkit>().ToList();
        allItems = FindObjectsOfType<PowerPacks>().ToList();
        player = FindObjectOfType<vehicleControl>();

        foreach (PowerPacks item in allItems)
        {
            item.Iam(this);
        } 

        for(int i = 0; i < 20; i++) { 
            spawn_power_packs(bomb_template);
        }
        for(int i = 0; i < 8; i++) { 
            spawn_power_packs(medkit_template);
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
    internal void spawn_power_packs(GameObject powerPack)
    {
        // spawn a power packs in random position

        GameObject go = Instantiate(powerPack, new Vector3(UnityEngine.Random.Range(-250.0f, 250.0f), 2.5f, UnityEngine.Random.Range(-250.0f, 250.0f)), Quaternion.identity);

        if(powerPack == bomb_template) {
            Bomb newBomb = go.GetComponent<Bomb>();
            bombs.Add(newBomb);
            allItems.Add(newBomb);
            newBomb.Iam(this); 
        }
        else if(powerPack == medkit_template)
        {
            medkit newMedkit = go.GetComponent<medkit>();
            meds.Add(newMedkit);
            allItems.Add(newMedkit);
            newMedkit.Iam(this);
        }
    }
}
