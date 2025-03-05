
using Assets.PixelFantasy.PixelHeroes.Common.Scripts.ExampleScripts;


using UnityEngine;


public class UnitMovement : MonoBehaviour
{
    CombatStatus activity;
    [SerializeField] float movementSpeed = 5f;

    
    Rigidbody2D myRigidbody2D;
    CharacterAnimation characterAnimation;
    UnitBars unitBars;

    float myCharXTransform;
    Transform tempTransform;
    private void Awake()
    {
        
        characterAnimation = GetComponent<CharacterAnimation>();
        unitBars= GetComponentInChildren<UnitBars>();
        //myRigidbody2D=GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        myCharXTransform = transform.localScale.x;

    }
    private void Update()
    {
        
    }

    public float GetMoveSpeed()
    {
        return movementSpeed;
    }

    public void Move(GameObject target)
    {
        //activity = CombatActivity.MOVING; //need to fix
        Vector2 targetPosition = target.transform.position;

        Transform targetTransform = target.transform;
        TurnCorrectDirection(targetTransform);

        float delta = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
        this.characterAnimation.Run();
    }
    public void Move(Transform target)
    {
        //activity = CombatActivity.MOVING; //need to fix
        Vector2 targetPosition = target.position;
        
        
        TurnCorrectDirection(target);

        float delta = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
        this.characterAnimation.Run();
    }
    public void Stop()
    {
        Vector2 targetposition = transform.position;
    }

    public void TurnCorrectDirection(Transform target)
    {
        
        bool movingLeft = target.transform.position.x < this.transform.position.x;

        if (movingLeft)
        {
            transform.localScale = new Vector2(-myCharXTransform, transform.localScale.y);
            unitBars.FixFlip(-1f);
        }
        else
        {
            transform.localScale = new Vector2(myCharXTransform, transform.localScale.y);
            unitBars.FixFlip(1f);
        }

    }
        void IdleMovementChecker()
        {//should go to update but is broken probably not needed
            if (transform.position == tempTransform.position)
                { 
                    characterAnimation.Idle();
                }
                tempTransform.position = transform.position;
        }
}
