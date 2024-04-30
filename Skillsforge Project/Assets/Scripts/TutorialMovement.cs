using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{

    public Sounds sound;
    private bool isMoving;
    public void MoveLeft()
    {
        if (this.transform.position.x > Boundary.leftMove && !isMoving && !TutorialCloneMultiplier.isDead)
        {
            sound.PlayClickSound();
            StartCoroutine(MoveToTarget(this.transform.position + new Vector3(-6, 0, 0)));


        }


    }

    public void MoveRight()
    {
        if (this.transform.position.x < Boundary.rightMove && !isMoving && !TutorialCloneMultiplier.isDead && !EndGame.isFighting)
        {
            sound.PlayClickSound();
            StartCoroutine(MoveToTarget(this.transform.position + new Vector3(6, 0, 0)));


        }

    }

    IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        isMoving = true;
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 target = targetPosition;

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startPosition, target, elapsedTime);
            elapsedTime += Time.deltaTime * 5;
            yield return null;
        }
        transform.position = target;
        isMoving = false;
    }
}
