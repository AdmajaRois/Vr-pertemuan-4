using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;
    public Text kubuText;

    public int jarak;
    private RaycastHit _hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gvrStatus){
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
            print("Bagus");
            kubuText.text = "Kubu merah";
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray,out _hit, jarak))
        {
            if (_hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                kubuText.text = "Kubu merah";
            }
        }
    }
  

    public void GVRon(){
        gvrStatus = true;
        print("GVR ON");
    }

    public void GVRoff(){
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
