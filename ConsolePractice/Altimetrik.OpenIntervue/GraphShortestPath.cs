using System;
using System.Collections.Generic;

public enum PathMode
{
    EdgeCount,   // BFS
    Weighted     // Dijkstra
}

public class GraphShortestPath
{
    private readonly Dictionary<int, List<(int neighbor, int weight)>> graph;

    public GraphShortestPath(List<(int u, int v, int w)> edges)
    {
        graph = new Dictionary<int, List<(int, int)>>();
        foreach (var (u, v, w) in edges)
        {
            if (!graph.ContainsKey(u))
                graph[u] = new List<(int, int)>();
            graph[u].Add((v, w));
        }
    }

    public int FindShortestPath(int start, int target, PathMode mode)
    {
        if (mode == PathMode.EdgeCount)
            return BFSShortestPath(start, target);
        else
            return DijkstraShortestPath(start, target);
    }

    private int BFSShortestPath(int start, int target)
    {
        var queue = new Queue<(int node, int depth)>();
        var visited = new HashSet<int>();

        queue.Enqueue((start, 0));
        visited.Add(start);

        while (queue.Count > 0)
        {
            var (node, depth) = queue.Dequeue();

            if (node == target)
                return depth;

            if (graph.ContainsKey(node))
            {
                foreach (var (neighbor, _) in graph[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue((neighbor, depth + 1));
                    }
                }
            }
        }

        return -1;
    }

    private int DijkstraShortestPath(int start, int target)
    {
        var dist = new Dictionary<int, int>();
        var pq = new PriorityQueue<int, int>();

        dist[start] = 0;
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int node, out int currentDist);

            if (node == target)
                return currentDist;

            if (!graph.ContainsKey(node))
                continue;

            foreach (var (neighbor, weight) in graph[node])
            {
                int newDist = currentDist + weight;
                if (!dist.ContainsKey(neighbor) || newDist < dist[neighbor])
                {
                    dist[neighbor] = newDist;
                    pq.Enqueue(neighbor, newDist);
                }
            }
        }

        return -1;
    }
}