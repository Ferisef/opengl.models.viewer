using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace opengl.models.viewer {
  /// <summary>
  /// Work with shaders.
  /// </summary>
  abstract class ShaderProgram {
    private int vertexID;
    private int fragmentID;
    private int programID;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="pathToVertex">Path to vertex shader file.</param>
    /// <param name="pathToFragment">Path to fragment shader file.</param>
    public ShaderProgram(string pathToVertex, string pathToFragment) {
      vertexID = compileShader(File.ReadAllText(pathToVertex), ShaderType.VertexShader);
      fragmentID = compileShader(File.ReadAllText(pathToFragment), ShaderType.FragmentShader);

      programID = GL.CreateProgram();
      GL.AttachShader(programID, vertexID);
      GL.AttachShader(programID, fragmentID);
      bindAttributes();
      GL.LinkProgram(programID);
      getAllUniformLocations();
    }

    /// <summary>
    /// Start shader.
    /// </summary>
    public void start() {
      GL.UseProgram(programID);
    }

    /// <summary>
    /// Stop shader.
    /// </summary>
    public void stop() {
      GL.UseProgram(0);
    }

    /// <summary>
    /// Free memory.
    /// </summary>
    public void cleanUp() {
      stop();
      GL.DetachShader(programID, vertexID);
      GL.DetachShader(programID, fragmentID);
      GL.DeleteShader(vertexID);
      GL.DeleteShader(fragmentID);
      GL.DeleteProgram(programID);
    }

    /// <summary>
    /// Compile shader.
    /// </summary>
    /// <param name="shaderSource">Shader source code.</param>
    /// <param name="shaderType">Shader type.</param>
    /// <returns>Shader id.</returns>
    private int compileShader(string shaderSource, ShaderType shaderType) {
      int shaderID = GL.CreateShader(shaderType);
      GL.ShaderSource(shaderID, shaderSource);
      GL.CompileShader(shaderID);
      return shaderID;
    }

    /// <summary>
    /// Bind all attributes.
    /// </summary>
    protected abstract void bindAttributes();

    /// <summary>
    /// Binding attribute value in shader and program.
    /// </summary>
    /// <param name="attribute">Attribute.</param>
    /// <param name="variableName">variable name.</param>
    protected void bindAttribute(int attribute, string variableName) {
      GL.BindAttribLocation(programID, attribute, variableName);
    }

    /// <summary>
    /// Loading float value into shader program.
    /// </summary>
    /// <param name="location">Location.</param>
    /// <param name="value">Value.</param>
    protected void loadFloat(int location, float value) {
      GL.Uniform1(location, value);
    }

    /// <summary>
    /// Loading a vector into shader program.
    /// </summary>
    /// <param name="location">Location.</param>
    /// <param name="vector">Value.</param>
    protected void loadVector(int location, Vector3 vector) {
      GL.Uniform3(location, vector);
    }

    /// <summary>
    /// Loading boolean value into shader program.
    /// </summary>
    /// <param name="location">Location.</param>
    /// <param name="value">Value.</param>
    protected void loadBoolean(int location, bool value) {
      GL.Uniform1(location, value ? 1 : 0);
    }

    /// <summary>
    /// Loading the matrix into shader program.
    /// </summary>
    /// <param name="location">Location.</param>
    /// <param name="matrix">Value.</param>
    protected void loadMatrix(int location, Matrix4 matrix) {
      GL.UniformMatrix4(location, false, ref matrix);
    }

    /// <summary>
    /// Getting all uniform locations.
    /// </summary>
    protected abstract void getAllUniformLocations();

    /// <summary>
    /// Getting a uniform location in shader program.
    /// </summary>
    /// <param name="uniformName">Uniform name.</param>
    /// <returns>Uniform location.</returns>
    protected int getUniformLocation(string uniformName) {
      return GL.GetUniformLocation(programID, uniformName);
    }
  }
}
