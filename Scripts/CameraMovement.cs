using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject jukeboxbutton;
    public Transform taggedpoint;
    public void StartMoving()
    {
        transform.DOMove(taggedpoint.position, 5)
            .OnComplete(() => jukeboxbutton.SetActive(true));
    }
}
