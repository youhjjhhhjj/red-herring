using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Focus : MonoBehaviour
{
    [Tooltip("The rotation that this object will start out with when inspected.")]
    public Vector3 defaultRotation;

    public Vector3 defaultTranslation;
    public float focusDistance;
    private Rigidbody rb;

    private void Start()
    {
        EventManager.AddListener<FocusEvent>(OnFocus);
        rb = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<FocusEvent>(OnFocus);
    }

    public void OnFocus(FocusEvent evt)
    {
        if (evt.gameObject == gameObject) disablePhysics();
    }

    public void disableCollider()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    public void enableCollider()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    public void disablePhysics()
    {
        if (rb != null) rb.isKinematic = true;
        disableCollider();
    }

    public void enablePhysics()
    {
        if (rb != null) rb.isKinematic = false;
        enableCollider();
    }
}