using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    private float speed = 500f;
    
    private Vector3 dir = new Vector3(1, 0, 0);

    private IEnumerator DeleteBullet()
    {
        //µÈ´ý5f    ×Óµ¯Ïú»Ù
        yield return new WaitForSeconds(5);
        //GameObject.Destroy(gameObject);
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteBullet());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
