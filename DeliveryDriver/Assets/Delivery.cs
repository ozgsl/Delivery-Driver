using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour{
    bool hasPackage = false;
    [SerializeField] float delay = 0.3f;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer;

//play tusuna basınca gerçekleşmesini istediğimiz yer yani start fonku içinde yazılacak
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //we gona use other start/update methods like unity's methods
    //and gone delete private access cuz we cant use if this like
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("You Failed!");
    }
    void OnTriggerEnter2D(Collider2D other) {
        //if(blabla), then print package picked up.
       if(other.tag == "Package"&&hasPackage == false){
        hasPackage = true;

        Debug.Log("Package picked up!");
        Destroy(other.gameObject, delay);

        spriteRenderer.color = hasPackageColor;
    }
       if(other.tag == "Customer"&&hasPackage == true){
        Debug.Log("Package delivered.");
        hasPackage = false;
        spriteRenderer.color = noPackageColor;
       }
    }
}