using System.IO;
using System.Collections.Generic;
using OpenTK;

namespace opengl.models.viewer {
  /// <summary>
  /// Represents methods to load data from .obj files.
  /// </summary>
  public static class OBJFileLoader {
    /// <summary>
    /// Load data from file.
    /// </summary>
    /// <param name="objFileName">Path to model file.</param>
    /// <returns>Model data.</returns>
    public static ModelData loadOBJ(string objFileName) {
      string[] lines = File.ReadAllLines(objFileName);

      List<Vertex> vertices = new List<Vertex>();
      List<Vector2> textures = new List<Vector2>();
      List<Vector3> normals = new List<Vector3>();
      List<int> indices = new List<int>();
      
      foreach (string line in lines) {
        string[] splitted = line.Split(' ');
        // parsing vertex coords
        if (line.StartsWith("v ")) {
          Vector3 v = new Vector3(
            float.Parse(splitted[1]),
            float.Parse(splitted[2]),
            float.Parse(splitted[3])
          );
          vertices.Add(new Vertex(vertices.Count, v));
        }
        // parsing textures coords
        if (line.StartsWith("vt ")) {
          Vector2 texPos = new Vector2(
            float.Parse(splitted[1]),
            float.Parse(splitted[2])
          );
          textures.Add(texPos);
        }
        // parsing normals
        if (line.StartsWith("vn ")) {
          Vector3 normal = new Vector3(
            float.Parse(splitted[1]),
            float.Parse(splitted[2]),
            float.Parse(splitted[3])
          );
          normals.Add(normal);
        }
        // parsing indices
        if (line.StartsWith("f ")) {
          processVertex(splitted[1].Split('/'), vertices, indices);
          processVertex(splitted[2].Split('/'), vertices, indices);
          processVertex(splitted[3].Split('/'), vertices, indices);
        }
      }
      removeUnusedVertices(vertices);

      float furthest = convertDataToArrays(vertices, textures, normals,
        out float[] verticesArray, out float[] texArray, out float[] normalsArray);
      return new ModelData(verticesArray, texArray, normalsArray, indices.ToArray(), furthest);
    }

    private static void processVertex(string[] vertex, List<Vertex> vertices, List<int> indices) {
      int index = int.Parse(vertex[0]) - 1;
      Vertex currentVertex = vertices[index];
      int textureIndex = int.Parse(vertex[1]) - 1;
      int normalIndex  = int.Parse(vertex[2]) - 1;
      if (!currentVertex.isSet()) {
        currentVertex.setTexIndex(textureIndex);
        currentVertex.setNormalIndex(normalIndex);
        indices.Add(index);
      } else {
        dealWithAlreadyProcessedVertex(currentVertex, textureIndex, normalIndex, indices, vertices);
      }
    }

    private static void dealWithAlreadyProcessedVertex(Vertex prevVertex,
        int newTexIndex, int newNormalIndex, List<int> indices, List<Vertex> vertices) {
      if (prevVertex.hasSameTextureAndNormal(newTexIndex, newNormalIndex)) {
        indices.Add(prevVertex.getIndex());
      } else {
        Vertex anotherVertex = prevVertex.getDuplicateVertex();
        if (anotherVertex != null) {
          dealWithAlreadyProcessedVertex(anotherVertex, newTexIndex, newNormalIndex, indices, vertices);
        } else {
          Vertex duplicateVertex = new Vertex(vertices.Count, prevVertex.getPosition());
          duplicateVertex.setTexIndex(newTexIndex);
          duplicateVertex.setNormalIndex(newNormalIndex);
          vertices.Add(duplicateVertex);
          indices.Add(duplicateVertex.getIndex());
        }
      }
    }

    /// <summary>
    /// Converting lists to arrays.
    /// </summary>
    /// <param name="vertices">List of vertices.</param>
    /// <param name="textures">List of texture coords.</param>
    /// <param name="normals">List of normals.</param>
    /// <param name="verticesArray">Returns an array of vertices.</param>
    /// <param name="texArray">Returns an array of texture coords.</param>
    /// <param name="normalsArray">Returns an array of indices.</param>
    /// <returns>Furthest point.</returns>
    private static float convertDataToArrays(List<Vertex> vertices, List<Vector2> textures, List<Vector3> normals,
        out float[] verticesArray, out float[] texArray, out float[] normalsArray) {
      verticesArray = new float[vertices.Count * 3];
      texArray      = new float[vertices.Count * 2];
      normalsArray  = new float[vertices.Count * 3];

      float furthestPoint = 0;
      for (int i = 0; i < vertices.Count; i++) {
        Vertex v = vertices[i];
        if (v.getLength() > furthestPoint) furthestPoint = v.getLength();

        Vector3 position = v.getPosition();
        verticesArray[i * 3]     = position.X;
        verticesArray[i * 3 + 1] = position.Y;
        verticesArray[i * 3 + 2] = position.Z;

        Vector2 texCoord = textures[v.getTexIndex()];
        texArray[i * 2]     = texCoord.X;
        texArray[i * 2 + 1] = texCoord.Y;

        Vector3 normalCoord = normals[v.getNormalIndex()];
        normalsArray[i * 3]     = normalCoord.X;
        normalsArray[i * 3 + 1] = normalCoord.Y;
        normalsArray[i * 3 + 2] = normalCoord.Z;
      }
      return furthestPoint;
    }

    /// <summary>
    /// Deleting unused vertices.
    /// </summary>
    /// <param name="vertices">List of verices.</param>
    private static void removeUnusedVertices(List<Vertex> vertices) {
      foreach (Vertex v in vertices) {
        if (!v.isSet()) {
          v.setTexIndex(0);
          v.setNormalIndex(0);
        }
      }
    }
  }
}
