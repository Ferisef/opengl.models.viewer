
namespace opengl.models.viewer {
  /// <summary>
  /// Model data.
  /// </summary>
  public class ModelData {
    private float[] vertices;
    private float[] texCoords;
    private float[] normals;
    private int[] indices;
    private float furthestPoint;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="vertices">Array of vertices.</param>
    /// <param name="texCoords">Array of texture coords.</param>
    /// <param name="normals">Array of normals.</param>
    /// <param name="indices">Array of indices.</param>
    /// <param name="furthestPoint">Furthest point.</param>
    public ModelData(float[] vertices, float[] texCoords, float[] normals, int[] indices, float furthestPoint) {
      this.vertices = vertices;
      this.texCoords = texCoords;
      this.normals = normals;
      this.indices = indices;
      this.furthestPoint = furthestPoint;
    }

    public float[] getVertices() => vertices;

    public float[] getTexCoords() => texCoords;

    public float[] getNormals() => normals;

    public int[] getIndices() => indices;

    public float getFurthestPoint() => furthestPoint;
  }
}
