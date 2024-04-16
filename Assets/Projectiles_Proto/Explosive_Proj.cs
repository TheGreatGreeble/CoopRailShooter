using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Proj : Proj_Move
{
    public float expl_radius = 3;
    private SphereCollider sc;
    public override void Start()
    {
        base.Start();
        sc = gameObject.GetComponent<SphereCollider>();
        sc.radius = 0.3f;
        StartCoroutine("explode");
    }
    private void OnTriggerEnter(Collider other) {
        damageEntity(other.gameObject);
    }
    private IEnumerator explode()
    {
        Debug.Log("exploding");
        float cur_rad = sc.radius;
        while (cur_rad < expl_radius) {
            cur_rad += 0.2f;
            sc.radius = cur_rad;
            yield return new WaitForFixedUpdate();
            //cur_rad = Mathf.Lerp(cur_rad, expl_radius, 0.5f);
        }
        Destroy(gameObject);
    }
}
