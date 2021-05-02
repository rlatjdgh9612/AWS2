using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class Pointer : MonoBehaviour
{
    [SerializeField] private float defaultLength = 5.0f;
    [SerializeField] private GameObject dot = null;

    public Camera Camera { get; private set; } = null;

    private LineRenderer lineRenderer = null;
    private VRInputModule inputModule = null;

    public SteamVR_Behaviour_Pose pose;
    public SteamVR_Action_Boolean grabPinch = SteamVR_Input.GetBooleanAction("GrabPinch");

    GameObject hitPullable;
    RaycastHit hit;
    private void Awake()
    {
        Camera = GetComponent<Camera>();
        Camera.enabled = false;

        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        inputModule = EventSystem.current.gameObject.GetComponent<VRInputModule>();
    }

    private void Update()
    {
        bool triggerStay = grabPinch.GetState(SteamVR_Input_Sources.Any);
        bool triggerUp = grabPinch.GetStateUp(SteamVR_Input_Sources.Any);

        if (triggerStay)
        {
            UpdateLine();
        }
        if (triggerUp && hitPullable != null)
        {
            hitPullable.transform.position = transform.position;
        }


    }

    public void UpdateLine()
    {
        // Use default or distance
        PointerEventData data = inputModule.Data;

        RaycastHit hit;

        if (!CreateRaycast(out hit))
        {
            hitPullable = null;
            return;
        }

        // If nothing is hit, set do default length
        float colliderDistance = hit.distance == 0 ? defaultLength : hit.distance;
        float canvasDistance = data.pointerCurrentRaycast.distance == 0 ? defaultLength : data.pointerCurrentRaycast.distance;

        // Get the closest one
        float targetLength = Mathf.Min(colliderDistance, canvasDistance);

        // Default
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        // Set position of the dot
        dot.transform.position = endPosition;

        // Set linerenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);

        hitPullable = hit.collider.gameObject;
    }

    private bool CreateRaycast(out RaycastHit hit)
    {
        // 맞았으면 true, 안 맞았으면 false
        return Physics.Raycast(new Ray(transform.position, transform.forward), out hit, defaultLength, LayerMask.GetMask("Pullable"));
    }
}
