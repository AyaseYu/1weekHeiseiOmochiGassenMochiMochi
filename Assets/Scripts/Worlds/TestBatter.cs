using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBatter : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x, y, 0)*Time.deltaTime*7f; 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.enabled = true;
        }
    }
}
