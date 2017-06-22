using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable {
    public Animator door;
    public int timeAfterOpen = 2;
    public AudioSource myAudio;

	public override void Interacting()
    {
        door.SetBool("OpenDoor", true);
        myAudio.Play();
        StartCoroutine(close(timeAfterOpen));
        interacting = true;
    }

    public IEnumerator close(int a)
    {
        yield return new WaitForSeconds(a);
        door.SetBool("OpenDoor", false);
        interacting = false;
    }
}
