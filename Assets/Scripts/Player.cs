namespace Assets.Scripts
{
    using System.Collections;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        private readonly int xSpeed = Constants.XHorizontalSpeed;
        private readonly int ySpeed = Constants.YVerticalSpeed;

        [SerializeField]
        private GameObject deathEffectObject;

        private float angle = Constants.Angle;
        private Rigidbody2D playerRigi;
        private GameManager gameManagerObject;
        private bool playerIsDead = false;

        public GameObject DeathEffectObject { get => this.deathEffectObject; set => this.deathEffectObject = value; }

        private void Awake()
        {
            this.playerRigi = this.GetComponent<Rigidbody2D>();
            this.gameManagerObject = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            // Empty
        }

        // Update is called once per frame
        private void Update()
        {
            // Empty
        }

        private void FixedUpdate()
        {
            if (this.playerIsDead)
            {
                return;
            }

            this.PlayerInput();
            this.PlayerMovement();
        }

        private void PlayerMovement()
        {
            Vector2 playerPosition = transform.position;

            const int XHorizontalSpaceMovement = 4;
            playerPosition.x = Mathf.Cos(this.angle) * XHorizontalSpaceMovement;

            transform.position = playerPosition;
            this.angle += Time.deltaTime * this.xSpeed;
        }

        private void PlayerInput()
        {
            if (Input.GetMouseButton(0))
            {
                this.playerRigi.AddForce(new Vector2(0, this.ySpeed));
            }
            else
            {
                if (this.playerRigi.velocity.y > 0)
                {
                    this.playerRigi.AddForce(new Vector2(0, -this.ySpeed));
                }
                else
                {
                    this.playerRigi.velocity = new Vector2(this.playerRigi.velocity.x, 0);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Obstacle")
            {
                this.StartCoroutine(this.PlayerDeath());
            }
            else if (other.gameObject.tag == "Item")
            {
                Player.Destroy(other.gameObject);
                this.gameManagerObject.ScoreIncrement();
            }
        }

        private IEnumerator PlayerDeath()
        {
            this.playerIsDead = true;
            this.StopPlayerMovement();

            Player.Destroy(Player.Instantiate(this.DeathEffectObject, transform.position, Quaternion.identity), 1.5f);
            yield return new WaitForSeconds(1.5f);
            
            this.gameManagerObject.GameOver();
        }

        private void StopPlayerMovement()
        {
            this.playerRigi.velocity = Vector2.zero;
            this.playerRigi.isKinematic = true;
        }
    }
}