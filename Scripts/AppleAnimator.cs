using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] idle;
    public Sprite[] vanish;

    void Start()
    {
        StartCoroutine(Idle());
    }

    void Update()
    {

    }

    IEnumerator Idle()
    {
        int i;
        i = 0;
        while (i < idle.Length)
        {
            spriteRenderer.sprite = idle[i];
            i++;
            yield return new WaitForSeconds(0.03f);
            yield return 0;

        }
        StartCoroutine(Idle());
    }

    IEnumerator Vanish()
    {
        int i;
        i = 0;
        while (i < vanish.Length)
        {
            spriteRenderer.sprite = vanish[i];
            i++;
            yield return new WaitForSeconds(0.07f);
            yield return 0;

        }
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //GetComponent<CircleCollider2D>().enabled = false;
            col.gameObject.GetComponent<PlayerSoundManager>().collectSound.Play();
            StopAllCoroutines();
            StartCoroutine(Vanish());
        }
    }
}
