# 🚀 Desafio Técnico — Explorando Marte

Este projeto resolve o desafio proposto pela Niuco: simular a movimentação de sondas em um planalto marciano, com controle de direção, validação de limites e prevenção de colisões.


## ✅ Descrição do Problema

Um conjunto de sondas (rovers) será enviado para explorar um planalto retangular em Marte. Cada sonda recebe uma posição inicial e uma sequência de comandos para se mover. O programa deve processar esses comandos e exibir a posição final de cada sonda.

Exemplo de entrada:
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

Saída esperada:
1 3 N
5 1 E


## 🛠️ Como Executar o Projeto

### Pré-requisitos
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Visual Studio 2022 ou superior, ou VS Code com extensão C#

### Executando no Visual Studio 2022

Clone o repositório via bash:
git clone https://github.com/rfogaca/marsrover.git

Abra o arquivo de solução (.sln) no Visual Studio
Clique com o botão direito sobre o projeto MarsRover.ConsoleApplication e selecione Set as Startup Project
Pressione Ctrl + F5 para executar (ou clique em "Start Without Debugging")
A saída será exibida no terminal integrado com os resultados da missão


🧱 Organização do Projeto

Domain/: entidades principais (Rover, Plateau, Position, Direction)
Commands/: implementação do Command Pattern (ICommand, MoveCommand, etc.)
Services/: classe MissionControl, responsável por orquestrar a missão
Tests/: testes unitários com NUni
.github/workflows/: CI com GitHub Actions


🧠 Decisões de Arquitetura

Projeto em formato CLI para foco total na lógica
Separação clara entre domínio e comandos
Uso de imutabilidade em Position para evitar efeitos colaterais
Testes unitários com cobertura de regras críticas (limites, rotação, colisões)


🧩 Design Patterns Utilizados

✅ Command Pattern
Cada instrução (L, R, M) foi encapsulada em uma classe de comando (ICommand). Isso facilita a adição de novos comandos no futuro, além de manter o código limpo e extensível.
✅ Factory Pattern
A classe CommandFactory é responsável por traduzir uma string como "LMLMM" em uma lista de objetos ICommand.


🧱 Aplicação dos Princípios SOLID

SRP: cada classe tem uma responsabilidade clara (ex: Rover movimenta, Plateau valida limites).
OCP: é possível adicionar novos comandos sem modificar o código existente.
LSP: se criarmos novos tipos de veículos no futuro, poderão herdar de uma estrutura comum.
ISP: as interfaces foram mantidas pequenas e específicas (ex: ICommand com apenas Execute()).
DIP: MissionControl depende de abstrações (ICommand), não de implementações concretas.


🐞 Uso do Debugger

Durante o desenvolvimento, utilizei:
Breakpoints em MissionControl.DeployRover() para acompanhar a execução de comandos
Step Over (F10) para validar rotação e limites
Inspeção de variáveis (como Position e Direction) para confirmar se estavam sendo atualizadas corretamente


💬 Considerações Finais

A estrutura foi pensada para facilitar leitura, testes e manutenção. Com o uso de OOP, SOLID e padrões de projeto, é possível expandir a solução facilmente (como adicionar sensores, comandos extras ou interface gráfica).


🔁 Integração Contínua (CI)

O projeto possui um pipeline no GitHub Actions que:
Compila o projeto
Roda os testes com dotnet test
O arquivo de configuração está em .github/workflows/ci.yml
Você pode visualizar os resultados na aba Actions do repositório.