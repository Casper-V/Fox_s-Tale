using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;

    public GameObject collectible;
    public GameObject collectible2;
    [Range(0,100)]public float chanceToDrop;
    [Range(0, 100)] public float kansOpGem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //Debug.Log("Hit Enemy");
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);
            if(dropSelect <= chanceToDrop)
            {
                float nogEenRandom = Random.Range(0, 100f);
                if(nogEenRandom <= kansOpGem)
                { 
                Instantiate(collectible, other.transform.position, other.transform.rotation);
                } else
                {
                Instantiate(collectible2, other.transform.position, other.transform.rotation);
                }
            }

            AudioManager.instance.PlaySFX(3);

        }
    }
}
