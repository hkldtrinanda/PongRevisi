using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;
    private ContactPoint2D lastContactPoint;
    // Skor pemain
    private int score;

    // Untuk mengakses informasi titik kontak dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    // Ketika terjadi tumbukan dengan bola, rekam titik kontaknya.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Dapatkan kecepatan raket sekarang.
        Vector2 velocity = rb2d.velocity;

        // Jika pemain menekan tombol ke atas, beri kecepatan positif ke komponen y (ke atas).
        if (Input.GetKey(moveUp))
        {
            velocity.y = speed;
        }

        // Jika pemain menekan tombol ke bawah, beri kecepatan negatif ke komponen y (ke bawah).
        else if (Input.GetKey(moveDown))
        {
            velocity.y = -speed;
        }

        // Jika pemain tidak menekan tombol apa-apa, kecepatannya nol.
        else
        {
            velocity.y = 0.0f;
        }

        // Masukkan kembali kecepatannya ke rigidBody2D.
        rb2d.velocity = velocity;
        var pos = transform.position;
    if (pos.y > boundY) {
        pos.y = boundY;
    }
    else if (pos.y < -boundY) {
        pos.y = -boundY;
    }
    transform.position = pos;
    }
    
    // Menaikkan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }

    // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    // Mendapatkan nilai skor
    public int Score
    {
        get { return score; }
    }
}