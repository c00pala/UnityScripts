Setup:

- Place the 'ChangeTile' script onto a single, 'game manager' style object in the scene.

- In the 'Tiles' array on the ChangeTile component, place the objects you want to be able to change between, your prefabs or tiles.

- To each object you put in this array, add the 'TileChanger' script to its prefab.

- Place your prefabs / tiles into the scene as normal, ensuring they're children of at least one other object.

----------------------------------------------------------------------

To use:

- When your prefabs / tiles are in the scene, select them in the editor and in the inspector pane, you'll see the 'Change Me' bool. 

- To 'select' a tile, simply set this to true. You can deselect this object in the editor and select other objects and this will stay true.

- With your desired objects 'selected', go back to the game manager object with the 'ChangeTile' script.

- Choose the new prefab / tile you want to change to by setting the 'Tile To Change Into' int variable on the 'ChangeTile' script (e.g. 0 is element 0 from the tiles array, etc.).

- If required, adjust the rotation using the 'New Rotation' variable.

- Click the 'Update Tiles' button.

- The tile 'selection' will be kept, so you can change the tile int and update tiles again and it should still update the same times. To clear this selection, click 'Clear Selected Tiles' or go to the object itself and set the 'Change Me' bool back to false.

----------------------------------------------------------------------

Tips:

- If the tiles fail to update, check the debug console for any error logs.

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
