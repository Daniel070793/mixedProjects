using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;

namespace textToSpeech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer voice;
        public MainWindow()
        {
            InitializeComponent();
            voice = new SpeechSynthesizer();
        }

        private void btnSpeak_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (cmboSelectVoice.SelectedIndex)
                {
                    case 0:
                        voice.SelectVoiceByHints(VoiceGender.NotSet);
                        break;
                    case 1:
                        voice.SelectVoiceByHints(VoiceGender.Male);
                        break;
                    case 2:
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        break;
                    case 3:
                        voice.SelectVoiceByHints(VoiceGender.Neutral);
                        break;
                    default:
                        break;                       
                }
                voice.SpeakAsync(txtContent.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            voice.Pause();
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            voice.Resume();
        }
    }
}
