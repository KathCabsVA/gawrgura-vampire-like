using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Obstacles : MonoBehaviour
{
     
    public GameObject ObstacleLR;
    [Header("Left to Right Movement")]
    public float leftPos;
    public float rightPos;
    public float duration;
    [Header("Rotating Spikes")]
    public float yAxis;
    public float rotDuration;

    // Start is called before the first frame update
    void Start()
    {
        MoveRight();
        RotateSpike();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateSpike()
    {
        ObstacleLR.transform.DOLocalRotate(new Vector3(0, yAxis, 0), rotDuration).SetLoops(-1, LoopType.Yoyo);

    }

    public void MoveRight()
    {
        ObstacleLR.transform.DOLocalMoveX(rightPos, duration).SetEase(Ease.Linear).OnComplete(MoveLeft);
    }

    public void MoveLeft()
    {
        ObstacleLR.transform.DOLocalMoveX(leftPos, duration).SetEase(Ease.Linear).OnComplete(MoveRight);
    }

}
