using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderJacket : Interactable
{
    public ParticleSystem playerParticles;

    //Interaction for the commander jacket
    public override void Interact()
    {
        ActivateParticles();
    }

    public void ActivateParticles()
    {
        playerParticles.Play();
    }
}
