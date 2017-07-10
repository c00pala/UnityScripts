Setup:

- Place the 'ChangeTile' script onto a single, 'game manager' style object in the scene.

- In the 'Tiles' array on the ChangeTile component, place the objects you want to be able to change between, your prefabs or tiles.

- To each object you put in this array, add the 'TileChanger' script to its prefab.

- Place your prefabs / tiles into the scene as normal, ensuring they're children of at least one other object.

----------------------------------------------------------------------

To use:

- When your prefabs / tiles are in the scene, select them in the editor and in the inspector pane, you'll see the 'Change Me' bool. 

- To 'select' a tile, simply set this to true. You can deselect this object safely.

- With your desired objects 'selected', go back to the game manager object with the 'ChangeTile' script.

- Choose the new prefab / tile you want to change to by setting the 'Tile To Change Into' int variable on the 'ChangeTile' script (e.g. 0 is element 0 from the tiles array, etc.).

- If required, adjust the rotation using the 'New Rotation' variable.

- Click the 'Update Tiles' button.

----------------------------------------------------------------------

Tips:

- If the tiles fail to update, check the debug console for any error logs.

- When a tile is updated, the new tile will have its 'Change Me' set to true, to clear all selected objects, click 'Clear Selected Tiles'.

- WARNING: Does not support Undo. If you update something, you can't undo it.

Also, currently doesn't support objects with children unless those children are a part of the prefab. If you've added children to an object in the scene only and not updated the prefab, these will be lost if you update the object!!

-----------------------------------------------------------------------

CHANGE LOG:

10/7/17 : 
- Changed Instantiate into PrefabUtility in the main spawn function to ensure new GameObject retains connection to its prefab (else it won't be up to date with any changes made to the prefab itself).
- Added ability to adjust rotation when replacing objects, adjust using the 'New Rotation' variable.

8/7/17 : 
- Cleaned up excess code in TileChanger script.

8/7/17 : 
- Created and uploaded to GitHub.
