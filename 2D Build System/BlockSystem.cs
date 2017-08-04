// System required for [Serializable] attribute.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSystem : MonoBehaviour {

    // Arrays for all solid blocks.
    // The two arrays need to match up.

    /*[SerializeField]
    private Sprite[] solidBlocks;
    [SerializeField]
    private string[] solidNames;

    // Arrays to store backing blocks.
    // As before, ensure these match up!!
    [SerializeField]
    private Sprite[] backingBlocks;
    [SerializeField]
    private string[] backingNames;*/

    [SerializeField]
    private BlockType[] allBlockTypes;

    // Array to store all blocks created in Awake()
    [HideInInspector]
    public Block[] allBlocks;

    private void Awake()
    {
        // Initialise allBlocks array.
        allBlocks = new Block[allBlockTypes.Length];
        
        // For loops to populate main allBlocks array.
        for (int i = 0; i < allBlockTypes.Length; i++)
        {
            BlockType newBlockType = allBlockTypes[i];
            allBlocks[i] = new Block(i, newBlockType.blockName, newBlockType.blockSprite, newBlockType.blockIsSolid);
            Debug.Log("Solid block: allBlocks[" + i + "] = " + newBlockType.blockName[i]);
        }
    }
}

public class Block
{
    public int blockID;
    public string blockName;
    public Sprite blockSprite;
    public bool isSolid;

    public Block(int id, string myName, Sprite mySprite, bool amISolid)
    {
        blockID = id;
        blockName = myName;
        blockSprite = mySprite;
        isSolid = amISolid;
    }
}

// Custom struct for Block type.
[Serializable]
public struct BlockType
{
    public string blockName;
    public Sprite blockSprite;
    public bool blockIsSolid;
}
