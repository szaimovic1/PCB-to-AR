using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationScaleMove : MonoBehaviour {
    public Slider sliderRotate, sliderMove, sliderScale;
    public ToggleGroup tgX, tgY, tgZ;
    private float x = 0, y = 0, z = 0;
    void Start() {
        sliderRotate.onValueChanged.AddListener(delegate {
            RotateMe();
        });
        sliderMove.onValueChanged.AddListener(delegate {
            MoveMe();
        });
        sliderScale.onValueChanged.AddListener(delegate {
            ScaleMe();
        });
    }
    public void RotateMe() {
        defineAxis();
        transform.RotateAround(this.transform.position, new Vector3(x, y, z), 90 * Time.deltaTime);
        resetAxis();
    }
    public void ScaleMe() {
        defineAxis();
        Vector3 newScale = new Vector3(this.transform.localScale.x +sliderScale.value * x, 
          this.transform.localScale.y + sliderScale.value * y, this.transform.localScale.z + sliderScale.value * z);
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime);
        resetAxis();
    }
    public void MoveMe() {
        defineAxis();
        Vector3 NewPos = new Vector3(this.transform.position.x + sliderMove.value * x, 
          this.transform.position.y + sliderMove.value * y, this.transform.position.z + sliderMove.value * z);
        transform.position = Vector3.Lerp(transform.position, NewPos, Time.deltaTime);
        resetAxis();
    }
    //određuje smijer obavljanja funkcije
    private void defineAxis() {
        Toggle[] toggles = tgX.GetComponentsInChildren<Toggle>();
        if (toggles[0].isOn) x = 1;
        else if (toggles[1].isOn) x = -1;
        toggles = tgY.GetComponentsInChildren<Toggle>();
        if (toggles[0].isOn) y = 1;
        else if (toggles[1].isOn) y = -1;
        toggles = tgZ.GetComponentsInChildren<Toggle>();
        if (toggles[0].isOn) z = 1;
        else if (toggles[1].isOn) z = -1;
    }
    //restart vrijednosti za ispravno ponovno pomijeranje slidera
    private void resetAxis() {
        x = 0;
        y = 0;
        z = 0;
    }
}