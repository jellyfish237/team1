using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem healthParticle = null;
    //delete after finished testing
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healParticle();
            
        }
    }

    public void healParticle()
    {
        //play the particles
        healthParticle.Play();
    }
    
}
