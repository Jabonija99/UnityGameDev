using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{

    private NavMeshAgent dogAgent;
    [SerializeField] private GameManagerController _gameManagerController;
    public bool dogFollow = false;
    [SerializeField] private GameObject player;

    public bool canAttack = true;
    public bool playerInRange = false;
    public float attackCooldown = 1f;
    private int damage = 1;

    [SerializeField] private Animator _dogAnim;
    [SerializeField] private GameObject plate;
    private bool soundhasPlayed = false;
   


    void Start()
    {
        dogAgent = GetComponent<NavMeshAgent>();

    }

    
    void Update()
    {
        
        if (playerInRange == true && canAttack == true)
        {
            StartCoroutine(DogAttack());
            
        }
        else if (playerInRange == false && canAttack == true)
        {
            FollowTarget();
        }

    }

    private void FollowTarget()
    {
        if (_gameManagerController.hasFedDog == false && (dogFollow == true)) 
        {
            dogAgent.SetDestination(player.transform.position);
            _dogAnim.Play("Dog_Walk");
        }
        else if(_gameManagerController.hasFedDog)
        {
            dogAgent.SetDestination(plate.transform.position);

            Vector3 distance = dogAgent.gameObject.transform.position - plate.transform.position;
            Debug.Log("Dog distance to food:" + distance);
            if (Mathf.Abs(distance.x) > 0.2f || Mathf.Abs(distance.z) > 2f)
            {
                _dogAnim.Play("Dog_Walk");
                dogAgent.isStopped = false;
            }
            else
            {
                dogAgent.isStopped = true;
                if (!soundhasPlayed)
                {
                    SoundManager.PlaySound(SoundType.DOGEAT);
                    soundhasPlayed = true;
                }
                
                _dogAnim.Play("Dog_Eating");
            }
        }
        else
        {
            _dogAnim.Play("Dog_Idle");
        }
            
    }

    private IEnumerator DogAttack()
    {
        Debug.Log("dog attacked u");
        DamageTarget();
        canAttack = false;
        _dogAnim.Play("Dog_Attack");
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;

    }


    private void DamageTarget()
    {
        player.gameObject.GetComponent<PlayerController>().playerCurrentHealth = player.gameObject.GetComponent<PlayerController>().playerCurrentHealth - damage;
        
    }

}
