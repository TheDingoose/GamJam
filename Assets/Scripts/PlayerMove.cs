using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;

    public IEnumerator MoveTo(Vector2 pos) {
        float actualSpeed = Vector2.Distance(transform.position, pos)/moveSpeed;
        Vector2 startPos = (Vector2)transform.position;

        if (pos.x - startPos.x > 0) transform.localScale = new Vector3(-1, 1, 1);

        Animator animator = GetComponent<Animator>();
        animator.SetInteger("AnimationState", 1);

        float timeElapsed = 0;
        while (timeElapsed < actualSpeed) {
            timeElapsed += Time.deltaTime;

            transform.position = Vector2.Lerp(startPos, pos, timeElapsed/actualSpeed);

            yield return null;
        }

        animator.SetInteger("AnimationState", 0);
        transform.localScale = new Vector3(1, 1, 1);
    }
}
