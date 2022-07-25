
using UnityEditor.UIElements;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private float _xInput;
    private float _zInput;
    [SerializeField]
    private float speed;
    public float rotatespeed;
    private CharacterController _characterController;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _xInput= Input.GetAxis("Horizontal");
        _zInput = Input.GetAxis("Vertical");

        Vector3 movDirection = new Vector3(_xInput, 0, _zInput);

        float magnitude = Mathf.Clamp01(movDirection.magnitude) * speed;
        movDirection.Normalize();
        
       // transform.Translate(movDirection * speed * Time.deltaTime);

       _characterController.SimpleMove(movDirection * magnitude);

       if (movDirection != Vector3.zero)
       {
           Quaternion torotate = Quaternion.LookRotation(movDirection, Vector3.up);
           transform.rotation = Quaternion.RotateTowards(transform.rotation, torotate, rotatespeed * Time.deltaTime);
       }
    }
}
