using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColision : MonoBehaviour {

    int damage;

    void start() {
        this.damage = 0;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Contains("pessoa")) {
            updateDamage(10);
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.name.Contains("pessoa")) {
            updateDamage(1);
        }

    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.name.Contains("pessoa")) {
        }
    }

    void updateDamage(int value) {
        damage += value;
        GameObject placar = GameObject.Find("placar");
        placar.gameObject.GetComponent<Text>().text = this.damage.ToString();
    }
}
