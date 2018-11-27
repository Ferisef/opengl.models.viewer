using OpenTK;

namespace opengl.models.viewer {
  /// <summary>
  /// Work with shaders.
  /// </summary>
  internal class StaticShader : ShaderProgram {
    private static readonly string PATH_TO_VERTEX_SHADER = @"shaders\shader.vert";
    private static readonly string PATH_TO_FRAGMENT_SHADER = @"shaders\shader.frag";

    private int transformationMatrixLocation;
    private int projectionMatrixLocation;
    private int viewMatrixLocation;
    private int lightPositionLocation;
    private int lightColorLocation;

    /// <summary>
    /// Constructor.
    /// </summary>
    public StaticShader() : base(PATH_TO_VERTEX_SHADER, PATH_TO_FRAGMENT_SHADER) { }

    /// <summary>
    /// Bind all attributes.
    /// </summary>
    protected override void bindAttributes() {
      bindAttribute(0, "position");
      bindAttribute(1, "normal");
    }

    /// <summary>
    /// Getting all uniform locations.
    /// </summary>
    protected override void getAllUniformLocations() {
      transformationMatrixLocation = getUniformLocation("transformationMatrix");
      projectionMatrixLocation = getUniformLocation("projectionMatrix");
      viewMatrixLocation = getUniformLocation("viewMatrix");
      lightPositionLocation = getUniformLocation("lightPosition");
      lightColorLocation = getUniformLocation("lightColor");
    }

    /// <summary>
    /// Loading light into shader program.
    /// </summary>
    /// <param name="light">Light.</param>
    public void loadLight(Light light) {
      loadVector(lightPositionLocation, light.getPosition());
      loadVector(lightColorLocation, light.getColor());
    }

    /// <summary>
    /// Loading transformation matrix into shader program.
    /// </summary>
    /// <param name="matrix">Transformation matrix.</param>
    public void loadTransformationMatrix(Matrix4 matrix) {
      loadMatrix(transformationMatrixLocation, matrix);
    }

    /// <summary>
    /// Loading projection matrix into shader program.
    /// </summary>
    /// <param name="matrix">Projection matrix.</param>
    public void loadProjectionMatrix(Matrix4 matrix) {
      loadMatrix(projectionMatrixLocation, matrix);
    }

    /// <summary>
    /// Loading view matrix into shader program.
    /// </summary>
    /// <param name="camera">View matrix.</param>
    public void loadViewMatrix(Camera camera) {
      Matrix4 matrix = Maths.createVeiwMatrix(camera);
      loadMatrix(viewMatrixLocation, matrix);
    }
  }
}
