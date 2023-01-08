using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textSocre;
    public float score; 

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        textSocre.text = score.ToString() + " Flowers";

    }

    // Update is called once per frame
    void Update()
    {
        textSocre.text = score.ToString() + " Flowers";

    }

    
}
 