using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float xInitialForce;
    public float yInitialForce;
    private Vector2 trajectoryOrigin;

    // Start is called before the first frame update

void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        // Jika nilainya di bawah 1, bola bergerak ke kiri. 
        // Jika tidak, bola bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan bola ini.
            rb2d.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rb2d.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }
    void Start()
    {
    rb2d = GetComponent<Rigidbody2D>();
    Invoke("PushBall", 2);
    trajectoryOrigin = transform.position;
    }

    void ResetBall(){
    rb2d.velocity = Vector2.zero;
    transform.position = Vector2.zero;
    }

    void RestartGame(){
    ResetBall();
    Invoke("Pushball", 1);
}

    void OnCollisionEnter2D (Collision2D coll) {
    if(coll.collider.CompareTag("Player")){
        Vector2 vel;
        vel.x = rb2d.velocity.x;
        vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
        rb2d.velocity = vel;
    }
}

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

        public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
    
}
