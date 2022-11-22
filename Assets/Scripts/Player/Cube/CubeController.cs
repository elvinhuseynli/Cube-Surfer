using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public bool isStacked = false;
    public ParticleSystem hitEffect;
    private Vector3 direction = Vector3.forward;
    private RaycastHit hit;

    void FixedUpdate() {
        if (!isStacked)
            return;

        float coeff = 0.2f;

        if (Physics.Raycast(transform.position, direction, out hit, 1f * coeff))
        {
            if (hit.transform.gameObject.CompareTag("Obstacle"))
            {
                CubesManager.Instance.dropCube(this);
            }
        }
    }

    public void playEffect() {
        hitEffect.gameObject.SetActive(true);
        hitEffect.Play();
    }
}
