using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2D;
    private float originalx;
    private float originaly;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float differencex = originalx - transform.position.x;
        float differencey = originaly - transform.position.y;

        if (differencex > 0)
        {
            animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);
            animator.SetFloat("Look X", 0);
            //Debug.Log("��");
        }

        if (differencex < 0)
        {
            animator.SetBool("isRight", true);
            animator.SetBool("isLeft", false);
            animator.SetFloat("Look X", 0.5f);
            //Debug.Log("��");
        }

        if (differencey > 0)
        {
            //Debug.Log("��");
        }

        if (differencey < 0)
        {
            //Debug.Log("��");
        }

        if (differencex == 0 && differencey == 0)
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
        }
    }

    private void LateUpdate()
    {
        originalx = transform.position.x;
        originaly = transform.position.y;
    }
}
