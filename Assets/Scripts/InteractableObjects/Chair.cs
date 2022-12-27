using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interactable
{

    private Rigidbody playerRB;
    private AgentMovement playerAM;
    public GameObject sitPosition;
    public GameObject frontPosition;
    public float timer;

    private void Start()
    {
        playerRB = FindObjectOfType<PlayerInput>().GetComponent<Rigidbody>();
        playerAM = FindObjectOfType<PlayerInput>().GetComponent<AgentMovement>();
    }

    public override void Interact()
    {
        SitDown();
    }

    //Interaction for the chair, in this case, sitting down on it.
    private void SitDown()
    {
        playerAM.gameObject.GetComponent<CapsuleCollider>().height = 1.7f;
        playerRB.isKinematic = true;
        this.GetComponent<BoxCollider>().enabled = false;
        playerRB.transform.position = frontPosition.transform.position;
        playerRB.transform.rotation = frontPosition.transform.rotation;
        playerRB.isKinematic = false;
        playerRB.GetComponent<Animator>().SetBool("IsSit", true);
        playerAM.isSit = true;
        playerAM.chair = this.gameObject;
        StartCoroutine("Sit");
    }

    //Move player a bit for the position. Necessary cause the animation pivots are not the same. 
    IEnumerator Sit()
    {
        yield return new WaitForSeconds(timer);
        playerRB.transform.position = sitPosition.transform.position;
        playerRB.transform.rotation = sitPosition.transform.rotation;
    }
}
