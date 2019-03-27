namespace Assets.Scripts
{
    using UnityEngine;

    public class ObstacleDestroyer : MonoBehaviour
    {
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Item")
            {
                ObstacleDestroyer.Destroy(other.gameObject);
            }
        }
    }
}