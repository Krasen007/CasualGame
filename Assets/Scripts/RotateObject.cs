namespace Assets.Scripts
{
    using UnityEngine;

    public class RotateObject : MonoBehaviour
    {
        private const int RotateSpeed = 75;

        // Start is called before the first frame update
        private void Start()
        {
            // Empty
        }

        // Update is called once per frame
        private void Update()
        {
            // Empty
            transform.Rotate(Vector3.forward * Time.deltaTime * RotateSpeed);
        }
    }
}