Setup:

- Place the 'ChangeTile' script onto single, game manager style object in the scene.

- In the 'Tiles' array on the ChangeTile component, place the objects you want to be able to change between, your prefabs.

- To each object you put in this array, add the TileChanger script.

To use:

- When your prefabs / tiles are in the scene, select them in the editor and in the inspector pane, you'll see the 'Change Me' bool. To 'select' a tile, simply set this to true.

- With your desired objects 'selected', go back to the game manager object with the ChangeTile script.

- Select the desired new prefab / tile by changing the 'Tile To Change Into' int (e.g. 0 is element 0 from the tiles array, etc.).

- Click the 'Update Tiles' button.

Tips:

- If the tiles fail to update, check the debug console for any error logs.

- When a tile is updated, the new tile will have its 'Change Me' set to true, to clear all selected objects, click 'Clear Selected Tiles'.

- Child all prefabs / tiles to a parent object to prevent the hierarchy pane getting all messy!