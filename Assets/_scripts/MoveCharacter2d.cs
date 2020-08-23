using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveCharacter2d : MonoBehaviour
{
    #region Variables and Components
    public float speed = 1.5f;
    public float targetStopRange = 1f;

    public FarmableTile activeTile;

    private Vector3 moveTarget;
    private float distanceToTarget;
    private bool isWalking = false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    #endregion

    void Awake()
    {
        //init moveTarget to prevent drift on awake
        //
        moveTarget = transform.position;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (distanceToTarget > targetStopRange)
        {

            ProcessMovement();
            if (!isWalking) { PlayWalkingAnimation(true); }
        }
        else
        {
            if (isWalking) { PlayWalkingAnimation(false); }
        }
    }

    public void SetMoveTarget(Vector3 target)
    {
        moveTarget = target;



        if (moveTarget.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }



        ProcessMovement();
    }

    public void PlayTillAnimation()
    {
        animator.SetTrigger("Till");
    }

    public void TillActiveTile()
    {
        activeTile.TillTile();
    }

    private void PlayWalkingAnimation(bool _walking)
    {
        animator.SetBool("isWalking", _walking);
        isWalking = _walking;
    }

    private void ProcessMovement()
    {
        moveTarget.z = transform.position.z;
        moveTarget.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);

        distanceToTarget = Vector3.Distance(moveTarget, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggered");
        if(other.gameObject.tag == "Tillable")
        {
            activeTile = other.GetComponent<FarmableTile>();
            Debug.Log("Other tile is" + activeTile);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("trigger exit");
    }
}
