using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;
    private BirdController birdController;

    private void Start()
    {
        // Find the bird controller in the scene
        birdController = GameObject.FindObjectOfType<BirdController>();
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10) // Destroy pipes off-screen
        {
            Destroy(gameObject);
        }
    }
}