using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transparency : MonoBehaviour {
    public GameObject currentGameObject;
    //polovična prozirnost
    public float alpha = 0.5f;
    //materijali trenutnog objekta
    private Material[] currentMat;
    void Start() {
        currentGameObject = gameObject;
        currentMat = currentGameObject.GetComponent<Renderer>().materials;
    }
    //mijenjanje boje svih materijala
    void ChangeAlpha(Material[] mat, float alphaVal) {
        for(int i = 0; i < mat.Length; i++) {
            Color oldColor = mat[i].color;
            Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
            mat[i].SetColor("_Color", newColor);
        }
    }
    //poziva se pri promjenama na slideru
    public void ChangeAlfaOnValueChange(Slider slider) {
        ChangeAlpha(currentMat, slider.value);
    }
}
