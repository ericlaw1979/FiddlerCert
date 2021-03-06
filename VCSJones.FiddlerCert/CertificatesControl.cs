﻿using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Fiddler;

namespace VCSJones.FiddlerCert
{
    public partial class CertificatesControl : UserControl
    {
        public CertificatesControl()
        {
            InitializeComponent();
        }

        internal void AssignCertificate(X509ChainElement chainElement)
        {
            const int CERT_HEIGHT = 175;
            const int CERT_PADDING = 5;
            var numberOfCertificates = Controls.Count;
            var currentOffset = (numberOfCertificates * CERT_HEIGHT) + (CERT_PADDING * numberOfCertificates) + CERT_PADDING;
            var newCertificate = new CertificateControl();
            newCertificate.Top = currentOffset;
            newCertificate.Height = CERT_HEIGHT;
            newCertificate.Width = this.Width;
            newCertificate.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            newCertificate.SetCertificate(chainElement);
            Controls.Add(newCertificate);
        }

        internal void ClearCertificates()
        {
            Controls.Clear();
        }
    }
}
