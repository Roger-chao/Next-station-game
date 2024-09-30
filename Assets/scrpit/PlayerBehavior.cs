using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    public float HP,MaxHP;
    public float recover;
    public int healthybag;
    public GameObject full;
    public GameObject green;
    bool wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = false;
        full.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            run();
            heal();
            life();
        }
    }
    void run()
    {
        float movex= Input.GetAxis("Horizontal")*speed;
        float movey = Input.GetAxis("Vertical")*speed;
        movex *= Time.deltaTime;
        movey *= Time.deltaTime;
        transform.Translate(movex, movey, 0);
    }
    void heal()
    {
        if (Input.GetKeyDown(KeyCode.Space) && healthybag != 0 && HP != MaxHP )
        {
            if ( HP <= MaxHP - recover)
                HP += recover;
            else if ( HP > MaxHP - recover)
                HP = MaxHP;
            healthybag--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && HP == MaxHP && healthybag !=0)
        {
            if (!wait)
            {
                full.SetActive(true);
                wait = true;
                Invoke("dis", 2);
            }
        }
    }
    void dis()
    {
        full.SetActive(false);
        wait = false;
    }
    void life()
    {      
      green.GetComponent<RectTransform>().sizeDelta = new Vector2(300*(HP/MaxHP),27);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hbag")
        {
            Destroy(collision.gameObject);
            healthybag++;
        }
    }
}
