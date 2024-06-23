using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //la componente tranform
    Transform player;
    public float yDistance = 4.5f;//distancia que se debe alejar el jugador para activar el movimiento
    public float yMovement = 9f;//tamaño de la pantalla en y

    public float xDistance = 4.5f;   
    public float xMovement = 9f;//tamaño de la pantalla en x


    public Vector3 cameraOrigin;//es la posicion de la camara antes de empezar la trancision
    public Vector3 cameraDirection;//el final de la trancision

    public float movementTime = 0.5f;//tiempo de la transicion en segundos
    public bool isMoving;//Variable de control para que no se mueva contantemente la camara

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            //miramos la posicion del jugador - la posicion de la camara.
            if (player.position.y - transform.position.y >= yDistance)
            {
                cameraDirection += new Vector3(0, yMovement,0);
                StartCoroutine(MoveCamera());
                //corutinas
            }
            else if (transform.position.y - player.position.y >= yDistance)
            {
                cameraDirection -= new Vector3(0,yMovement,0 );
                StartCoroutine(MoveCamera());
            }
            else if (player.position.x - transform.position.x >= xDistance)
            {
                cameraDirection += new Vector3(xMovement,0,0);
                StartCoroutine(MoveCamera());
            }
            else if (transform.position.x - player.position.x >= xDistance)
            {
                cameraDirection -= new Vector3(xMovement,0,0);
                StartCoroutine(MoveCamera());
            }
        }

    }
    IEnumerator MoveCamera()
    {
        isMoving = true;
        var currentPos = transform.position;//posicion actual de la camara
        var t = 0f;//el step
        while (t < 1)
        {
            t += Time.deltaTime / movementTime;//es la velocidad de la animacion de paso de camara
            transform.position = Vector3.Lerp(currentPos, cameraDirection,t );//esto es el movimiento de la camara de la posicion principal a la final
            transform.position = new Vector3(transform.position.x, transform.position.y, currentPos.z);//es para la posicion en z siempre sea -10 en este caso
            yield return null;
        }
        isMoving = false;

    }
}
