namespace Khlyzova_Valeria_PRI_117_lab_08
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Режим рисования",
            "Режим коррекции"});
            this.comboBox1.Location = new System.Drawing.Point(506, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(-1, -1);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(500, 500);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 2;
            this.AnT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseClick);
            this.AnT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseDown);
            this.AnT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseMove);
            this.AnT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseUp);
            // 
            // RenderTimer
            // 
            this.RenderTimer.Interval = 30;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "15 вариант";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(505, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "Вернутся к динамическому рисованию";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 497);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AnT);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Khlyzova_Valeria_PRI_117_lab_08";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Timer RenderTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

