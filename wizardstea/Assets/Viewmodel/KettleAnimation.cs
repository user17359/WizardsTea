using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettleAnimation : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void ChangeKettle(int stage)
    {
        animator.SetInteger("stage", stage);
    }
}
