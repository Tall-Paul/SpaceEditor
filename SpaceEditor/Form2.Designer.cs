namespace SpaceEditor
{
    partial class Form2
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
            System.Windows.Forms.Label Y;
            System.Windows.Forms.Label label2;
            this.label1 = new System.Windows.Forms.Label();
            this.xBox = new System.Windows.Forms.TextBox();
            this.yBox = new System.Windows.Forms.TextBox();
            this.zBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            Y = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(53, 12);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(237, 22);
            this.xBox.TabIndex = 2;
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(53, 40);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(237, 22);
            this.yBox.TabIndex = 3;
            // 
            // zBox
            // 
            this.zBox.Location = new System.Drawing.Point(53, 68);
            this.zBox.Name = "zBox";
            this.zBox.Size = new System.Drawing.Size(237, 22);
            this.zBox.TabIndex = 4;
            // 
            // Y
            // 
            Y.AutoSize = true;
            Y.Location = new System.Drawing.Point(30, 43);
            Y.Name = "Y";
            Y.Size = new System.Drawing.Size(17, 17);
            Y.TabIndex = 5;
            Y.Text = "Y";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(30, 71);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(17, 17);
            label2.TabIndex = 6;
            label2.Text = "Z";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 124);
            this.Controls.Add(this.button1);
            this.Controls.Add(label2);
            this.Controls.Add(Y);
            this.Controls.Add(this.zBox);
            this.Controls.Add(this.yBox);
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.TextBox zBox;
        private System.Windows.Forms.Button button1;
    }
}