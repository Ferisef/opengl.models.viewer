namespace opengl.models.viewer {
  partial class ModelPickerForm {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent() {
      this.choose3DModelDialog = new System.Windows.Forms.OpenFileDialog();
      this.open3DModelButton = new System.Windows.Forms.Button();
      this.buttonsPanel = new System.Windows.Forms.Panel();
      this.view3DModelButton = new System.Windows.Forms.Button();
      this.mainPanel = new System.Windows.Forms.Panel();
      this.modelInfoPanel = new System.Windows.Forms.Panel();
      this.modelDataPanel = new System.Windows.Forms.Panel();
      this.normalsCountLabel = new System.Windows.Forms.Label();
      this.texCoordsCountLabel = new System.Windows.Forms.Label();
      this.indicesCountLabel = new System.Windows.Forms.Label();
      this.verticesCountLabel = new System.Windows.Forms.Label();
      this.modelInfoLabel = new System.Windows.Forms.Label();
      this.fileSizeLabel = new System.Windows.Forms.Label();
      this.fileNameLabel = new System.Windows.Forms.Label();
      this.buttonsPanel.SuspendLayout();
      this.mainPanel.SuspendLayout();
      this.modelInfoPanel.SuspendLayout();
      this.modelDataPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // choose3DModelDialog
      // 
      this.choose3DModelDialog.FileName = "Choose 3D Model";
      this.choose3DModelDialog.Filter = "3D Models (*.obj)|*obj";
      // 
      // open3DModelButton
      // 
      this.open3DModelButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.open3DModelButton.Location = new System.Drawing.Point(5, 5);
      this.open3DModelButton.Name = "open3DModelButton";
      this.open3DModelButton.Size = new System.Drawing.Size(158, 24);
      this.open3DModelButton.TabIndex = 0;
      this.open3DModelButton.Text = "Open 3D Model";
      this.open3DModelButton.UseVisualStyleBackColor = true;
      this.open3DModelButton.Click += new System.EventHandler(this.choose3DModelButton_Click);
      // 
      // buttonsPanel
      // 
      this.buttonsPanel.Controls.Add(this.view3DModelButton);
      this.buttonsPanel.Controls.Add(this.open3DModelButton);
      this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.buttonsPanel.Location = new System.Drawing.Point(0, 0);
      this.buttonsPanel.Margin = new System.Windows.Forms.Padding(0);
      this.buttonsPanel.Name = "buttonsPanel";
      this.buttonsPanel.Padding = new System.Windows.Forms.Padding(5);
      this.buttonsPanel.Size = new System.Drawing.Size(168, 321);
      this.buttonsPanel.TabIndex = 1;
      // 
      // view3DModelButton
      // 
      this.view3DModelButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.view3DModelButton.Location = new System.Drawing.Point(5, 29);
      this.view3DModelButton.Name = "view3DModelButton";
      this.view3DModelButton.Size = new System.Drawing.Size(158, 24);
      this.view3DModelButton.TabIndex = 1;
      this.view3DModelButton.Text = "View 3D Model";
      this.view3DModelButton.UseVisualStyleBackColor = true;
      this.view3DModelButton.Click += new System.EventHandler(this.view3DModelButton_Click);
      // 
      // mainPanel
      // 
      this.mainPanel.AutoSize = true;
      this.mainPanel.Controls.Add(this.modelInfoPanel);
      this.mainPanel.Controls.Add(this.fileSizeLabel);
      this.mainPanel.Controls.Add(this.fileNameLabel);
      this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainPanel.Location = new System.Drawing.Point(168, 0);
      this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Padding = new System.Windows.Forms.Padding(5);
      this.mainPanel.Size = new System.Drawing.Size(296, 321);
      this.mainPanel.TabIndex = 2;
      // 
      // modelInfoPanel
      // 
      this.modelInfoPanel.Controls.Add(this.modelDataPanel);
      this.modelInfoPanel.Controls.Add(this.modelInfoLabel);
      this.modelInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.modelInfoPanel.Location = new System.Drawing.Point(5, 49);
      this.modelInfoPanel.Name = "modelInfoPanel";
      this.modelInfoPanel.Padding = new System.Windows.Forms.Padding(5);
      this.modelInfoPanel.Size = new System.Drawing.Size(286, 267);
      this.modelInfoPanel.TabIndex = 2;
      // 
      // modelDataPanel
      // 
      this.modelDataPanel.Controls.Add(this.normalsCountLabel);
      this.modelDataPanel.Controls.Add(this.texCoordsCountLabel);
      this.modelDataPanel.Controls.Add(this.indicesCountLabel);
      this.modelDataPanel.Controls.Add(this.verticesCountLabel);
      this.modelDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.modelDataPanel.Location = new System.Drawing.Point(5, 28);
      this.modelDataPanel.Name = "modelDataPanel";
      this.modelDataPanel.Padding = new System.Windows.Forms.Padding(5);
      this.modelDataPanel.Size = new System.Drawing.Size(276, 234);
      this.modelDataPanel.TabIndex = 5;
      // 
      // normalsCountLabel
      // 
      this.normalsCountLabel.Dock = System.Windows.Forms.DockStyle.Top;
      this.normalsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.normalsCountLabel.Location = new System.Drawing.Point(5, 65);
      this.normalsCountLabel.Name = "normalsCountLabel";
      this.normalsCountLabel.Size = new System.Drawing.Size(266, 20);
      this.normalsCountLabel.TabIndex = 4;
      this.normalsCountLabel.Text = "Normals";
      // 
      // texCoordsCountLabel
      // 
      this.texCoordsCountLabel.Dock = System.Windows.Forms.DockStyle.Top;
      this.texCoordsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.texCoordsCountLabel.Location = new System.Drawing.Point(5, 45);
      this.texCoordsCountLabel.Name = "texCoordsCountLabel";
      this.texCoordsCountLabel.Size = new System.Drawing.Size(266, 20);
      this.texCoordsCountLabel.TabIndex = 3;
      this.texCoordsCountLabel.Text = "Texture Coords";
      // 
      // indicesCountLabel
      // 
      this.indicesCountLabel.Dock = System.Windows.Forms.DockStyle.Top;
      this.indicesCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.indicesCountLabel.Location = new System.Drawing.Point(5, 25);
      this.indicesCountLabel.Name = "indicesCountLabel";
      this.indicesCountLabel.Size = new System.Drawing.Size(266, 20);
      this.indicesCountLabel.TabIndex = 2;
      this.indicesCountLabel.Text = "Indices";
      // 
      // verticesCountLabel
      // 
      this.verticesCountLabel.Dock = System.Windows.Forms.DockStyle.Top;
      this.verticesCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.verticesCountLabel.Location = new System.Drawing.Point(5, 5);
      this.verticesCountLabel.Name = "verticesCountLabel";
      this.verticesCountLabel.Size = new System.Drawing.Size(266, 20);
      this.verticesCountLabel.TabIndex = 1;
      this.verticesCountLabel.Text = "Vertices";
      // 
      // modelInfoLabel
      // 
      this.modelInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
      this.modelInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
      this.modelInfoLabel.Location = new System.Drawing.Point(5, 5);
      this.modelInfoLabel.Name = "modelInfoLabel";
      this.modelInfoLabel.Size = new System.Drawing.Size(276, 23);
      this.modelInfoLabel.TabIndex = 0;
      this.modelInfoLabel.Text = "Model Info";
      // 
      // fileSizeLabel
      // 
      this.fileSizeLabel.Dock = System.Windows.Forms.DockStyle.Top;
      this.fileSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.fileSizeLabel.Location = new System.Drawing.Point(5, 28);
      this.fileSizeLabel.Name = "fileSizeLabel";
      this.fileSizeLabel.Size = new System.Drawing.Size(286, 21);
      this.fileSizeLabel.TabIndex = 1;
      this.fileSizeLabel.Text = "File Size";
      // 
      // fileNameLabel
      // 
      this.fileNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
      this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.fileNameLabel.Location = new System.Drawing.Point(5, 5);
      this.fileNameLabel.Name = "fileNameLabel";
      this.fileNameLabel.Size = new System.Drawing.Size(286, 23);
      this.fileNameLabel.TabIndex = 0;
      this.fileNameLabel.Text = "File Name";
      // 
      // ModelPickerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(464, 321);
      this.Controls.Add(this.mainPanel);
      this.Controls.Add(this.buttonsPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "ModelPickerForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "OpenGL 3D Model Viewer";
      this.buttonsPanel.ResumeLayout(false);
      this.mainPanel.ResumeLayout(false);
      this.modelInfoPanel.ResumeLayout(false);
      this.modelDataPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog choose3DModelDialog;
    private System.Windows.Forms.Button open3DModelButton;
    private System.Windows.Forms.Panel buttonsPanel;
    private System.Windows.Forms.Panel mainPanel;
    private System.Windows.Forms.Label fileSizeLabel;
    private System.Windows.Forms.Label fileNameLabel;
    private System.Windows.Forms.Panel modelInfoPanel;
    private System.Windows.Forms.Label verticesCountLabel;
    private System.Windows.Forms.Label modelInfoLabel;
    private System.Windows.Forms.Label normalsCountLabel;
    private System.Windows.Forms.Label texCoordsCountLabel;
    private System.Windows.Forms.Label indicesCountLabel;
    private System.Windows.Forms.Panel modelDataPanel;
    private System.Windows.Forms.Button view3DModelButton;
  }
}

