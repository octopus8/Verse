using UnityEngine;
using UnityEngine.Animations.Rigging;


public class IKRiggedArmAnimationController : MonoBehaviour
{
    protected IKRiggedAvatarFootSolver leftFootSolver;
    protected IKRiggedAvatarFootSolver rightFootSolver;

    float startAnimTime;
    float endAnimTime;

    enum AnimationState {
        idle,
        leftLeg,
        rightLeg,
    }

    AnimationState animationState = AnimationState.idle;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Turn off arm IK.
        RigBuilder rigBuilder = GetComponent<RigBuilder>();
        foreach (var layer in rigBuilder.layers) {
            if (layer.name == "Arm IK Rig") {
                layer.active = false;
                break;
            }
        }
    }

    public void SetFootSolvers(IKRiggedAvatarFootSolver leftFootSolver, IKRiggedAvatarFootSolver rightFootSolver) {
        this.leftFootSolver = leftFootSolver;
        this.rightFootSolver = rightFootSolver;
    }

    private void Update() {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        bool isAnimating = false;
        float currentAnimationProgress = leftFootSolver.GetStepProgression();
        if (currentAnimationProgress < 1.0f) {
            isAnimating = true;
            if (animationState != AnimationState.leftLeg) {
                startAnimTime = state.normalizedTime;
                endAnimTime = Mathf.FloorToInt(startAnimTime) + 0.8f;
                if (endAnimTime < startAnimTime) {
                    endAnimTime += 1.0f;
                }
                animationState = AnimationState.leftLeg;
            }
        }
        else {
            currentAnimationProgress = rightFootSolver.GetStepProgression();
            if (currentAnimationProgress < 1.0f) {
                isAnimating = true;
                if (animationState != AnimationState.rightLeg) {
                    startAnimTime = state.normalizedTime;
                    endAnimTime = Mathf.FloorToInt(startAnimTime) + 0.3f;
                    if (endAnimTime < startAnimTime) {
                        endAnimTime += 1.0f;
                    }
                    animationState = AnimationState.rightLeg;
                }
            }
        }

        if (isAnimating) {
            float currentAnimationTime = Mathf.Lerp(startAnimTime, endAnimTime, currentAnimationProgress);
            animator.Play(state.fullPathHash, -1, currentAnimationTime);
        }
        else {
            animationState = AnimationState.idle;
        }
    }


}
