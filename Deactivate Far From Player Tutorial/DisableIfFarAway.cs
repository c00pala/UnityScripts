using UnityEngine;
using System.Collections;

public class DisableIfFarAway : MonoBehaviour {

    // --------------------------------------------------
    // Variables:

    private GameObject itemActivatorObject;
    private ItemActivator activationScript;

	// --------------------------------------------------

	void Start()
	{
        itemActivatorObject = GameObject.Find("ItemActivatorObject");
        activationScript = itemActivatorObject.GetComponent<ItemActivator>();

        StartCoroutine("AddToList");
    }

    IEnumerator AddToList()
    {
        yield return new WaitForSeconds(0.1f);

        activationScript.activatorItems.Add(new ActivatorItem { item = this.gameObject, itemPos = transform.position });
    }
}
