using UnityEngine;


namespace O8C {

    /// <summary>
    /// Parent class for IO8CDeviceTracking MonoBehaviour implementations.
    /// </summary>
    /// <remarks>
    /// This class only contains abstract implementations of the interface and is intended to allow implementors of the interface to be used in the inspector.
    /// </remarks>
    public abstract class O8CDeviceTracking : MonoBehaviour, IO8CDeviceTracking {

        /** {@inheritdoc} */
        abstract public void AddHeadTarget(GameObject target);


        /** {@inheritdoc} */
        abstract public void AddLeftHandTarget(GameObject target);


        /** {@inheritdoc} */
        abstract public void AddRightHandTarget(GameObject target);


        /** {@inheritdoc} */
        abstract public void RemoveHeadTarget(GameObject target);


        /** {@inheritdoc} */
        abstract public void RemoveLeftHandTarget(GameObject target);


        /** {@inheritdoc} */
        abstract public void RemoveRightHandTarget(GameObject target);

    }

}