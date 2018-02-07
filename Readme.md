Prova Tecnica DB1

Optei por utilizar Visual Studio 2017, .NET Framework 4.7, C# 7.0. Porque estes s�o minhas 
ferramentas de dominio. Quanto ao Angular, criei um projeto separado da solu��o utilizando Visual Code com a vers�o do angular 5.

### Parte 1 - Logica

3 projetos 1 para cada exercicio, encontrados dentro da solu��o > pasta consoles.


### Parte 2 - Projeto Web

Optei por criar um projeto totalmente separado do backend. Gosto dessa forma porque assim front-end e back-end ficam
independentes tendo assim, um bom ganho de produtividade na equipe.
Utilizando Lazy-Load e rotas.

Dependencias:
nodejs      
npm         
angular-cli (npm install -g @angular/cli)

Rode o projeto pelo CMD navegando ate a pasta do website dentro da solucao -> {Solucao}/ProvaTecnica/WebSite e execute os seguintes
comandos: npm install
          ng serve

### Parte 3 - Web Api RH

Criei um WebApi simples, utilizando Owin, swagger para documentacao, autofac como injetor de dependecia, n�o
utilizei nenhum ORM, classes de log. Optei por fazer um codigo mais limpo possivel. Controllers apenas expoe rotas e 
redireciona requisi�oes, servi�os s�o responsaveis pela comunica��o com o dominio, modelo POCO e Repository responsavel
pela integridade dos dados.

Para executar o projeto precisamos de 2 passos, 
Execute a WebApi como projeto de startup padr�o e voc� vera a documenta��o do swagger em uma pagina web. 
Execute o WebSite como descrito na parte 2

### Tests
Tests c#
Test -> Run -> All Tests (Test unitario)
(Ctrl R + A)

Tests angular
ng test (Test unitario de componentes)
ng e2e (Test de integra��o)



