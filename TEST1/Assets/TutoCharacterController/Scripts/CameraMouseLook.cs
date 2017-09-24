using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for main character camera look
/// </summary>
public class CameraMouseLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothVector;

    [SerializeField] // Let the value appears in Unity editor
    private float sensitivity = 1.2f;
    [SerializeField]
    private float smoothing = 2.0f;

    GameObject character;

    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Change of the mouse movement
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        // Multiplying with smooth and sensitivity
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVector.x = Mathf.Lerp(smoothVector.x, mouseDelta.x, 1f / smoothing);
        smoothVector.y = Mathf.Lerp(smoothVector.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothVector;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f); // Clamp Looking up and down

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

    }
}
