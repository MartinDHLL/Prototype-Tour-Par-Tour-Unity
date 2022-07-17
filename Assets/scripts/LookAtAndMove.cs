using UnityEngine;

public class LookAtAndMove : MonoBehaviour
{
    /*

    bug à corriger :
    La translation du joueur est divisé par deux lorsque la rotation n'est pas égale
    à la rotation précédente.

    */

    private SpawnCaseController spawnCaseController;
    private Transform cursorTransform, finalTransform;

    private Vector3 roundVector1, roundVector2;

    private bool spawnCase;

    public Transform setCursor {
        set => cursorTransform = value;
    }
    
    private void Start() {
        spawnCaseController = this.GetComponent<SpawnCaseController>();
        spawnCase = false;
    }

    private void Update() {
        if(spawnCase)
            {
                spawnCaseController.spawnCase = true;
                spawnCase = false;
            }
        if(cursorTransform != null)
        {
            this.transform.LookAt(cursorTransform);
            finalTransform = this.transform;
            roundVector1 = new Vector3(Mathf.Round(cursorTransform.position.x),0,Mathf.Round(cursorTransform.position.z));
            roundVector2 = new Vector3(Mathf.Round(finalTransform.position.x),0,Mathf.Round(finalTransform.position.z));
            //Debug.Log("vector 1 (cursor) : " + roundVector1);
            //Debug.Log("vector 2 (playerPosition) : " + roundVector2);
            if(roundVector1 != roundVector2)
            {
                this.transform.rotation = new Quaternion(0,finalTransform.rotation.y,0,finalTransform.rotation.w);
                this.transform.Translate(0,0,.01f);
            }
            else
            {
                spawnCaseController.destroyCase = true;
                this.transform.rotation = new Quaternion(0,finalTransform.rotation.y,0,finalTransform.rotation.w);
                spawnCase = true;
            }
        }
    }
}
