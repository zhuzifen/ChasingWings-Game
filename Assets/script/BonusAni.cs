using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAni : MonoBehaviour
{
    public float r = 0;
    public float amplitude = 0.1f;
    public float speed = 2f;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        r += Time.deltaTime * speed;
        float newY = Mathf.Cos(r) * amplitude;
        transform.position = pos + Vector3.up * newY;
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
    }
}
