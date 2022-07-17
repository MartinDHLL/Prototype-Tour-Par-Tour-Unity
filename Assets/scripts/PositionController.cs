using UnityEngine;

public class PositionController : MonoBehaviour
{
    public GameObject left, right, bottom, top;
    private SendClickPosition leftPos, rightPos, bottomPos, topPos;
    private Transform saveLastPos;
    private bool allowSearch;

    public Transform getLastPos {
        get => saveLastPos;
    }

    private void Start() {
        allowSearch = true;
        leftPos = left.GetComponent<SendClickPosition>();
        rightPos = right.GetComponent<SendClickPosition>();
        bottomPos = bottom.GetComponent<SendClickPosition>();
        topPos = top.GetComponent<SendClickPosition>();
    }

    private void Update() {
        if(allowSearch)
        {
            saveLastPos = leftPos.getPosition != null ? leftPos.getPosition 
            : rightPos.getPosition != null ? rightPos.getPosition
            : topPos.getPosition != null ? topPos.getPosition
            : bottomPos.getPosition != null ? bottomPos.getPosition
            : null
            ;

            if(saveLastPos != null)
            {
                allowSearch = false;
            }
        }
    }
}
