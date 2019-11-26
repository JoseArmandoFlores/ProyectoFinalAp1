namespace ProyectoFinal
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsuarioTextBox = new System.Windows.Forms.TextBox();
            this.ContrasenaTextBox = new System.Windows.Forms.TextBox();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.IngresarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "Usuario: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 42;
            this.label2.Text = "Contraseña: ";
            // 
            // UsuarioTextBox
            // 
            this.UsuarioTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsuarioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioTextBox.Location = new System.Drawing.Point(150, 24);
            this.UsuarioTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.UsuarioTextBox.Name = "UsuarioTextBox";
            this.UsuarioTextBox.Size = new System.Drawing.Size(241, 24);
            this.UsuarioTextBox.TabIndex = 43;
            // 
            // ContrasenaTextBox
            // 
            this.ContrasenaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContrasenaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContrasenaTextBox.Location = new System.Drawing.Point(150, 81);
            this.ContrasenaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ContrasenaTextBox.Name = "ContrasenaTextBox";
            this.ContrasenaTextBox.Size = new System.Drawing.Size(241, 24);
            this.ContrasenaTextBox.TabIndex = 44;
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // IngresarButton
            // 
            this.IngresarButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.IngresarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.IngresarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IngresarButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.IngresarButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.IngresarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IngresarButton.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IngresarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IngresarButton.Image = global::ProyectoFinal.Properties.Resources.Login;
            this.IngresarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IngresarButton.Location = new System.Drawing.Point(31, 142);
            this.IngresarButton.Name = "IngresarButton";
            this.IngresarButton.Size = new System.Drawing.Size(355, 46);
            this.IngresarButton.TabIndex = 45;
            this.IngresarButton.Text = "Iniciar Sesión";
            this.IngresarButton.UseVisualStyleBackColor = false;
            this.IngresarButton.Click += new System.EventHandler(this.IngresarButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 201);
            this.Controls.Add(this.IngresarButton);
            this.Controls.Add(this.ContrasenaTextBox);
            this.Controls.Add(this.UsuarioTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox UsuarioTextBox;
        public System.Windows.Forms.TextBox ContrasenaTextBox;
        private System.Windows.Forms.Button IngresarButton;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
    }
}