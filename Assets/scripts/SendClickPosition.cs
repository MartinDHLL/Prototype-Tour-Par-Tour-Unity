using UnityEngine;

public class SendClickPosition : MonoBehaviour
{
    private bool allowClick;
    private Transform position;

    public Transform getPosition {
        get => position;
    }

    private void Start() {
        allowClick = true;
    }
    private void OnMouseDown() {
        if(allowClick)
        {
            position = this.transform;
            allowClick = false;
        }
    }
}
