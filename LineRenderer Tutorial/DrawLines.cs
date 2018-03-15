using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour {

    #region Object Variables
    [SerializeField]
    private GameObject lineGeneratorPrefab;
    [SerializeField]
    private GameObject linePointPrefab;
    #endregion

    private void Update()
    {
        // If left mouse clicked.
        if (Input.GetMouseButtonDown(0))
        {
            // Get position of mouse, set Z to 0.
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;

            // Create a point marker object at newPos.
            CreatePointMarker(newPos);
        }

        // If right mouse clicked.
        if (Input.GetMouseButtonDown(1))
        {
            // Destroy all point markers in game.
            ClearAllPoints();
        }

        // If E key pressed.
        if (Input.GetKeyDown("e"))
        {
            // Create a line running through all points.
            GenerateNewLine();
        }
    }

    private void CreatePointMarker(Vector3 pointPosition)
    {
        // Spawn point marker at pointPosition.
        Instantiate(linePointPrefab, pointPosition, Quaternion.identity);
    }

    private void ClearAllPoints()
    {
        // Get GameObject array of all objects with tag 'PointMarker'.
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("PointMarker");

        // For each object in array, destroy it.
        foreach (GameObject p in allPoints)
        {
            Destroy(p);
        }
    }

    private void GenerateNewLine()
    {
        // Get GameObject array of all objects with tag 'PointMarker'.
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("PointMarker");
        // Initialise new Vector3 array, length = allPoints.Length.
        Vector3[] allPointPositions = new Vector3[allPoints.Length];

        // If 2 or more points in game.
        if (allPoints.Length >= 2)
        {
            // Loop to assign Vector3 to allPointPositions from allPoint object's transform.position.
            for (int i = 0; i < allPoints.Length; i++)
            {
                allPointPositions[i] = allPoints[i].transform.position;
            }

            // Run function to create line, give it allPointPositions array as parameter.
            SpawnLineGenerator(allPointPositions);
        }
        else
        {
            // Error if < 2 points in game.
            Debug.Log("Need 2 or more points to draw a line.");
        }
    }

    private void SpawnLineGenerator(Vector3[] linePoints)
    {
        // Create new LineHolder object.
        GameObject newLineGen = Instantiate(lineGeneratorPrefab);
        // Get reference to newLineGen's LineRenderer.
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();

        // Set amount of LineRenderer positions = amount of line point positions.
        lRend.positionCount = linePoints.Length;
        // Set positions of LineRenderer using linePoints array.
        lRend.SetPositions(linePoints);

        // Destroy line after 5 seconds.
        Destroy(newLineGen, 5);
    }
}