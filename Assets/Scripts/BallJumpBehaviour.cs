using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJumpBehaviour : StateMachineBehaviour
{
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >=1) {
            animator.SetBool("Jump", false);
        }
    }
}
