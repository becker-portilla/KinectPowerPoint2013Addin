namespace KinectPowerPointAddIn
{
    partial class KinectRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public KinectRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.kinectBtn = this.Factory.CreateRibbonToggleButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.chkStartPresentation = this.Factory.CreateRibbonCheckBox();
            this.chkMirroring = this.Factory.CreateRibbonCheckBox();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "Kinect";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.kinectBtn);
            this.group1.Items.Add(this.separator1);
            this.group1.Items.Add(this.chkStartPresentation);
            this.group1.Items.Add(this.chkMirroring);
            this.group1.Label = "Control";
            this.group1.Name = "group1";
            // 
            // kinectBtn
            // 
            this.kinectBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.kinectBtn.Image = global::KinectPowerPointAddIn.Properties.Resources.kinect;
            this.kinectBtn.Label = "Activar Control Kinect";
            this.kinectBtn.Name = "kinectBtn";
            this.kinectBtn.ShowImage = true;
            this.kinectBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.kinectBtn_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // chkStartPresentation
            // 
            this.chkStartPresentation.Checked = true;
            this.chkStartPresentation.Label = "Iniciar Presentación";
            this.chkStartPresentation.Name = "chkStartPresentation";
            // 
            // chkMirroring
            // 
            this.chkMirroring.Label = "Espejado";
            this.chkMirroring.Name = "chkMirroring";
            // 
            // KinectRibbon
            // 
            this.Name = "KinectRibbon";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.KinectRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton kinectBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkStartPresentation;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkMirroring;
    }

    partial class ThisRibbonCollection
    {
        internal KinectRibbon KinectRibbon
        {
            get { return this.GetRibbon<KinectRibbon>(); }
        }
    }
}
