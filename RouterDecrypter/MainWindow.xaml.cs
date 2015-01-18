using System.Windows;
using System.Windows.Documents;

namespace RouterDecrypter
{
    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonEncrypt_OnClick(object sender, RoutedEventArgs e)
        {
            Source.Text = Encrypt(Output.Text);
        }

        private void ButtonDecrypt_OnClick(object sender, RoutedEventArgs e)
        {
            Output.Text = Decrypt(Source.Text);
        }

        private string Encrypt(string input)
        {
            var source = input.Trim();
            var sourceLength = source.Length;
            var builder = new System.Text.StringBuilder(sourceLength);
            for (int i = 0; i < sourceLength; i++)
            {
                var c = source[i] * 2;
                builder.Append((char)(c % 127));
            }
            return builder.ToString();
        }

        private string Decrypt(string input)
        {
            var source = input.Trim();
            var sourceLength = source.Length;
            var builder = new System.Text.StringBuilder(sourceLength);
            for (int i = 0; i < sourceLength; i++)
            {
                var c = source[i];
                if (c % 2 == 0)
                {
                    builder.Append((char)(c/2));
                }
                else
                {
                    builder.Append((char) ((c + 127)/2));
                }
            }
            return builder.ToString();
        }
    }

    public class HyperlinkEx : Hyperlink
    {
        protected override void OnClick()
        {
            if (NavigateUri != null && NavigateUri.IsAbsoluteUri)
            {
                System.Diagnostics.Process.Start(NavigateUri.OriginalString);
            }
            else
            {
                base.OnClick();
            }
        }
    }

}
