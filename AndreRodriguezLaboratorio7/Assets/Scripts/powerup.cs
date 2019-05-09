using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start() => startPos = transform.position;

    // Update is called once per frame
    void Update() => transform.position = startPos + new Vector2(0, Mathf.Sin(Time.time)*0.5f);
}
