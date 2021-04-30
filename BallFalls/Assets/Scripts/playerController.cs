using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Rigidbody2D rb;
    Animator _animator;
    int Speed_Hash = Animator.StringToHash("MoveSpeed");
    public float MovingSpeed = 10.0f;
    float HorizMove;

    // Start is called before the first frame update
    void Start()
    {
      
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizMove = Input.GetAxisRaw("Horizontal") * MovingSpeed;
        Vector3 PlayerScale = transform.localScale;
        if (HorizMove > 0)
            PlayerScale.x = 6f;
        if(HorizMove<0)
            PlayerScale.x = -6f;
        transform.localScale = PlayerScale;
        _animator.SetFloat(Speed_Hash, Mathf.Abs(HorizMove));

            MoveCharacter();
        
        
        
    }
    void MoveCharacter()
    {
        transform.position += new Vector3(HorizMove, 0, 0) * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 7f), transform.position.y, 0);
    }
}
