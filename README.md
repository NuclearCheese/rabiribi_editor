# Rabi-Ribi Editor

This program allows editing of Rabi-Ribi level files.

## Acknowledgements

Much of the technical data used in creating this editor comes from wcko87's map editing documentation: https://github.com/wcko87/rabiribi-map-editing

## Basics

This program operates directly on the .map files used by the game.  Use the File menu to open and save.
* You should make new copies of map files before editing them, so as to not corrupt the original files.
* Rabi-Ribi has custom map support as of version 1.85 - see the "custom" folder within Rabi-Ribi's install directory for details.

In order to have a proper tile set visible in the editor, the file *TILE1_A.PNG* must be in the directory you launch the editor from.  If this file is missing, the editor will generate placeholder tiles which just have the tile number written on them.
Collision tile graphics can also be specified with a file named *COLLISION_TILES.PNG* - if this file is missing the editor will generate placeholder graphics.
* These files can be downloaded from wcko87's repository, linked above.
* Alternatively, if using a custom tile set, be sure to launch the editor from the path where that custom tile set image file is.


The View tab on the right presents the ability to toggle visibility of each layer.  Switching over to the Tools tab allows selecting which layer to edit.

After selecting a tool, the options for what data to use are presented below the tool selection box:
* For layers 0 through 6 (the visible tile layers), tile graphics are presented, along with the horizontal and vertical flip checkboxes.  Click a tile to select it.
** Note that the top-left-most tile is an empty tile.  Use this to clear out existing tiles.
* For the collision layer, collision tile graphics are displayed - click one to select it.
* For event and item IDs, you can enter any ID in the text box.  There are also drop down lists of known IDs that you can select from.
* For room type and room color, you can select a value from the drop down list.
* For room BG, an ID must be entered into the text box.

You can also select a value by right-clicking on the map to select whatever you're pointing at.

Once a tool and value/tile are selected, left click in the map view to draw it on the map.  You can also drag with the left mouse button to fill in a rectangular area.
Be aware that you can draw on a map even if the layer you're drawing to is not currently visible.


## Sample Map

I threw together a quick map using the editor, as a sample of what it can do.

Download is at: https://github.com/NuclearCheese/rabiribi_maps/blob/master/maps/Rabi-Ribi%20Editor%20Sample%20Level.zip?raw=true

Or navigate to it manually in my maps repository:
- https://github.com/NuclearCheese/rabiribi_maps
- maps directory
- Rabi-Ribi Editor Sample Level.zip

Note that admittedly I'm not the best artist, so things look a bit plain.  That's more on me than the editor! :)
