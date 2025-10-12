namespace ProblemSolving.Graph;

public class Graph
{
    private readonly List<List<int>> _adjList;

    public Graph()
    {
        _adjList = new List<List<int>>();
    }

    public Graph(int vertexNum)
    {
        _adjList = new List<List<int>>();
        while (_adjList.Count < vertexNum)
        {
            _adjList.Add(new List<int>());
        }
    }

    public IEnumerator<int> GetEdgeEnumerator(int vertex)
    {
        return _adjList[vertex].GetEnumerator();
    }

    public void AddEdge(int from, int to, EdgeOption option = EdgeOption.Bidirectional)
    {
        int needV = Math.Max(from, to);
        if (_adjList.Count < needV + 1)
        {
            Grow(needV + 1);
        }
        
        switch (option)
        {
            case EdgeOption.Unidirectional:
            {
                AddUnidirectionalEdge(from, to);
                break;
            }
            case EdgeOption.Bidirectional:
            {
                AddBidirectionalEdge(from, to);
                break;
            }
            default:
            {
                AddBidirectionalEdge(from, to);
                break;
            }
        }
    }

    private void AddUnidirectionalEdge(int from, int to)
    {
        _adjList[from].Add(to);
    }

    private void AddBidirectionalEdge(int from, int to)
    {
        _adjList[from].Add(to);
        _adjList[to].Add(from);
    }

    private void Grow(int size)
    {
        while (_adjList.Count < size)
        {
            _adjList.Add(new List<int>());
        }
    }
}