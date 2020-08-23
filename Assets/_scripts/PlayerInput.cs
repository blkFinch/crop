using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveCharacter2d))]
public class PlayerInput : MonoBehaviour
{
    private MoveCharacter2d moveCharacter;
    private Vector3 mouseTarget;

    void Awake()
    {
        moveCharacter = this.GetComponent<MoveCharacter2d>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
             mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             moveCharacter.SetMoveTarget(mouseTarget);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            moveCharacter.PlayTillAnimation();
        }
    }

   
}
