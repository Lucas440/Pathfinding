namespace Pathfinding
{
    class Graph
    {
        /*
        Node[,] _nodeArray;

        int _arrayLength;
        int _arrayHeight;

        int _nodeID = 0;

        public Graph(int pXAmount, int pYAmount) 
        {
            _arrayLength = pXAmount;
            _arrayHeight = pYAmount;
            _nodeArray = new Node[_arrayLength , _arrayHeight];
            for (int i = 0; i < _arrayLength; i++) 
            {
                for (int j = 0; j < _arrayHeight; j++) 
                {
                    _nodeArray[i, j] = new Node(_nodeID);
                    if (_nodeID == 0) 
                    {
                        _nodeArray[i, j].StartNode = true;
                    }
                    if (_nodeID == 39) 
                    {
                        _nodeArray[i, j].GoalNode = true;
                    }
                    _nodeID++;
                }
            }

            for (int x = 0; x < _arrayLength; x++) 
            {
                for (int y = 0; y < _arrayHeight; y++) 
                {

                    IList<int> _connectedNodes = new List<int>();
                    if (x != 0) 
                    {
                        _connectedNodes.Add(_nodeArray[x - 1, y].getUUID());
                    }
                    if (x + 1 < _arrayLength) 
                    {
                        _connectedNodes.Add(_nodeArray[x + 1, y].getUUID());
                    }
                    if (y != 0) 
                    {
                        _connectedNodes.Add(_nodeArray[x, y - 1].getUUID());
                    }
                    if (y + 1 < _arrayHeight) 
                    {
                        _connectedNodes.Add(_nodeArray[x, y + 1].getUUID());
                    }
                    
                    _nodeArray[x, y].Initalise(_connectedNodes, x * 100 , y * 100);

                  
                }
            }
        }

        public Node[,] GetNodes() 
        {
            return _nodeArray;
        }

        public Node GetNode(int x , int y) 
        {
            return _nodeArray[x, y];
        }

        public Vector2 GetNodeLocation(int x, int y) 
        {
            return _nodeArray[x, y].GetLocation();
        }

        public bool IsConnected(int x , int y , int pNextNodeX , int pNextNodeY) 
        {     
            return _nodeArray[x, y].IsConnected(_nodeArray[pNextNodeX , pNextNodeY].getUUID());
        }

        public IList<Node> Neighbors(Node pNode) 
        {
            IList<Node> connectedNodes = new List<Node>();

            foreach (Node n in _nodeArray) 
            {
                if (pNode.IsConnected(n.getUUID())) 
                {
                    connectedNodes.Add(n);
                }
            }

            return connectedNodes;
        }
        */
    }
}
