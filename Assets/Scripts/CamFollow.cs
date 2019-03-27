namespace Assets.Scripts
{
    using UnityEngine;

    public class CamFollow : MonoBehaviour
    {
        private GameObject playerTransform;

        // Start is called before the first frame update
        private void Start()
        {
           this.playerTransform = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        private void Update()
        {
            // Empty
        }

        private void LateUpdate()
        {
            Vector3 temp = transform.position;

            temp.y = this.playerTransform.transform.position.y;
            transform.position = temp;
        }
    }
}