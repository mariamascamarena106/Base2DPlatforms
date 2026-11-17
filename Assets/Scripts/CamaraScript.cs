using UnityEngine;

public class CamaraScript : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        transform.position = playerTransform.position - offset;

    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = playerTransform.position - offset;
        transform.position = Vector3.Lerp(transform.position, playerTransform.position - offset, speed);

    }
}
