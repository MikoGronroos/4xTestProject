using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MapShower : MonoBehaviour
{

    [SerializeField] private ProvinceConfig _model;
    [SerializeField] private ProvinceDataConfig _config;

    [SerializeField] private ProvinceDataEventChannelSO _provinceDataEvent;

    int width;
    int height;

    Color32[] mapArr;
    Texture2D paletteTex;

    Color32 prevColor;
    bool selectAny = false;

    // Start is called before the first frame update
    void Start()
    {
        var material = GetComponent<Renderer>().material;
        var mainTex = material.GetTexture("_MainTex") as Texture2D;
        var mainArr = mainTex.GetPixels32();

        width = mainTex.width;
        height = mainTex.height;

        var main = new Dictionary<Color32, Color32>();
        mapArr = new Color32[mainArr.Length];
        int idx = 0;
        for(int i=0; i<mainArr.Length; i++){
            var mainColor = mainArr[i]; // takes the rgb value of the province
            if (!main.ContainsKey(mainColor))
            {
                main[mainColor] = mainColor;
                idx++;
            }
            var color = main[mainColor];
            mapArr[i] = color;
        }

        var paletteArr = new Color32[256*256];
        for(int i=0; i<paletteArr.Length; i++){
            paletteArr[i] = new Color32(255, 255, 255, 255);
        }

        var remapTex = new Texture2D(width, height, TextureFormat.RGBA32, false);
        remapTex.filterMode = FilterMode.Point;
        remapTex.SetPixels32(mapArr);
        remapTex.Apply(false);
        material.SetTexture("_RemapTex", remapTex);

        paletteTex = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        paletteTex.filterMode = FilterMode.Point;
        paletteTex.SetPixels32(paletteArr);
        paletteTex.Apply(false);
        material.SetTexture("_PaletteTex", paletteTex);

    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo)){
            var p = hitInfo.point;
            int x = (int)Mathf.Floor(p.x) + width / 2;
            int y = (int)Mathf.Floor(p.y) + height / 2;

            var color = mapArr[x + y * width];

            if (Input.GetMouseButtonDown(0))
            {
                if (!selectAny || !prevColor.Equals(color))
                {
                    if (selectAny)
                    {
                        changeColor(prevColor, new Color32(255, 255, 255, 255));
                    }
                    selectAny = true;
                    prevColor = color;
                    var province = _model.Provinces[color];
                    _provinceDataEvent.Raise(province.name, _config.GetProvinceData(province.id));
                    changeColor(color, new Color32(50, 0, 255, 255));
                    paletteTex.Apply(false);
                }
            }
        }
    }

    void changeColor(Color32 remapColor, Color32 showColor){
        int xp = remapColor[0];
        int yp = remapColor[1];

        paletteTex.SetPixel(xp, yp, showColor);
    }
}
