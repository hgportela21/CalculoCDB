# Calculadora de CDB
Esta aplicação foi desenvolvida com o intuito de teste para realizar cálculo de rendimento de um CDB

## Requisitos

.NET SDK (versão 7).<br>
Node.js (versão 18 ou superior).<br>
Angular (versão 14 ou superior).

## Inicialização do projeto Angular
Abir o terminal e ir até o caminho (cd ~/CalculoCDB.Web) e executar os comandos:

- "npm install" (baixar as dependências do projeto angular) e depois o "ng serve" para executar a aplicação que irá iniciar em http://localhost:4200.

## Execução da API .NET
O projeto para execução da API é o "CalculoCDB.API" localizado dentro da pasta "WebAPI" da solution. <br>
Definir o projeto como projeto de inicialização. <br>
A API estará disponível em https://localhost:7190. <br>
Após estar executando ambas aplicações ("CalculoCDB.Web" e "CalculoCDB.API") ao mesmo tempo, basta utilizar a aplicação normalmente pelo http://localhost:4200. 