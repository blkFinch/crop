using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu]
//not sure about the arguments here but this allows
//the brush to appear in the tilemap editor 
// took from https://www.youtube.com/watch?v=VV0NgnztIQg
[CustomGridBrush(false,true,false, "Prefab Brush / Farmable Tile Brush")] 
public class FarmableTileBrush : GridBrushBase
{
    public GameObject farmableTileObject;
    public int zPos = 0;

    public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
    {
        Vector3Int cellPosition = new Vector3Int(position.x, position.y, zPos);
        Vector3 centerTile = new Vector3(.5f, .5f, 0f);

        //to prevent painting multiple tiles in same grid position
        if( GetObjectInCell(grid, brushTarget.transform, new Vector3Int(position.x, position.y, zPos)) != null)
            return;

        GameObject tileObject;
        tileObject = Instantiate(farmableTileObject);
        tileObject.transform.SetParent(brushTarget.transform);
        tileObject.transform.position = grid.LocalToWorld(grid.CellToLocalInterpolated(cellPosition + centerTile));
    }

    //Code copied from Jay Santos presentation. 
    private static Transform GetObjectInCell(GridLayout grid, Transform parent, Vector3Int position)
    {
        int childCount = parent.childCount;

        //gets world position of grid cell
        Vector3 min = grid.LocalToWorld(grid.CellToLocalInterpolated(position));

        //...add (1f,1f,1f) to check entire cell
        Vector3 max = grid.LocalToWorld(grid.CellToLocalInterpolated(position + Vector3.one));
        Bounds bounds = new Bounds((max+min)* .5f, max-min);

        for(int i =0; i <childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if(bounds.Contains(child.position))
            {
                return child;
            }
        }

        return null;
    }
    
}
