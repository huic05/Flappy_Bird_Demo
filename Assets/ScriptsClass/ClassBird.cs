using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassBird : MonoBehaviour
{
    public float forceScale = 10f;
    private Rigidbody2D _rigidbody;
    public TextMeshProUGUI scoreText;
    private int scorecounter = 0;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriterenderer;
    public Sprite deathsprite;
    private Animator animator;
    private ClassGameScipt gameScript;



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        scoreText.text = "" + scorecounter;
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriterenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _rigidbody.gravityScale = 0;
        gameScript = GameObject.Find("Game Controller").GetComponent<ClassGameScipt>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rigidbody.velocity = forceScale * Vector2.up * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            _rigidbody.gravityScale = 1;
            boxCollider2D.enabled = false;
            spriterenderer.sprite = deathsprite;
            gameScript.FromPlayToLose(scorecounter);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Goal"))
        {
            
            scorecounter++;
            scoreText.text = "" + scorecounter; 
        }
    }
    public void SetUpBird()
    {
        _rigidbody.gravityScale = 0.4f;
        
    }
    public void UpdateBird()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rigidbody.velocity = forceScale * Vector2.up;

        }
    }
}
