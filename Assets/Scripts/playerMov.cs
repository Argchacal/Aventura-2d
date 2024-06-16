using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction;
    // para saber la direccion (1,0) derecha  (1,0) abajo  (1,0) arriba e isquierda

    Rigidbody2D rigidbody;// el componente que creamos en el prsonaje para la fisica
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();        
    }
    private void FixedUpdate() {
        rigidbody.velocity = direction * speed;//asigna la direccion en base a la direccion
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()     
    {
        //asigna valores al vector 2 toma el valor del input
        //las teclas estan predeterminadas en unity y podemos verlo en edit proyect setting, input manager
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
