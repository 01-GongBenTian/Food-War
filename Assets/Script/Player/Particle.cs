using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject Red_Particle, Green_Particle, White_Particle, Gold_Particle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Particle_Emission(GameObject Particle)
    {
        Particle.GetComponent<ParticleSystem>().Play();
    }
}
