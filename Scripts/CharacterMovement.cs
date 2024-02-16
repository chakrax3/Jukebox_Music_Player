using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator animator;
    public Transform taggedpoint;
    public void StartMoving()
    {
        animator.SetBool("walking", true);
        transform.DOMove(taggedpoint.position, 5)
            .OnComplete(() => animator.SetBool("arrived", true));
    }

    public void StartDancing()
    {
        animator.SetBool("dancing", true);
    }

    public void StopDancing()
    {
        animator.SetBool("dancing", false);
    }
}
