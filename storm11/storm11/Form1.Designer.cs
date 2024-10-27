namespace storm11
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_init = new Button();
            button_draw = new Button();
            draw_panel = new Panel();
            SuspendLayout();
            // 
            // button_init
            // 
            button_init.BackColor = SystemColors.ActiveCaption;
            button_init.FlatStyle = FlatStyle.Popup;
            button_init.Location = new Point(1127, 12);
            button_init.Name = "button_init";
            button_init.Size = new Size(75, 23);
            button_init.TabIndex = 0;
            button_init.Text = "Init";
            button_init.UseVisualStyleBackColor = false;
            button_init.Click += button_init_Click;
            // 
            // button_draw
            // 
            button_draw.BackColor = SystemColors.Highlight;
            button_draw.FlatStyle = FlatStyle.Popup;
            button_draw.Location = new Point(1127, 48);
            button_draw.Name = "button_draw";
            button_draw.Size = new Size(75, 23);
            button_draw.TabIndex = 2;
            button_draw.Text = "Drawing";
            button_draw.UseVisualStyleBackColor = false;
            button_draw.Click += button_draw_Click;
            // 
            // draw_panel
            // 
            draw_panel.Location = new Point(0, 0);
            draw_panel.Name = "draw_panel";
            draw_panel.Size = new Size(1121, 775);
            draw_panel.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 787);
            Controls.Add(draw_panel);
            Controls.Add(button_draw);
            Controls.Add(button_init);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button_init;
        private Button button_draw;
        private Panel draw_panel;
    }
}
