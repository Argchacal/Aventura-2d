using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    Vector2 direction;
    // para saber la direccion (1,0) derecha  (1,0) abajo  (1,0) arriba e isquierda
    Rigidbody2D rigidbody;// el componente que creamos en el prsonaje para la fisica
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();       
        animator = GetComponent<Animator>();    
    }
    private void FixedUpdate() {
        rigidbody.velocity = direction * speed;//asigna la direccion en base a la direccion
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Animations();
    }

    private void Movement()     
    {
        //asigna valores al vector 2 toma el valor del input
        //las teclas estan predeterminadas en unity y podemos verlo en edit proyect setting, input manager
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void Animations()
    {
        //si, la magnitud de direccion no es 0 reproduce la animacion run
        if (direction.magnitude != 0)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.Play("Run");
        }
        else
        {
            animator.Play("Idle");
        }
    }
}
