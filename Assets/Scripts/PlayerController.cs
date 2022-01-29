using Assets.Scripts;
using Assets.Scripts.Additional;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;

    public Rigidbody2D rigidbody;
    public int crystalCount = 0;
    private Vector2 moveV;
    private Collider2D coll;

    [SerializeField]
    private LayerMask walls;

    private float fallTime = 0f;
    // Start is called before the first frame update


    private GameObject[] realObjects;
    private GameObject[] ghostObjects;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        realObjects = GameObject.FindGameObjectsWithTag("RealWorldItem");
        ghostObjects = GameObject.FindGameObjectsWithTag("GhostWorldItem");

        foreach (var obj in realObjects)
        {
            obj.SetActive(false);
        }
        foreach (var obj in ghostObjects)
        {
            obj.SetActive(true);
        }
    }

    void Update()
    {
        if (gameObject.active)
        {
            Vector2 moveInput = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));
            moveV = moveInput.normalized * speed;

        }
    }


    void FixedUpdate()
    {
        if (gameObject.active)
        {
            rigidbody.MovePosition(rigidbody.position + moveV * Time.fixedDeltaTime);
        }
    }
    
    public void Show()
    {
        gameObject.tag = "Player";
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().playerObject = gameObject;

        foreach (var obj in realObjects)
        {
            obj.SetActive(false);
        }        
        foreach (var obj in ghostObjects)
        {
            obj.SetActive(true);
        }
    }

    public void Hide()
    {
        gameObject.tag = "Invader";
        gameObject.SetActive(false);

        foreach (var obj in realObjects)
        {
            obj?.SetActive(true);
        }
        foreach (var obj in ghostObjects)
        {
            obj?.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (fallTime > 0.4f && rigidbody.IsSleeping())
            {
                rigidbody.WakeUp();

                collision.gameObject.GetComponent<AControllableNPC>().SetInvader(gameObject);
                collision.gameObject.GetComponent<AControllableNPC>().ChangeState();
                Hide();
                fallTime = 0f;
            }
            else
            {
                rigidbody.Sleep();
                fallTime += Time.fixedDeltaTime;
            }

            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyUnit")
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        else if (collision.gameObject.tag == "GhostWorldItem")
        {
            crystalCount++;
            DestroyGhostItem(collision.gameObject);
        }
    }

    private void DestroyGhostItem(GameObject obj)
    {
        var index = -1;
        for (var i = 0; i < ghostObjects.Length; i++)
        {
            if (ghostObjects[i] == obj)
                index = i;
        }
        ghostObjects[index] = null;
        for (var i = index + 1; i < ghostObjects.Length; i++)
        {
            ghostObjects[i - 1] = ghostObjects[i];
             
        }
        Destroy(obj);
    }
}
