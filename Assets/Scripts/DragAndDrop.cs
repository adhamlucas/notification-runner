using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col;

    Touch touch;
    Vector2 touchPosition;
    Collider2D touchedCollider;

    public GameObject selectionEffect;
    public GameObject deathEffect;
    private GameMaster gameMaster;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began) {
                touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider) {
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    moveAllowed = true;
                }
            }

            if (touch.phase == TouchPhase.Moved) {
                if (moveAllowed == true) {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            if (touch.phase == TouchPhase.Ended) {
                moveAllowed = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            audioSource.Play();
            gameMaster.GameOver();
        }
    }
}
