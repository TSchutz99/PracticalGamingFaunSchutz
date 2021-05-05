using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collected_Eggs : MonoBehaviour
{
    public Text myText = null;
    // Start is called before the first frame update
    void Start()
    {
        myText.text = "0 of 6";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void egg_collected(int eggs)
    {
        myText.text = eggs + " of 6";
    }
}
