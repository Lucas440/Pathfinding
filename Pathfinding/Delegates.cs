using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Pathfinding
{
    public delegate Vector2 GetNodeLocation(int x, int y);

    public delegate bool GetConnectedNode(int x, int y, int pNextNodeX, int pNextNodeY);

    public delegate Node GetNodeDelegate(int x, int y);

    public delegate IList<Node> GetNeigboursDelegate(Node pNode);
}
