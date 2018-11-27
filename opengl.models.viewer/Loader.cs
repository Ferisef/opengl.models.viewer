using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

namespace opengl.models.viewer {
  /// <summary>
  /// Represents loader.
  /// Loads data into the memory of a video card using VAO's and VBO's.
  /// </summary>
  class Loader {
    private List<int> vaos = new List<int>();
    private List<int> vbos = new List<int>();

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="positions">Array of positions.</param>
    /// <param name="indices">Array of indices.</param>
    /// <returns>Raw model.</returns>
    public RawModel loadToVAO(float[] positions, float[] normals, int[] indices) {
      int vaoID = createVAO();
      vaos.Add(vaoID);
      bindIndicesBuffer(indices);
      storeDataInAttributeList(0, positions);
      storeDataInAttributeList(1, normals);
      GL.BindVertexArray(0);
      return new RawModel(vaoID, indices.Length);
    }

    /// <summary>
    /// Free memory.
    /// </summary>
    public void cleanUp() {
      foreach (int vao in vaos) {
        GL.DeleteVertexArray(vao);
      }
      foreach (int vbo in vbos) {
        GL.DeleteBuffer(vbo);
      }
    }

    /// <summary>
    /// Create vertex array object.
    /// </summary>
    /// <returns>VAO id.</returns>
    private int createVAO() {
      GL.GenVertexArrays(1, out int vaoID);
      vaos.Add(vaoID);
      GL.BindVertexArray(vaoID);
      return vaoID;
    }

    /// <summary>
    /// Store data in VBO.
    /// </summary>
    /// <param name="attributeNumber">Attribute numder.</param>
    /// <param name="data">Data.</param>
    private void storeDataInAttributeList(int attributeNumber, float[] data) {
      GL.GenBuffers(1, out int vboID);
      vbos.Add(vboID);
      GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
      GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * data.Length, data, BufferUsageHint.StaticDraw);
      GL.VertexAttribPointer(attributeNumber, 3, VertexAttribPointerType.Float, false, 0, 0);
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
    }

    /// <summary>
    /// Store indices in VBO.
    /// </summary>
    /// <param name="indices">Array of indices.</param>
    private void bindIndicesBuffer(int[] indices) {
      GL.GenBuffers(1, out int vboID);
      vbos.Add(vboID);
      GL.BindBuffer(BufferTarget.ElementArrayBuffer, vboID);
      GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(int) * indices.Length, indices, BufferUsageHint.StaticDraw);
    }
  }
}
