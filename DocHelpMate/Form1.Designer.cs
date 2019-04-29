namespace DocHelpMate
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.SourceFileTextBox = new System.Windows.Forms.TextBox();
			this.SourceFileButton = new System.Windows.Forms.Button();
			this.SaveFileTextBox = new System.Windows.Forms.TextBox();
			this.StartButton = new System.Windows.Forms.Button();
			this.SaveFileButton = new System.Windows.Forms.Button();
			this.SourceFileFieldName = new System.Windows.Forms.TextBox();
			this.SaveFileFieldName = new System.Windows.Forms.TextBox();
			this.InstructionBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// SourceFileTextBox
			// 
			this.SourceFileTextBox.Location = new System.Drawing.Point(112, 211);
			this.SourceFileTextBox.Name = "SourceFileTextBox";
			this.SourceFileTextBox.Size = new System.Drawing.Size(321, 20);
			this.SourceFileTextBox.TabIndex = 0;
			// 
			// SourceFileButton
			// 
			this.SourceFileButton.Location = new System.Drawing.Point(439, 209);
			this.SourceFileButton.Name = "SourceFileButton";
			this.SourceFileButton.Size = new System.Drawing.Size(75, 23);
			this.SourceFileButton.TabIndex = 1;
			this.SourceFileButton.Text = "Set Source";
			this.SourceFileButton.UseVisualStyleBackColor = true;
			this.SourceFileButton.Click += new System.EventHandler(this.SourceFileButton_Click);
			// 
			// SaveFileTextBox
			// 
			this.SaveFileTextBox.Location = new System.Drawing.Point(112, 237);
			this.SaveFileTextBox.Name = "SaveFileTextBox";
			this.SaveFileTextBox.Size = new System.Drawing.Size(321, 20);
			this.SaveFileTextBox.TabIndex = 2;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(439, 264);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 3;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// SaveFileButton
			// 
			this.SaveFileButton.Location = new System.Drawing.Point(439, 235);
			this.SaveFileButton.Name = "SaveFileButton";
			this.SaveFileButton.Size = new System.Drawing.Size(75, 23);
			this.SaveFileButton.TabIndex = 4;
			this.SaveFileButton.Text = "Set Folder";
			this.SaveFileButton.UseVisualStyleBackColor = true;
			this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
			// 
			// SourceFileFieldName
			// 
			this.SourceFileFieldName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SourceFileFieldName.Location = new System.Drawing.Point(11, 214);
			this.SourceFileFieldName.Name = "SourceFileFieldName";
			this.SourceFileFieldName.ReadOnly = true;
			this.SourceFileFieldName.Size = new System.Drawing.Size(95, 13);
			this.SourceFileFieldName.TabIndex = 5;
			this.SourceFileFieldName.Text = "Source File";
			// 
			// SaveFileFieldName
			// 
			this.SaveFileFieldName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SaveFileFieldName.Location = new System.Drawing.Point(11, 240);
			this.SaveFileFieldName.Name = "SaveFileFieldName";
			this.SaveFileFieldName.ReadOnly = true;
			this.SaveFileFieldName.Size = new System.Drawing.Size(95, 13);
			this.SaveFileFieldName.TabIndex = 6;
			this.SaveFileFieldName.Text = "Destination Folder";
			// 
			// InstructionBox
			// 
			this.InstructionBox.Location = new System.Drawing.Point(13, 11);
			this.InstructionBox.Multiline = true;
			this.InstructionBox.Name = "InstructionBox";
			this.InstructionBox.ReadOnly = true;
			this.InstructionBox.Size = new System.Drawing.Size(501, 191);
			this.InstructionBox.TabIndex = 7;
			this.InstructionBox.Text = resources.GetString("InstructionBox.Text");
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 299);
			this.Controls.Add(this.InstructionBox);
			this.Controls.Add(this.SaveFileFieldName);
			this.Controls.Add(this.SourceFileFieldName);
			this.Controls.Add(this.SaveFileButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.SaveFileTextBox);
			this.Controls.Add(this.SourceFileButton);
			this.Controls.Add(this.SourceFileTextBox);
			this.Name = "Form1";
			this.Text = "PDF to Word Document Helper";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox SourceFileTextBox;
		private System.Windows.Forms.Button SourceFileButton;
		private System.Windows.Forms.TextBox SaveFileTextBox;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Button SaveFileButton;
		private System.Windows.Forms.TextBox SourceFileFieldName;
		private System.Windows.Forms.TextBox SaveFileFieldName;
		private System.Windows.Forms.TextBox InstructionBox;
	}
}

