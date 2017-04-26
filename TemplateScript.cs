using UnityEngine;
using System.Collections;

public class TemplateScript : MonoBehaviour {

    [SerializeField]
    private GameObject finalObject;

    private Vector2 mousePos;

    [SerializeField]
    private LayerMask allTilesLayer;
	
	// Update is called once per frame
	void Update ()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, allTilesLayer);

            if (rayHit.collider != null)
            {
                if (rayHit.collider.gameObject.tag == "GrassTile" && this.gameObject.tag == "HouseTemplate")
                {
                    Instantiate(finalObject, transform.position, Quaternion.identity);
                }
            }
            else if (rayHit.collider == null && this.gameObject.tag == "GrassTemplate")
            {
                Instantiate(finalObject, transform.position, Quaternion.identity);
            }
        }
	}
}
