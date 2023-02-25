using UnityEngine;
using UnityEngine.Animations.Rigging;

/// <summary>
/// Animates the arm in sync with the feet.
/// </summary>
public class IKRiggedActorArmAnimationController : MonoBehaviour
{
    #region Class Variables

    /// <summary>The left foot solver.</summary>
    protected IKRiggedActorFootSolver leftFootSolver;

    /// <summary>The left foot solver.</summary>
    protected IKRiggedActorFootSolver rightFootSolver;

    /// <summary>Computed animation start time.</summary>
    protected float startAnimTime;

    /// <summary>Computed animation end time.</summary>
    protected float endAnimTime;

    /// <summary>The current animation state.</summary>
    protected AnimationState animationState = AnimationState.idle;

    /// <summary>The companion Animator component.</summary>
    protected Animator animator;

    /// <summary>The animation controller.</summary>
    public RuntimeAnimatorController AnimatorController { private get; set; }

    #endregion



    #region Base Methods

    /// <summary>
    /// Initializes values.
    /// </summary>
    void Start()
    {
        // Set the animation congtroller.
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = AnimatorController;

        // Turn off arm IK.
        RigBuilder rigBuilder = GetComponent<RigBuilder>();
        foreach (var layer in rigBuilder.layers) {
            if (layer.name == "Arm IK Rig") {
                layer.active = false;
                break;
            }
        }
    }


    /// <summary>
    /// Animates the arms in sync with the feet.
    /// </summary>
    private void Update() {
        // If the right foot is moving...
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        bool isAnimating = false;
        float currentAnimationProgress = leftFootSolver.StepProgression;
        // If not already animating with the left foot, start animating in sync with the foot.
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
        // Otherwise, check if the right foot is moving.
        else {
            currentAnimationProgress = rightFootSolver.StepProgression;
            // If not already animating with the right foot, start animating in sync with the foot.
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

        // If arms are animating, compute the current animation time.
        if (isAnimating) {
            float currentAnimationTime = Mathf.Lerp(startAnimTime, endAnimTime, currentAnimationProgress);
            animator.Play(state.fullPathHash, -1, currentAnimationTime);
        }
        // Otherwise, set the animation state to idle.
        else {
            animationState = AnimationState.idle;
        }
    }

    #endregion



    /// <summary>
    /// Sets the foot solvers.
    /// </summary>
    public void SetFootSolvers(IKRiggedActorFootSolver leftFootSolver, IKRiggedActorFootSolver rightFootSolver) {
        this.leftFootSolver = leftFootSolver;
        this.rightFootSolver = rightFootSolver;
    }



    /// <summary>
    /// Current arm animation state.
    /// </summary>
    protected enum AnimationState {
        idle,
        leftLeg,
        rightLeg,
    }

}
