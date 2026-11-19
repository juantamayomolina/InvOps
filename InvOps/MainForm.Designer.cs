/*
 * Created by SharpDevelop.
 * User: Juan
 * Date: 27/01/2023
 * Time: 4:38 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace InvOps
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ImprimirTsmi = new System.Windows.Forms.ToolStripMenuItem();
            printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tabPage2 = new System.Windows.Forms.TabPage();
            label23 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            maximaProbabilidadLabel = new System.Windows.Forms.Label();
            valorEsperadoLabel = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            analisisRiesgosDgv = new System.Windows.Forms.DataGridView();
            tabPage1 = new System.Windows.Forms.TabPage();
            parametrosGpb = new System.Windows.Forms.GroupBox();
            probabilidadesBtn = new System.Windows.Forms.Button();
            filasCostosTxt = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            columnasCostosTxt = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            alfaHurwiczTxt = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            categoriaCostoCmb = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            calcularBtn = new System.Windows.Forms.Button();
            generarCostosBtn = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            savageResLabel = new System.Windows.Forms.Label();
            hurwiczResLabel = new System.Windows.Forms.Label();
            laplaceResLabel = new System.Windows.Forms.Label();
            waldResLabel = new System.Windows.Forms.Label();
            maximaxResLabel = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            decisionesDgvSavage = new System.Windows.Forms.DataGridView();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            decisionesDgv = new System.Windows.Forms.DataGridView();
            costosDgv = new System.Windows.Forms.DataGridView();
            generalTbc = new System.Windows.Forms.TabControl();
            menuStrip1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)analisisRiesgosDgv).BeginInit();
            tabPage1.SuspendLayout();
            parametrosGpb.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)decisionesDgvSavage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)decisionesDgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costosDgv).BeginInit();
            generalTbc.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1231, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, ImprimirTsmi, printPreviewToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            fileToolStripMenuItem.Text = "&Archivo";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            newToolStripMenuItem.Text = "&Nuevo";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            openToolStripMenuItem.Text = "&Abrir";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            saveToolStripMenuItem.Text = "&Guardar";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            saveAsToolStripMenuItem.Text = "Guardar &Como";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // ImprimirTsmi
            // 
            ImprimirTsmi.Image = (System.Drawing.Image)resources.GetObject("ImprimirTsmi.Image");
            ImprimirTsmi.ImageTransparentColor = System.Drawing.Color.Magenta;
            ImprimirTsmi.Name = "ImprimirTsmi";
            ImprimirTsmi.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P;
            ImprimirTsmi.Size = new System.Drawing.Size(180, 22);
            ImprimirTsmi.Text = "&Imprimir";
            ImprimirTsmi.Click += ImprimirTsmi_Click;
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("printPreviewToolStripMenuItem.Image");
            printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            printPreviewToolStripMenuItem.Text = "Vista de I&mpresion";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            exitToolStripMenuItem.Text = "Salir";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            editToolStripMenuItem.Text = "&Editar";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z;
            undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            undoToolStripMenuItem.Text = "&Deshacer";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y;
            redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            redoToolStripMenuItem.Text = "&Rehacer";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X;
            cutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            cutToolStripMenuItem.Text = "Cor&tar";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
            copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            copyToolStripMenuItem.Text = "&Copiar";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V;
            pasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            pasteToolStripMenuItem.Text = "&Pegar";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label23);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(analisisRiesgosDgv);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(1199, 549);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Analisis de Riesgo";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label23.Location = new System.Drawing.Point(23, 23);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(244, 25);
            label23.TabIndex = 33;
            label23.Text = "Tabla de analisis de riesgos:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(maximaProbabilidadLabel);
            groupBox2.Controls.Add(valorEsperadoLabel);
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(label22);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(23, 409);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(314, 69);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "Alternativas ideales según criterios";
            // 
            // maximaProbabilidadLabel
            // 
            maximaProbabilidadLabel.AutoSize = true;
            maximaProbabilidadLabel.Location = new System.Drawing.Point(135, 39);
            maximaProbabilidadLabel.Name = "maximaProbabilidadLabel";
            maximaProbabilidadLabel.Size = new System.Drawing.Size(12, 15);
            maximaProbabilidadLabel.TabIndex = 6;
            maximaProbabilidadLabel.Text = "-";
            // 
            // valorEsperadoLabel
            // 
            valorEsperadoLabel.AutoSize = true;
            valorEsperadoLabel.Location = new System.Drawing.Point(135, 22);
            valorEsperadoLabel.Name = "valorEsperadoLabel";
            valorEsperadoLabel.Size = new System.Drawing.Size(12, 15);
            valorEsperadoLabel.TabIndex = 5;
            valorEsperadoLabel.Text = "-";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(6, 39);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(122, 15);
            label21.TabIndex = 1;
            label21.Text = "Maxima Probabilidad:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(6, 23);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(87, 15);
            label22.TabIndex = 0;
            label22.Text = "Valor esperado:";
            // 
            // analisisRiesgosDgv
            // 
            analisisRiesgosDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            analisisRiesgosDgv.Location = new System.Drawing.Point(23, 64);
            analisisRiesgosDgv.Name = "analisisRiesgosDgv";
            analisisRiesgosDgv.RowTemplate.Height = 25;
            analisisRiesgosDgv.Size = new System.Drawing.Size(314, 317);
            analisisRiesgosDgv.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(parametrosGpb);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(decisionesDgvSavage);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(decisionesDgv);
            tabPage1.Controls.Add(costosDgv);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1199, 549);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Análisis de Decisiones";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // parametrosGpb
            // 
            parametrosGpb.Controls.Add(probabilidadesBtn);
            parametrosGpb.Controls.Add(filasCostosTxt);
            parametrosGpb.Controls.Add(label1);
            parametrosGpb.Controls.Add(columnasCostosTxt);
            parametrosGpb.Controls.Add(label2);
            parametrosGpb.Controls.Add(alfaHurwiczTxt);
            parametrosGpb.Controls.Add(label6);
            parametrosGpb.Controls.Add(categoriaCostoCmb);
            parametrosGpb.Controls.Add(label3);
            parametrosGpb.Controls.Add(calcularBtn);
            parametrosGpb.Controls.Add(generarCostosBtn);
            parametrosGpb.Location = new System.Drawing.Point(6, 23);
            parametrosGpb.Name = "parametrosGpb";
            parametrosGpb.Size = new System.Drawing.Size(143, 355);
            parametrosGpb.TabIndex = 32;
            parametrosGpb.TabStop = false;
            parametrosGpb.Text = "Parametros";
            // 
            // probabilidadesBtn
            // 
            probabilidadesBtn.Location = new System.Drawing.Point(5, 270);
            probabilidadesBtn.Name = "probabilidadesBtn";
            probabilidadesBtn.Size = new System.Drawing.Size(131, 41);
            probabilidadesBtn.TabIndex = 29;
            probabilidadesBtn.Text = "Configurar\r\nprobabilidades";
            probabilidadesBtn.UseVisualStyleBackColor = true;
            probabilidadesBtn.Click += probabilidadesBtn_Click;
            // 
            // filasCostosTxt
            // 
            filasCostosTxt.Location = new System.Drawing.Point(100, 44);
            filasCostosTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            filasCostosTxt.Name = "filasCostosTxt";
            filasCostosTxt.Size = new System.Drawing.Size(36, 23);
            filasCostosTxt.TabIndex = 17;
            filasCostosTxt.Text = "0";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(5, 44);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 23);
            label1.TabIndex = 21;
            label1.Text = "No. Decisiones:";
            // 
            // columnasCostosTxt
            // 
            columnasCostosTxt.Location = new System.Drawing.Point(100, 84);
            columnasCostosTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            columnasCostosTxt.Name = "columnasCostosTxt";
            columnasCostosTxt.Size = new System.Drawing.Size(36, 23);
            columnasCostosTxt.TabIndex = 18;
            columnasCostosTxt.Text = "0";
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(7, 84);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 38);
            label2.TabIndex = 22;
            label2.Text = "Estados de la \r\nNaturaleza:";
            // 
            // alfaHurwiczTxt
            // 
            alfaHurwiczTxt.Location = new System.Drawing.Point(100, 132);
            alfaHurwiczTxt.Name = "alfaHurwiczTxt";
            alfaHurwiczTxt.Size = new System.Drawing.Size(36, 23);
            alfaHurwiczTxt.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 132);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(53, 30);
            label6.TabIndex = 27;
            label6.Text = "Alfa de \r\nHurwicz:";
            // 
            // categoriaCostoCmb
            // 
            categoriaCostoCmb.FormattingEnabled = true;
            categoriaCostoCmb.Items.AddRange(new object[] { "Costos", "Rentabilidad" });
            categoriaCostoCmb.Location = new System.Drawing.Point(5, 195);
            categoriaCostoCmb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            categoriaCostoCmb.Name = "categoriaCostoCmb";
            categoriaCostoCmb.Size = new System.Drawing.Size(131, 23);
            categoriaCostoCmb.TabIndex = 20;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(5, 176);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(128, 28);
            label3.TabIndex = 23;
            label3.Text = "Concepto decisiones:";
            // 
            // calcularBtn
            // 
            calcularBtn.Location = new System.Drawing.Point(5, 326);
            calcularBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            calcularBtn.Name = "calcularBtn";
            calcularBtn.Size = new System.Drawing.Size(131, 23);
            calcularBtn.TabIndex = 24;
            calcularBtn.Text = "Calcular";
            calcularBtn.UseVisualStyleBackColor = true;
            calcularBtn.Click += CalcularBtnClick;
            // 
            // generarCostosBtn
            // 
            generarCostosBtn.Location = new System.Drawing.Point(5, 233);
            generarCostosBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            generarCostosBtn.Name = "generarCostosBtn";
            generarCostosBtn.Size = new System.Drawing.Size(131, 23);
            generarCostosBtn.TabIndex = 28;
            generarCostosBtn.Text = "Generar costos";
            generarCostosBtn.UseVisualStyleBackColor = true;
            generarCostosBtn.Click += GenerarCostosBtnClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(savageResLabel);
            groupBox1.Controls.Add(hurwiczResLabel);
            groupBox1.Controls.Add(laplaceResLabel);
            groupBox1.Controls.Add(waldResLabel);
            groupBox1.Controls.Add(maximaxResLabel);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(6, 416);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(625, 114);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alternativas ideales según criterios";
            // 
            // savageResLabel
            // 
            savageResLabel.AutoSize = true;
            savageResLabel.Location = new System.Drawing.Point(135, 85);
            savageResLabel.Name = "savageResLabel";
            savageResLabel.Size = new System.Drawing.Size(12, 15);
            savageResLabel.TabIndex = 9;
            savageResLabel.Text = "-";
            // 
            // hurwiczResLabel
            // 
            hurwiczResLabel.AutoSize = true;
            hurwiczResLabel.Location = new System.Drawing.Point(135, 70);
            hurwiczResLabel.Name = "hurwiczResLabel";
            hurwiczResLabel.Size = new System.Drawing.Size(12, 15);
            hurwiczResLabel.TabIndex = 8;
            hurwiczResLabel.Text = "-";
            // 
            // laplaceResLabel
            // 
            laplaceResLabel.AutoSize = true;
            laplaceResLabel.Location = new System.Drawing.Point(135, 55);
            laplaceResLabel.Name = "laplaceResLabel";
            laplaceResLabel.Size = new System.Drawing.Size(12, 15);
            laplaceResLabel.TabIndex = 7;
            laplaceResLabel.Text = "-";
            // 
            // waldResLabel
            // 
            waldResLabel.AutoSize = true;
            waldResLabel.Location = new System.Drawing.Point(135, 39);
            waldResLabel.Name = "waldResLabel";
            waldResLabel.Size = new System.Drawing.Size(12, 15);
            waldResLabel.TabIndex = 6;
            waldResLabel.Text = "-";
            // 
            // maximaxResLabel
            // 
            maximaxResLabel.AutoSize = true;
            maximaxResLabel.Location = new System.Drawing.Point(135, 22);
            maximaxResLabel.Name = "maximaxResLabel";
            maximaxResLabel.Size = new System.Drawing.Size(12, 15);
            maximaxResLabel.TabIndex = 5;
            maximaxResLabel.Text = "-";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(6, 85);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(47, 15);
            label12.TabIndex = 4;
            label12.Text = "Savage:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(6, 70);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(53, 15);
            label11.TabIndex = 3;
            label11.Text = "Hurwicz:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(6, 55);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(50, 15);
            label10.TabIndex = 2;
            label10.Text = "Laplace:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 39);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(37, 15);
            label9.TabIndex = 1;
            label9.Text = "Wald:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 23);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(107, 15);
            label8.TabIndex = 0;
            label8.Text = "Maximax/Minimin:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(654, 285);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(145, 25);
            label7.TabIndex = 30;
            label7.Text = "Análisis Savage:";
            // 
            // decisionesDgvSavage
            // 
            decisionesDgvSavage.AllowUserToAddRows = false;
            decisionesDgvSavage.AllowUserToDeleteRows = false;
            decisionesDgvSavage.AllowUserToResizeColumns = false;
            decisionesDgvSavage.AllowUserToResizeRows = false;
            decisionesDgvSavage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            decisionesDgvSavage.Location = new System.Drawing.Point(654, 313);
            decisionesDgvSavage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decisionesDgvSavage.Name = "decisionesDgvSavage";
            decisionesDgvSavage.Size = new System.Drawing.Size(505, 217);
            decisionesDgvSavage.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(654, 23);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(194, 25);
            label5.TabIndex = 26;
            label5.Text = "Tabla de operaciones:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(156, 23);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(402, 25);
            label4.TabIndex = 25;
            label4.Text = "Tabla de decisiones y estados de la naturaleza:";
            // 
            // decisionesDgv
            // 
            decisionesDgv.AllowUserToAddRows = false;
            decisionesDgv.AllowUserToDeleteRows = false;
            decisionesDgv.AllowUserToResizeColumns = false;
            decisionesDgv.AllowUserToResizeRows = false;
            decisionesDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            decisionesDgv.Location = new System.Drawing.Point(653, 51);
            decisionesDgv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decisionesDgv.Name = "decisionesDgv";
            decisionesDgv.Size = new System.Drawing.Size(505, 217);
            decisionesDgv.TabIndex = 16;
            // 
            // costosDgv
            // 
            costosDgv.AllowUserToAddRows = false;
            costosDgv.AllowUserToDeleteRows = false;
            costosDgv.AllowUserToResizeColumns = false;
            costosDgv.AllowUserToResizeRows = false;
            costosDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            costosDgv.Location = new System.Drawing.Point(156, 51);
            costosDgv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            costosDgv.Name = "costosDgv";
            costosDgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            costosDgv.Size = new System.Drawing.Size(475, 327);
            costosDgv.TabIndex = 15;
            costosDgv.CellLeave += CostosDgvCellLeave;
            costosDgv.CellValidated += costosDgv_CellValidated;
            // 
            // generalTbc
            // 
            generalTbc.Controls.Add(tabPage1);
            generalTbc.Controls.Add(tabPage2);
            generalTbc.Location = new System.Drawing.Point(12, 27);
            generalTbc.Name = "generalTbc";
            generalTbc.SelectedIndex = 0;
            generalTbc.Size = new System.Drawing.Size(1207, 577);
            generalTbc.TabIndex = 13;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1231, 613);
            Controls.Add(generalTbc);
            Controls.Add(menuStrip1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "InvOps";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)analisisRiesgosDgv).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            parametrosGpb.ResumeLayout(false);
            parametrosGpb.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)decisionesDgvSavage).EndInit();
            ((System.ComponentModel.ISupportInitialize)decisionesDgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)costosDgv).EndInit();
            generalTbc.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ImprimirTsmi;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label maximaProbabilidadLabel;
        private System.Windows.Forms.Label valorEsperadoLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridView analisisRiesgosDgv;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox parametrosGpb;
        private System.Windows.Forms.Button probabilidadesBtn;
        private System.Windows.Forms.TextBox filasCostosTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox columnasCostosTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox alfaHurwiczTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox categoriaCostoCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button calcularBtn;
        private System.Windows.Forms.Button generarCostosBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label savageResLabel;
        private System.Windows.Forms.Label hurwiczResLabel;
        private System.Windows.Forms.Label laplaceResLabel;
        private System.Windows.Forms.Label waldResLabel;
        private System.Windows.Forms.Label maximaxResLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView decisionesDgvSavage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView decisionesDgv;
        private System.Windows.Forms.DataGridView costosDgv;
        private System.Windows.Forms.TabControl generalTbc;
    }
}
