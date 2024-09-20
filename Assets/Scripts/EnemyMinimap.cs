using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinimap : MonoBehaviour
{
    GameObject[] enemies;
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // for each enemy in the scene, create a minimap sphere color red, belong to the minimap layer, let the sphere be a child of the enemy
        foreach (GameObject enemy in enemies)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(2f, 2f, 2f);
            sphere.GetComponent<Renderer>().material.color = Color.red;
            sphere.layer = LayerMask.NameToLayer("MinimapTile");
            sphere.transform.position = enemy.transform.position + new Vector3(0, 0.2f, 0);
            sphere.transform.SetParent(enemy.transform);
        }
    }

    private void Update() {
    }
}
