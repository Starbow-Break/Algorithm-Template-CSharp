namespace ProblemSolving.Graph;

public struct EdgeData<TWeight>
{
    public int to;
    public TWeight weight;

    public EdgeData(int to, TWeight weight)
    {
        this.to = to;
        this.weight = weight;
    }
}

public class WeightedGraph<TWeight>
{
    private readonly List<List<EdgeData<TWeight>>> _adjList;

    public WeightedGraph()
    {
        _adjList = new List<List<EdgeData<TWeight>>>();
    }

    public WeightedGraph(int vertexNum)
    {
        _adjList = new List<List<EdgeData<TWeight>>>();
        while (_adjList.Count < vertexNum)
        {
            _adjList.Add(new List<EdgeData<TWeight>>());
        }
    }
    
    public IEnumerator<EdgeData<TWeight>> GetEdgeEnumerator(int vertex)
    {
        return _adjList[vertex].GetEnumerator();
    }

    public void AddEdge(int from, int to, TWeight weight, EdgeOption option = EdgeOption.Bidirectional)
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
                AddUnidirectionalEdge(from, to, weight);
                break;
            }
            case EdgeOption.Bidirectional:
            {
                AddBidirectionalEdge(from, to, weight);
                break;
            }
            default:
            {
                AddBidirectionalEdge(from, to, weight);
                break;
            }
        }
    }

    private void AddUnidirectionalEdge(int from, int to, TWeight weight)
    {
        _adjList[from].Add(new EdgeData<TWeight>(to, weight));
    }

    private void AddBidirectionalEdge(int from, int to, TWeight weight)
    {
        _adjList[from].Add(new EdgeData<TWeight>(to, weight));
        _adjList[to].Add(new EdgeData<TWeight>(to, weight));
    }

    private void Grow(int size)
    {
        while (_adjList.Count < size)
        {
            _adjList.Add(new List<EdgeData<TWeight>>());
        }
    }
}