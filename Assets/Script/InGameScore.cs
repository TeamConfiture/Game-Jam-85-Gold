using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScore : MonoBehaviour
{

    public Text gText; 
    public Text lText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!DogBehaviour.foundPhilosophersStone)
        {
            gText.text = string.Format("{0}", DogBehaviour.gold);
            lText.text = string.Format("{0}", DogBehaviour.lead);
        } else
        {
            gText.text = string.Format("{0}", DogBehaviour.gold + DogBehaviour.lead);
            lText.text = "0";
        }
    }
}
