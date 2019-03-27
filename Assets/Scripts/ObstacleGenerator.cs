namespace Assets.Scripts
{
    using UnityEngine;

    public class ObstacleGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] obstacles;

        private int playerDistance = -1;

        [SerializeField]
        private GameObject player;

        public GameObject[] Obstacles { get => this.obstacles; set => this.obstacles = value; }

        public GameObject Player { get => this.player; set => this.player = value; }

        // Start is called before the first frame update
        private void Start()
        {
            // Empty
        }

        private void CreateObstacle()
        {
            // Position and offset between obstacle and player
            const int SpaceOffset = 25;
            int obstacleSpawnPosition = (int)this.Player.transform.position.y + SpaceOffset;

            // Select random obstacle
            int randomObstacleCounter = UnityEngine.Random.Range(0, this.obstacles.Length);

            ObstacleGenerator.Instantiate(this.obstacles[randomObstacleCounter], new Vector3(0, obstacleSpawnPosition), Quaternion.identity);
        }

        // Update is called once per frame
        private void Update()
        {
            int currentPlayerDistance = (int)(this.Player.transform.position.y / (125 / 2));

            if (this.playerDistance != currentPlayerDistance)
            {
                this.CreateObstacle();
                this.playerDistance = currentPlayerDistance;
            }

            ///transform.Rotate(Vector3.forward * Time.deltaTime * 3);
        }
    }
}
