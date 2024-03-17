using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{

    public GameObject hitSprite;
    public AudioClip[] audioClips; 

    [Header("Events")]
    public UnityEvent deathEvent;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    private bool isAlive = true;

    private bool screenClick = false;

    private Animator animator;
    private AudioSource[] audioSources;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        audioSources = GetComponents<AudioSource>();
    }

    private void Update() { 
        if ((Input.GetKeyDown(KeyCode.Space) || screenClick == true) && isAlive)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0.5f, 1) * 50f);

            animator.SetTrigger("Flip2");

            PlaySound(0);

            screenClick = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isAlive = false;
            
            rigidbody.velocity = Vector2.down;

            animator.SetTrigger("Death");

            PlaySound(1);

            PlaySound(2);

            ShowHitSprite(collision.contacts[0].point);

            deathEvent.Invoke();
        }
    }

    private void PlaySound(int numClip)
    {
        bool findEmptySource = false;
        foreach(var item in audioSources)
        {
            if (item.isPlaying == false)
            {
                item.clip = audioClips[numClip];
                item.Play();

                findEmptySource = true;
                break;
            }
        }

        if (findEmptySource == false)
        {
            this.AddComponent<AudioSource>();
            audioSources = GetComponents<AudioSource>();

            PlaySound(numClip);
        }
    }

    private void ShowHitSprite(Vector2 pointHit)
    {
        hitSprite.transform.position = pointHit;
        hitSprite.SetActive(true);

        Invoke(nameof(HideHitSprite), 0.2f);
    }

    private void HideHitSprite()
    {
        hitSprite.SetActive(false);
    }

    public void ClickScreenButton()
    {
        screenClick = true;
    }
}



