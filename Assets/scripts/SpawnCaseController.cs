using UnityEngine;

public class SpawnCaseController : MonoBehaviour
{
    public GameObject moveCasePrefab;
    private GameObject moveCase;
    private PositionController positionController;
    private LookAtAndMove lookAtAndMove;
    private Vector3 casePos;

    private bool _spawnCase, _destroyCase;

    public bool spawnCase {
        set => _spawnCase = value;
        get => _spawnCase;
    }
    
    public bool destroyCase {
        set => _destroyCase = value;
        get => _destroyCase;
    }

    private void Awake() {
        _spawnCase = _destroyCase = false;
    }

    private void Start() {
        lookAtAndMove = this.GetComponent<LookAtAndMove>();
        casePos = new Vector3(this.transform.position.x, this.transform.position.y - 0.60f, this.transform.position.z);
        moveCase = Instantiate(moveCasePrefab, casePos, Quaternion.identity);
        positionController = moveCase.GetComponent<PositionController>();
    }

    private void Update() {

        if(_spawnCase)
        {
            casePos = new Vector3(this.transform.position.x, this.transform.position.y - 0.60f, this.transform.position.z);
            moveCase = Instantiate(moveCasePrefab, casePos, Quaternion.identity);
            positionController = moveCase.GetComponent<PositionController>();
            _spawnCase = false;
        }

        if(_destroyCase)
        {
            if(moveCase != null)
            {
                Destroy(moveCase);
            }
            _destroyCase = false;
        }

        if(moveCase != null && positionController != null)
        {
            lookAtAndMove.setCursor = positionController.getLastPos ?? null;
        }
        
    }
}
