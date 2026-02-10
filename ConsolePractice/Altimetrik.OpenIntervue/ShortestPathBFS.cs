using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Altimetrik.OpenIntervue
{
    public static class ShortestPathBFS
    {
        public static int FindShortestPathLength(List<(int u, int v, int w)> edges, int start, int target)
        {
            // Build adjacency list (ignore weights)
            var graph = new Dictionary<int, List<int>>();

            foreach (var (u, v, w) in edges)
            {
                if (!graph.ContainsKey(u))
                    graph[u] = new List<int>();
                graph[u].Add(v);
            }

            // BFS setup
            var queue = new Queue<(int node, int depth)>();
            var visited = new HashSet<int>();
            queue.Enqueue((start, 0));
            visited.Add(start);
            while (queue.Count > 0)
            {
                var (node, depth) = queue.Dequeue();
                if (node == target) return depth; // Found shortest path
                if (graph.ContainsKey(node))
                {
                    foreach (var neighbor in graph[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue((neighbor, depth + 1));
                        }
                    }
                }
            }
            return -1; // No path exists
        }


        public static int FindShortestPathWeighted(List<(int u, int v, int w)> edges, int start, int target)
        {
            // Build adjacency list with weights
            var graph = new Dictionary<int, List<(int neighbor, int weight)>>();
            foreach (var (u, v, w) in edges)
            {
                if (!graph.ContainsKey(u))
                    graph[u] = new List<(int, int)>();
                graph[u].Add((v, w));
            }

            // Distance dictionary
            var dist = new Dictionary<int, int>();
            var pq = new PriorityQueue<int, int>(); // node, distance

            dist[start] = 0;
            pq.Enqueue(start, 0);

            while (pq.Count > 0)
            {
                pq.TryDequeue(out int node, out int currentDist);

                if (node == target)
                    return currentDist; // Found shortest path

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

            return -1; // No path exists
        }


    }
}
