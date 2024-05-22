using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile1 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    private ManagerScene managerScene;
    public int puntos = 1;

    private void Start() {
        myRB = GetComponent<Rigidbody2D>();
        managerScene = FindObjectOfType<ManagerScene>();
    }
   

    private void Update() {
        float angle = Mathf.Atan2(myRB.velocity.y, myRB.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Muro"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Objetivo"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

            if (managerScene != null)
            {
                managerScene.IncrementarPuntos();
            }
        }
    }

}
