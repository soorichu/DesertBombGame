using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Animator myAnimator;
    public AudioClip deathClip;

    private float translation;
    private float rotation;

    private Vector3 mousePos1;
    private Vector3 mousePos2;

    private void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePos1 = new Vector3(Input.mousePosition.x, 0f, Input.mousePosition.y);
        }
        else if (Input.GetMouseButton(0))
        {
            mousePos2 = new Vector3(Input.mousePosition.x, 0f, Input.mousePosition.y);
        }

        if(mousePos1 != mousePos2)
        {
            translation = (mousePos2.z - mousePos1.z) / 10f;

            if(Mathf.Abs(mousePos2.x - mousePos1.x) > 20f)
            {
                translation = 0f;
                rotation = mousePos2.x - mousePos1.x;
            }
        }

        if (Input.anyKey)
        {
            translation = Input.GetAxis("Vertical") * 10f;
            rotation = Input.GetAxis("Horizontal") * 100f;
        }

        if (translation != 0.0f || rotation != 0.0f)
        {
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);

            myAnimator.SetBool("walk", true);
        }
        else
        {
            myAnimator.SetBool("walk", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        if (collision.collider.tag == "Obstacle")
        {
            myAnimator.SetTrigger("damage");
            GameManager.instance.AddScore(-1);
        }

        if (collision.collider.tag == "BadBall")
        {
            myAnimator.SetBool("walk", false);
            myAnimator.SetTrigger("attack01");
            GameManager.instance.OnPlayerDead();
        }

        if (collision.collider.tag == "GoodBall")
        {
            GameManager.instance.AddScore(1);
        }
    }




}
