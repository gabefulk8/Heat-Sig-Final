using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource source;
    public CharacterController playerController;
    private AudioClip clip;
    public AudioClip[] feetSnow;
    public AudioClip[] feetMetal;
    public AudioClip[] feetBoat;
    public AudioClip[] feetWood;

    public float footstepsVolume = 0.3f;
    private float footstepTimer = 0.6f;

    void Update()
    {
        CallFootsteps();
    }

    void CallFootsteps()
    {
        if (playerController.velocity.magnitude > 0.2f)
        {
            footstepTimer -= Time.deltaTime;

            if (footstepTimer <= 0)
            {
                if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
                {
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Metal":
                            clip = feetMetal[Random.Range(0, feetMetal.Length - 1)];
                            source.PlayOneShot(clip);
                            break;
                        case "Boat":
                            clip = feetBoat[Random.Range(0, feetBoat.Length - 1)];
                            source.PlayOneShot(clip, footstepsVolume);
                            break;
                        case "Wood":
                            clip = feetWood[Random.Range(0, feetWood.Length - 1)];
                            source.PlayOneShot(clip, footstepsVolume);
                            break;
                        default:
                            clip = feetSnow[Random.Range(0, feetSnow.Length)];
                            source.PlayOneShot(clip, footstepsVolume);
                            break;
                    }
                }

                footstepTimer = 0.6f;
            }
        }
    }
}
