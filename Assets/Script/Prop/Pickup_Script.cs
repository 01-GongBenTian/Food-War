using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Script : MonoBehaviour
{
    public float rotate_speed;

    public int rotate_direction;

    public string Name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotate_speed * rotate_direction * Time.deltaTime, 0);
    }
}
