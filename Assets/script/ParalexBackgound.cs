using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalexBackgound : MonoBehaviour
{

    private float lenght;
    private float startPos;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("CM vcam1");
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + lenght)
        {
            startPos += lenght;
        }
        else if (temp < startPos + lenght)
        {
            startPos -= lenght;
        }
    }
}
