using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class particle_system : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public bool stopParticles = false;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particlesIsStop();
    }

    private void Update() {
        particlesIsStop();
    }

    private void particlesIsStop(){
        if(stopParticles){
            particleSystem.Stop();

        } else {
            particleSystem.Play();
        }
    }
}
