using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Key : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    public GameObject shootPoint;
    private bool activated = true;
    private Keyboard keyboard;
    private TreeGameManager gameManager;
    private Color color;
    private ParticleSystem particles;
    [SerializeField]
    public string mainScene = "Game Scene";

    void OnEnable() {
        EventManager.beatEvent += FireProjectile;
	}

	void OnDisable() {
        EventManager.beatEvent -= FireProjectile;
	}

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<TreeGameManager>().GetComponent<TreeGameManager>();
        keyboard = GameObject.FindGameObjectWithTag("Keyboard").GetComponent<Keyboard>();
        color = Color.blue;
        particles = this.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


                if (hit.collider != null)
                {
                    // if in select root mode, this key will be set as root
                    if (gameManager.selectRootMode)
                    {
                        updateRoot(hit.collider.gameObject.tag);
                    }
                    if (gameManager.gameOver)
                    {
                        GameObject.FindObjectOfType<SceneController>().loadScene(mainScene);
                    }
                }

            }
        
        
    }

    private void FireProjectile(int beat) {
        if (this.activated) {
            projectile.GetComponent<SpriteRenderer>().color = color;
            projectile.GetComponentInChildren<TrailRenderer>().startColor = color;
            Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
            MainModule psMain = particles.main;
            psMain.startColor = color;
            particles.Play();
        }
    }

    public void deactivate()
    {
        activated = false;
        foreach (Transform c in transform.GetComponentsInChildren<Transform>())
        {
            if (c.GetComponent<SpriteRenderer>() != null)
            {
                c.GetComponent<SpriteRenderer>().enabled = false;
                c.GetComponent<SpriteRenderer>().color = Color.clear;
            }
                
        }
    }

    public void activate()
    {
        Color bonkersColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        color = bonkersColor;
        activated = true;
        // get children
        foreach (Transform c in transform.GetComponentsInChildren<Transform>())
        {
            if (c.GetComponent<SpriteRenderer>() != null)
            {
                c.GetComponent<SpriteRenderer>().enabled = true;
                c.GetComponent<SpriteRenderer>().color = bonkersColor;
            }
                
        }
    }

    private void updateRoot(string tag)
    {
        EventManager.Pitch(tag);
        keyboard.setRoot(tag);
    }

}
