using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Stuff
    //Reference to attached animator
    private Animator animator;

    //Reference to attached rigidbody 2D
    private Rigidbody2D rb;

    //The direction the player is moving in
    private Vector2 playerDirection;

    //The speed at which they're moving
    private float playerSpeed = 1f;

    [Header("Movement parameters")]
    //The maximum speed the player can move
    [SerializeField] private float playerMaxSpeed = 100f;
    #endregion

    public Image[] heartImages; 

    public Sprite FullHeartSprite; 
    public Sprite HalfHeartSprite;  
    public Sprite EmptyHeartSprite;


    /// <summary>
    /// When the script first initialises this gets called, use this for grabbing componenets
    /// </summary>
    ///
    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] Transform m_firePoint;
    [SerializeField] float m_projectileSpeed;
    [SerializeField] Vector2 m_mousePosition;
    [SerializeField] Vector3 m_mousePointOnScreen;

    public static int health = 10;
    private float damageCooldown = 0f;

    private void Awake()
    {
        //Get the attached components so we can use them later
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of pc perfornamce so physics can be calculated properly
    /// </summary>
    private void FixedUpdate()
    {
        rb.velocity = playerDirection * (playerSpeed * playerMaxSpeed) * Time.fixedDeltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (damageCooldown <= 0) // so that the player doesn't take damage on every frame
            {
                TakeDamage();
            }
        }

    }

    void TakeDamage()
    {
        health--; //reduces player health by 1
        damageCooldown = 1f;
    }

    void IncreaseHealth()
    {
        health++; //increases player health by 1
    }
    private void Update()
    {
        // read input from WASD keys
        playerDirection.x = Input.GetAxis("Horizontal");
        playerDirection.y = Input.GetAxis("Vertical");

        // check if there is some movement direction, if there is something, then set animator flags and make speed = 1
        if (playerDirection.magnitude != 0)
        {
            animator.SetFloat("Horizontal", playerDirection.x);
            animator.SetFloat("Vertical", playerDirection.y);
            animator.SetFloat("Speed", playerDirection.magnitude);

            //And set the speed to 1, so they move!
            playerSpeed = 1f;
        }
        else
        {
            //Was the input just cancelled (released)? If so, set
            //speed to 0
            playerSpeed = 0f;

            //Update the animator too, and return
            animator.SetFloat("Speed", 0);
        }

        // Was the fire button pressed (mapped to Left mouse button or gamepad trigger)
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot (well debug for now)
            //Debug.Log($"Shoot! {Time.time}", gameObject);
            Fire();
        }

        damageCooldown -= Time.deltaTime;

        void Fire() //shoots projectiles towards where the player has clicked
        {
            float customZValue = 10f;
            m_mousePosition = Input.mousePosition;
            m_mousePointOnScreen = Camera.main.ScreenToWorldPoint(new Vector3(m_mousePosition.x, m_mousePosition.y, customZValue));

            Vector2 fireDirection = m_mousePointOnScreen - transform.position;

            GameObject bulletToSpawn = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);

            if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
            {
                bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(fireDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);
            }
        }

        #region HealthUi

        GameObject Heart1 = GameObject.FindWithTag("Heart1");
        Image Heart1Image = Heart1.GetComponent<Image>();
        heartImages[0] = Heart1Image;

        GameObject Heart2 = GameObject.FindWithTag("Heart2");
        Image Heart2Image = Heart2.GetComponent<Image>();
        heartImages[1] = Heart2Image;

        GameObject Heart3 = GameObject.FindWithTag("Heart3");
        Image Heart3Image = Heart3.GetComponent<Image>();
        heartImages[2] = Heart3Image;

        GameObject Heart4 = GameObject.FindWithTag("Heart4");
        Image Heart4Image = Heart4.GetComponent<Image>();
        heartImages[3] = Heart4Image;

        GameObject Heart5 = GameObject.FindWithTag("Heart5");
        Image Heart5Image = Heart5.GetComponent<Image>();
        heartImages[4] = Heart5Image;

        if (health == 10)
        {
            heartImages[0].sprite = FullHeartSprite;
            heartImages[1].sprite = FullHeartSprite;
            heartImages[2].sprite = FullHeartSprite;
            heartImages[3].sprite = FullHeartSprite;
            heartImages[4].sprite = FullHeartSprite;
        }

        else if (health == 9)
        {
            heartImages[0].sprite = FullHeartSprite;
            heartImages[1].sprite = FullHeartSprite;
            heartImages[2].sprite = FullHeartSprite;
            heartImages[3].sprite = FullHeartSprite;
            heartImages[4].sprite = HalfHeartSprite;
        }

        else if (health == 8)
        {
            heartImages[0].sprite = FullHeartSprite;
            heartImages[1].sprite = FullHeartSprite;
            heartImages[2].sprite = FullHeartSprite;
            heartImages[3].sprite = FullHeartSprite;
            heartImages[4].sprite = EmptyHeartSprite;
        }

        else if (health == 7)
        {
            heartImages[0].sprite = FullHeartSprite;
            heartImages[1].sprite = FullHeartSprite;
            heartImages[2].sprite = FullHeartSprite;
            heartImages[3].sprite = HalfHeartSprite;
            heartImages[4].sprite = EmptyHeartSprite;
        }

        else if (health == 6)
        {
            heartImages[0].sprite = FullHeartSprite;
            heartImages[1].sprite = FullHeartSprite;
            heartImages[2].sprite = FullHeartSprite;
            heartImages[3].sprite = EmptyHeartSprite;
            heartImages[4].sprite = EmptyHeartSprite;
        }

        else if (health == 5)
        {
            heartImages[0].sprite = FullHeartSprite;
            heartImages[1].sprite = FullHeartSprite;
            heartImages[2].sprite = HalfHeartSprite;
            heartImages[3].sprite = EmptyHeartSprite;
            heartImages[4].sprite = EmptyHeartSprite;
        }

        else if (health == 4)
        {

            heartImages[0].sprite = FullHeartSprite;
            heartImages[1].sprite = FullHeartSprite;
            heartImages[2].sprite = EmptyHeartSprite;
            heartImages[2].sprite = EmptyHeartSprite;
            heartImages[2].sprite = EmptyHeartSprite;
        }



        else if (health == 3)
        {
            heartImages[0].sprite = FullHeartSprite;
            heartImages[1].sprite = HalfHeartSprite;
            heartImages[2].sprite = EmptyHeartSprite;
            heartImages[3].sprite = EmptyHeartSprite;
            heartImages[4].sprite = EmptyHeartSprite;
        }


        else if (health == 2)
        {
            heartImages[0].sprite = FullHeartSprite;
            heartImages[1].sprite = EmptyHeartSprite;
            heartImages[2].sprite = EmptyHeartSprite;
            heartImages[3].sprite = EmptyHeartSprite;
            heartImages[4].sprite = EmptyHeartSprite;
        }


        else if (health == 1)
        {
            heartImages[0].sprite = HalfHeartSprite;
            heartImages[1].sprite = EmptyHeartSprite;
            heartImages[2].sprite = EmptyHeartSprite;
            heartImages[3].sprite = EmptyHeartSprite;
            heartImages[4].sprite = EmptyHeartSprite;
        }

        else
        {
            heartImages[0].sprite = EmptyHeartSprite;
            heartImages[1].sprite = EmptyHeartSprite;
            heartImages[2].sprite = EmptyHeartSprite;
            heartImages[3].sprite = EmptyHeartSprite;
            heartImages[4].sprite = EmptyHeartSprite;
        }


        
        #endregion

        if (health > 10) //so that the health cannot go above 10
        {
            health = 10;
        }

        //kills the player
        if (health <= 0)
        {
            health = 0;

            DeathScreenScript.finalScore = ScoreSystem.score;
            DeathScreenScript.finalDiamonds = DiamondSystem.diamondCount;

            SceneManager.LoadScene("DeathScreen");

            gameObject.SetActive(false);

        }
    }


}
