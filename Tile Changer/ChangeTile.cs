#if (UNITY_EDITOR)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ChangeTile : MonoBehaviour {

    public GameObject[] tiles;
    public int tileToChangeInto;

    public void UpdateTiles()
    {
        TileChanger[] selectedTiles = GameObject.FindObjectsOfType<TileChanger>();

        if (tileToChangeInto >= tiles.Length)
        {
            Debug.Log("ERROR: tileToChangeInto > array objects.");
        }
        else if (selectedTiles.Length < 1)
        {
            Debug.Log("ERROR: No tiles found (Have you attached the TileChanger script?)");
        }
        else
        {
            bool selectedTileFound = false;

            foreach (TileChanger tileScript in selectedTiles)
            {
                if (tileScript.changeMe == true)
                {
                    GameObject newTile = Instantiate(tiles[tileToChangeInto], tileScript.gameObject.transform.position, tileScript.gameObject.transform.rotation);
                    newTile.transform.SetParent(tileScript.gameObject.transform.parent);
                    newTile.GetComponent<TileChanger>().changeMe = true;
                    DestroyImmediate(tileScript.gameObject, false);

                    selectedTileFound = true;
                }
            }

            if (selectedTileFound == false)
            {
                Debug.Log("ERROR: No selected tiles found (set 'changeMe' to true on the tile)");
            }
        }
    }

    public void ClearSelected()
    {
        TileChanger[] selectedTiles = GameObject.FindObjectsOfType<TileChanger>();

        if (selectedTiles.Length < 1)
        {
            Debug.Log("ERROR: No tiles found (Have you attached the TileChanger script?)");
        }
        else
        {
            bool selectedTileFound = false;

            foreach (TileChanger tileScript in selectedTiles)
            {
                if (tileScript.changeMe == true)
                {
                    tileScript.changeMe = false;
                    selectedTileFound = true;
                }
            }

            if (selectedTileFound == false)
            {
                Debug.Log("ERROR: No selected tiles found");
            }
        }
    }
}

[CustomEditor(typeof(ChangeTile))]
public class ChangeEditor : Editor
{
    ChangeTile myScript;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (myScript == null)
        {
            myScript = (ChangeTile)target;
        }

        if (GUILayout.Button("Update Tiles"))
        {
            myScript.UpdateTiles();
        }

        if (GUILayout.Button("Clear Selected Tiles"))
        {
            myScript.ClearSelected();
        }
    }
}
#endif