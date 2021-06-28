using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLightManager : MonoBehaviour
{
    public static AmbientLightManager Instance;

    public Camera camera;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    public Color color8;
    public Color color9;
    public Color color10;
    public Color color11;
    public Color color12;
    public Color color13;
    public Color color14;
    public Color color15;
    public Color color16;
    public Color color17;
    public Color color18;
    public Color color19;
    public Color color20;
    public Color color21;
    public Color color22;
    public Color color23;
    public Color color24;
    public Color color25;
    public Color color26;
    public Color color27;
    public Color color28;
    public Color color29;
    public Color color30;

    private int actualColor;
    private const float COLOR_CHANGE_SPEED = 0.15f;
    private float playerYChangeColor = 200f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        actualColor = Mathf.FloorToInt(Player.Instance.transform.position.y / playerYChangeColor);

        switch (actualColor)
        {
            case 0: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color1, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 1: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color2, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 2: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color3, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 3: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color4, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 4: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color5, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 5: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color6, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 6: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color7, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 7: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color8, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 8: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color9, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 9: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color10, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 10: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color11, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 11: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color12, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 12: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color13, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 13: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color14, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 14: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color15, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 15: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color16, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 16: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color17, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 17: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color18, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 18: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color19, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 19: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color20, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 20: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color21, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 21: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color22, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 22: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color23, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 23: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color24, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 24: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color25, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 25: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color26, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 26: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color27, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 27: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color28, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 28: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color29, Time.deltaTime * COLOR_CHANGE_SPEED); break;
            case 29: camera.backgroundColor = Color.Lerp(camera.backgroundColor, color30, Time.deltaTime * COLOR_CHANGE_SPEED); break;
        }
    }

    public void ChangeColor()
    {
        if (actualColor < 30)
            actualColor++;
        else
            actualColor = 0;
    }
}
