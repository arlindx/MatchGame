// Classes básicas usadas pela aplicação WPF.
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MatchGame
{
    // Representa a janela principal do jogo.
    public partial class MainWindow : Window
    {
        // Temporizador responsável por atualizar o tempo exibido na tela.
        DispatcherTimer timer = new DispatcherTimer();

        // Quantidade de décimos de segundo transcorridos desde o início da partida.
        int tenthsOfSecondsElapsed;

        // Quantidade de pares de emojis encontrados pelo jogador.
        int matchesFound;

        // Construtor executado quando a janela principal é criada.
        public MainWindow()
        {
            // Carrega os componentes definidos no arquivo MainWindow.xaml.
            InitializeComponent();

            // Faz o temporizador executar o evento Tick a cada 0,1 segundo.
            timer.Interval = TimeSpan.FromSeconds(.1);

            // Liga o evento do temporizador ao método que atualiza o relógio do jogo.
            timer.Tick += Timer_Tick;

            // Prepara os emojis e inicia uma nova partida.
            SetUpGame();
        }

        // Executa a atualização do relógio sempre que o temporizador dispara.
        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Soma um décimo de segundo ao tempo total da partida.
            tenthsOfSecondsElapsed++;

            // Converte os décimos de segundo para segundos e atualiza o texto da tela.
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

            // Verifica se todos os oito pares foram encontrados.
            if (matchesFound == 8)
            {
                // Para a contagem do tempo porque a partida terminou.
                timer.Stop();

                // Informa ao jogador que ele pode iniciar outra partida.
                timeTextBlock.Text = timeTextBlock.Text + " = Play again?";
            }
        }

        // Distribui aleatoriamente os emojis e reinicia os dados da partida.
        private void SetUpGame()
        {
            // Cria duas cópias de cada emoji para formar os pares do jogo.
            List<string> animalEmoji = new List<string>()
            {
                "🐙", "🐙",
                "🦁", "🦁",
                "🦊", "🦊",
                "🐱", "🐱",
                "🐷", "🐷",
                "🐭", "🐭",
                "🐸", "🐸",
                "🐔", "🐔",
            };

            // Cria o gerador usado para sortear a posição de cada emoji.
            Random random = new Random();

            // Percorre todos os TextBlocks que estão dentro do painel principal.
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) 
            {
                // O TextBlock do relógio não participa do tabuleiro de emojis.
                if (textBlock.Name != "timeTextBlock") 
                {
                    // Torna o emoji visível no início da partida.
                    textBlock.Visibility = Visibility.Visible;

                    // Escolhe aleatoriamente um emoji que ainda não foi usado.
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];

                    // Exibe o emoji sorteado no quadrado atual.
                    textBlock.Text = nextEmoji;

                    // Remove o emoji escolhido para impedir que ele seja usado novamente.
                    animalEmoji.RemoveAt(index);
                }

                // Inicia ou reinicia o temporizador da partida.
                timer.Start();

                // Zera o tempo decorrido e a quantidade de pares encontrados.
                tenthsOfSecondsElapsed = 0;
                matchesFound = 0;
            }
        }

        // Armazena o último quadrado selecionado pelo jogador.
        TextBlock lastTextBlockClicked;

        // Indica se o jogador já selecionou o primeiro emoji de um possível par.
        bool findingMatch = false;

        // Trata o clique do jogador em um quadrado do tabuleiro.
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Obtém o TextBlock que recebeu o clique.
            TextBlock textBlock = sender as TextBlock;

            // Se este for o primeiro clique do par, esconde o emoji e guarda sua referência.
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }

            // Se os dois emojis forem iguais, registra o par, esconde o segundo quadrado
            // e encerra a seleção atual.
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                // Soma um ao total de pares encontrados.
                matchesFound++;

                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }

            // Se os emojis forem diferentes, revela novamente o primeiro quadrado selecionado.
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        // Trata o clique no relógio quando o jogador deseja iniciar uma nova partida.
        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Só permite reiniciar depois que todos os oito pares foram encontrados.
            if (matchesFound == 8)
            {
                // Monta novamente o tabuleiro e reinicia os contadores.
                SetUpGame();
            }
        }
    }
}
