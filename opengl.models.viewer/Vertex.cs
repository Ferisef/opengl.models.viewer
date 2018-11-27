using OpenTK;

namespace opengl.models.viewer {
  /// <summary>
  ///  Represents Vertex.
  /// </summary>
  public class Vertex {
    private static int NO_INDEX = -1;

    private Vector3 position;
    private int texIndex = NO_INDEX;
    private int normalIndex = NO_INDEX;
    private Vertex duplicateVertex = null;
    private int index;
    private float length;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <param name="position">Position.</param>
    public Vertex(int index, Vector3 position) {
      this.index = index;
      this.position = position;
      length = position.Length;
    }

    public int getIndex() => index;

    public float getLength() => length;

    public bool isSet() {
      return (texIndex != NO_INDEX) && (normalIndex != NO_INDEX);
    }

    public bool hasSameTextureAndNormal(int texIndexOther, int normalIndexOther) {
      return (texIndexOther == texIndex) && (normalIndexOther == normalIndex);
    }

    public Vector3 getPosition() => position;

    public int getTexIndex() => texIndex;

    public void setTexIndex(int index) {
      texIndex = index;
    }

    public int getNormalIndex() => normalIndex;

    public void setNormalIndex(int index) {
      normalIndex = index;
    }

    public Vertex getDuplicateVertex() => duplicateVertex;

    public void setDuplicateVertex(Vertex vertex) {
      duplicateVertex = vertex;
    }
  }
}
