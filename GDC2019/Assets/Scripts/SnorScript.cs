using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnorScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject Player;
    public GameObject Hook;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, Hook.transform.position);
        lineRenderer.SetPosition(1, Player.transform.position);
    }
}
