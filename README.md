# MatchGame

Um jogo de memória desenvolvido em C# com WPF. Este projeto foi criado para praticar os conceitos básicos de C#, XAML e desenvolvimento de aplicações desktop.

O objetivo é encontrar todos os pares de emojis exibidos no tabuleiro.
Ao selecionar dois animais:

- Se forem iguais, eles são removidos da tela.
- Se forem diferentes, eles voltam a aparecer após alguns instantes.
- Ao encontrar todos os pares, o cronômetro é parado e o jogo é reiniciado.

Este projeto foi desenvolvido como forma de aprendizado e prática dos conceitos básicos de C# e XAML.

## Funcionalidades
- 🐶 Combinação de animais
- ⏱️ Cronômetro durante a partida
- 🔄 Reinício automático após completar o jogo
- ❌ Tratamento de combinações incorretas
- 🎲 Embaralhamento dos animais a cada partida

## Tecnologias utilizadas

- C#
- WPF (Windows Presentation Foundation)
- XAML
- .NET 10
- Visual Studio

## Como executar

### Pré-requisitos

- Windows
- SDK do .NET 10
- Visual Studio com a carga de trabalho de desenvolvimento para desktop do .NET

### Passos

1. Clone o repositório:

   ```bash
   git clone https://github.com/arlindx/MatchGame.git
   ```

2. Abra `MatchGame.sln` no Visual Studio.
3. Selecione o projeto `MatchGame` como projeto de inicialização.
4. Execute com `F5` ou clique em **Iniciar**.

Também é possível executar pelo terminal:

```bash
cd MatchGame
dotnet run --project MatchGame/MatchGame.csproj
```

## Referência de aprendizado

Este projeto foi inspirado em um exercício do livro **Use a Cabeça! C#**, 4ª edição, publicado pela O'Reilly Media.

A implementação deste repositório representa a versão desenvolvida durante o estudo e não reproduz integralmente textos, imagens ou conteúdo original da publicação. Consulte o livro para o material oficial e os direitos de publicação.

## O que eu aprendi

Durante o desenvolvimento deste projeto, pratiquei:

- Estrutura básica de aplicações em C#
- Criação de interfaces utilizando WPF
- Eventos e interação com elementos da interface
- Manipulação de listas e objetos
- Controle de tempo utilizando timers
- Lógica de comparação e combinação de elementos

## Demonstração
<img width="344" height="397" alt="image" src="https://github.com/user-attachments/assets/dbafac92-ae0f-4dc7-a7e4-22719461355a" />

## Próximos passos

- [ ] Adicionar diferentes níveis de dificuldade.
- [ ] Adicionar pontuação e um Ranking.
- [ ] Melhorar as animações.
- [ ] Adicionar mais animais e gerar uma rotatividade lógica de pares.
- [ ] Criar uma tela inicial.
- [ ] Adicionar efeitos sonoros.
