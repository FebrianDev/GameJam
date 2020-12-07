using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    public GameObject combat;
    AudioSource audio;

    public AudioClip[] clip;
    void Start()
    {
        anim = GetComponent<Animator>();
        combat.SetActive(false);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int rand = Random.Range(0, clip.Length);
            audio.PlayOneShot(clip[rand]);
            StartCoroutine(AnimActive());
            anim.SetTrigger("Attack");
        }
    }

    IEnumerator AnimActive()
    {
        combat.SetActive(true);
        yield return new WaitForSeconds(1);
        combat.SetActive(false);
    }
}
