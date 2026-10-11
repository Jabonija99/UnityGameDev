using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;

    const string ATTACK = "Attack";
    const string PICKUP = "Pickup";
    public bool canMove = true;


    PlayerInputs input;

    NavMeshAgent agent;


    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    [Header("Attack")]
    [SerializeField] float attackSpeed = 1.5f;
    [SerializeField] float attackDelay = 0.3f;
    [SerializeField] float attackDistance = 1.5f;
    [SerializeField] int attackDamage = 1;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] public int playerMaxHealth = 10;
    [SerializeField] public int playerCurrentHealth;
    private Vector3 moveDirection;
    private Vector3 test;
    [SerializeField] private GameManagerController _gameManagerController;





    bool playerBusy = false;
    Interactable target = null;

    float lookRotationSpeed = 8f;


    [SerializeField] private Animator _playerAnim;
    public bool isMoving = false;
    public bool canAttack = true;
    private bool isAttacking = false;
    public float attackCooldown = 2f;

    void Awake()
    {

        isMoving = false;
        playerCurrentHealth = playerMaxHealth;
        agent = GetComponent<NavMeshAgent>();
        input = new PlayerInputs();
        AssignInput();
}

    void AssignInput()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    void ClickToMove()
    {
        test = transform.position;

        if (canMove == false) return;

        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            if (hit.transform.CompareTag("Interactable"))
            {
                Debug.Log("Whatever");
                target = hit.transform.GetComponent<Interactable>();
                if (clickEffect != null)
                {
                    Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);

                }

            }
            else
            {
                target = null;
                agent.destination = hit.point;
                if (clickEffect != null)
                {
                    Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);

                }
            }
           
        }

    }
    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        FollowTarget();
        FaceTarget();
        HandleAnimations();
        CheckMovingState();
    }

   

    void FollowTarget()
    {
       

        if (target == null) return;
        if (Vector3.Distance(target.transform.position, transform.position) <= attackDistance)
        {
            ReachDistance();
        }
        else
        {
            agent.SetDestination(target.transform.position);
            
        }
    }


    void ReachDistance()
    {
        Debug.Log("player busy state"+playerBusy);
        agent.SetDestination(transform.position);

        if (playerBusy) return;
        playerBusy = false;

        switch (target.interactionType)
        {
            case InteractableType.Enemy:
                Debug.Log("Attacking enemy");
                Invoke(nameof(SendAttack), attackDelay);
                break;

            case InteractableType.Item:
                Debug.Log("picking up item");
                target.InteractWithItem();
                target = null;
                Invoke(nameof(ResetBusyState), 0.5f);
                break;
        }
    }

    void SendAttack()
    {
        if (target == null) return;

        //Instantiate(hitEffect, target.transform.position + new Vector3(0, 1, 0), Quaternion.identity);

        if (_gameManagerController.hasWeapon == true)
        {
            target.GetComponent<EnemyController>().takeDamage(attackDamage);
            HandleAttackAnimation();
            StartCoroutine(AttackCoolDown());
        }
        
        playerBusy = false;
        
    }

    void ResetBusyState()
    {
        playerBusy = false;
    }


    void FaceTarget()
    {


        if (agent.destination == transform.position)
        {
            return;
        }


        Vector3 facing = Vector3.zero;

        if (target != null) { facing = target.transform.position; }
        else { facing = agent.destination; }





        Vector3 direction = (facing - test).normalized;
       
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
       
       
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }



    private void HandleAnimations()
    {
        if (isMoving)
        {
            if(canMove)
                _playerAnim.Play("PlayerWalk");
        }
        else
        {
            if(!isAttacking)
                _playerAnim.Play("PlayerIdle");
        }
    }


    private void CheckMovingState()
    {

        Debug.Log("Player Position: " + gameObject.transform.position + "// Destination: " + agent.destination + "// Distance: " + Vector3.Distance(this.gameObject.transform.position, agent.destination));
        
        if (Vector3.Distance(this.gameObject.transform.position, agent.destination) < 1.1f)
        {
            isMoving = false;
        }
        else
        {
            
            isMoving = true;
        }
    }

   private void HandleAttackAnimation()
   {
        if (canAttack)
        {
            _playerAnim.Play("PlayerAttack");
            canAttack = false;
        }
   }

   private IEnumerator AttackCoolDown()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.4f);
        isAttacking = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }


}
