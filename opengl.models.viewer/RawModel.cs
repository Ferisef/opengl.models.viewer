
namespace opengl.models.viewer {
  /// <summary>
  /// Represents a way to store data in memory.
  /// </summary>
  class RawModel {
    private int vaoID;
    private int vertexCount;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="vaoID">VAO id.</param>
    /// <param name="vertexCount">Number of vertices.</param>
    public RawModel(int vaoID, int vertexCount) {
      this.vaoID = vaoID;
      this.vertexCount = vertexCount;
    }

    public int getVaoID() => vaoID;

    public int getVertexCount() => vertexCount;
  }
}
