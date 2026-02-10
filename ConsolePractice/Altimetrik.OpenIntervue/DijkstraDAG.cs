namespace ConsolePractice.Altimetrik.OpenIntervue
{
    public static class DijkstraDAG
    {
        /// <summary>
        /// Finds the shortest path from a source vertex to all other vertices in a directed acyclic graph (DAG) using Dijkstra's algorithm. 
        /// # If a vertex is unreachable, its distance is reported as 'Infinity'.
        /// </summary>
        /// <param name="n">The number of edges in the graph.</param>
        /// <param name="m">The number of vertices in the graph. </param>
        /// <param name="edges">A list of edges where each edge is represented as a tuple (u, v, w) indicating a directed edge from vertex u to vertex V with weight w.</param>
        /// <param name="source">The source vertex from which to calculate the shortest paths.</param>
        /// <returns>A list of strings representing the shortest distances from the source vertex to each vertex. Unreachable vertices are represented as 'Infinity'.</returns>
        public static List<string> ShortestPathInDAG_01(int n, int m, List<Tuple<int, int, int>> edges, int source)
        {
            // 1. Build Adjacency List
            List<List<(int to, int weight)>> adj = new List<List<(int, int)>>();
            for (int i = 0; i < n; i++)
            {
                adj.Add(new List<(int, int)>());
            }

            foreach (var edge in edges)
            {
                adj[edge.Item1].Add((edge.Item2, edge.Item3));
            }

            // 2. Dijkstra's Setup
            int[] dist = new int[n];
            Array.Fill(dist, int.MaxValue);
            dist[source] = 0;

            // Min-Priority Queue (Distance, Vertex)
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            pq.Enqueue(source, 0);

            while (pq.Count > 0)
            {
                pq.TryDequeue(out int u, out int d);

                // Optimization: skip if we found a better path already
                if (d > dist[u])
                    continue;

                foreach (var neighbor in adj[u])
                {
                    int v = neighbor.to;
                    int weight = neighbor.weight;

                    if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                    {
                        dist[v] = dist[u] + weight;
                        pq.Enqueue(v, dist[v]);
                    }
                }
            }

            // 3. Format Output
            List<string> result = new List<string>();
            for (int i = 0; i < n; i++)
            {
                if (dist[i] == int.MaxValue)
                {
                    result.Add("Infinity");
                }
                else
                {
                    result.Add(dist[i].ToString());
                }
            }

            return result;
        }

        /// <summary>
        /// Finds the shortest path from a source vertex to all other vertices in a directed acyclic graph (DAG) using Dijkstra's algorithm. 
        /// # If a vertex is unreachable, its distance is reported as 'Infinity'.
        /// </summary>
        /// <param name="n">The number of edges in the graph.</param>
        /// <param name="m">The number of vertices in the graph. </param>
        /// <param name="edges">A list of edges where each edge is represented as a tuple (u, v, w) indicating a directed edge from vertex u to vertex V with weight w.</param>
        /// <param name="source">The source vertex from which to calculate the shortest paths.</param>
        /// <returns>A list of strings representing the shortest distances from the source vertex to each vertex. Unreachable vertices are represented as 'Infinity'.</returns>

        public static List<string> ShortestPathInDAG(int n, int m, List<Tuple<int, int, int>> edges, int source)
        {
            // Build adjacency list
            var adj = new List<(int v, int w)>[n];
            for (int i = 0; i < n; i++)
                adj[i] = new List<(int v, int w)>();

            foreach (var edge in edges)
            {
                adj[edge.Item1].Add((edge.Item2, edge.Item3));
            }

            // Distance array
            var dist = new int[n];
            for (int i = 0; i < n; i++)
                dist[i] = int.MaxValue;

            dist[source] = 0;

            // PriorityQueue: vertex with priority = distance
            var pq = new PriorityQueue<int, int>();
            pq.Enqueue(source, 0);

            while (pq.Count > 0)
            {
                pq.TryDequeue(out int u, out int d); // Skip outdated entries
                if (d > dist[u])
                    continue;

                foreach (var (v, w) in adj[u])
                {
                    if (dist[v] > dist[u] + w)
                    {
                        dist[v] = dist[u] + w;
                        pq.Enqueue(v, dist[v]);
                    }
                }
            }

            // Format output
            var result = new List<string>();
            for (int i = 0; i < n; i++)
            {
                result.Add(dist[i] == int.MaxValue ? "Infinity" : dist[i].ToString());
            }

            return result;
        }
    }
}