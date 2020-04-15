using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
   RequestOnServer requestOn = new RequestOnServer();
   public void OnClick()
   {
      StartCoroutine(requestOn.Connection());

   }
}
