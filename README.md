<br />
<p align="center">
  <h1 align="center">Prova programador multimídia junior</h1>
</p>
<br />

## Avaliação Prática
Para realização, o candidato deverá ter Conta Google (Gmail) e também criar conta no GitHub. A conta do Gmail será utilizada para fazer a conferência via Hangouts e a conta do GitHub para realização da Prova Prática.

A prova fará uso das seguintes tecnologias: Unity 3D versão mínima 2021, implementação de programação orientada a objeto e utilização de serviços web (API). Opcional o uso do Blender 3D para eventuais animações.

O resultado será enviado individualmente à banca examinadora (on-line) e demais orientações serão enviadas por e-mail após a aprovação na etapa de análise curricular.

Requisitos mínimos: Sistema Operacional e hardware compatíveis com a Unity3D na versão 2021. (https://docs.unity3d.com/2019.4/Documentation/Manual/system-requirements.html)

## Regras
- O candidato realizará a Prova Prática on-line entre os dias 12/08 e 14/08/2022 (iniciando às 17h do dia 12/08/2022 e com prazo máximo para realização até às 23h59 do dia 14/08/2022).

## Critérios de avaliação 
- Planejamento e Organização
- Orientação para o Resultado
- Conhecimento Técnico
- Comunicação e Interação

## Responsável pelo processo seletivo
ANDRELISE HENRIQUE BITTENCOURT (andrelise.henrique@fiesc.com.br)

# Avaliação
+ As questões devem ser respondidas utilizando a Unity e C#
+ A **SCENES** devem ser dividas em pastas para cada questão.

## Questão 1
A mineradora de diamantes **Multimídia-Team** precisa de um programador para criar um sistema automatizado que irá realizar o processo de limpeza de seus diamantes recolhidos, mas para isso o programador deve criar uma simulação para fazer os testes, tendo isso em vista crie um script para realizar esse processo utilizando estrutura de dados em C#.

Faça a limpeza da seguinte string removendo os * e fechando os diamantes <><><><><>:

`***<**<*****<**<**<**<**<****>****>***>***>*****>***>***********>**`

> Exemplo do processo
```
Dada a string:
*<**<****>*>*

Limpeza: <<>>
Resultado final: <><>
```

## Questão 2

Utilizando os modelos 3D disponibilizados, crie um jogo **WHACK-A-MOLE**
> [Modelos 3D](https://github.com/SENAI-SD/prova-programador-multimidia-junior/tree/main/Modelos3D)

**Menu inicial ->**
+ Um botão para iniciar o jogo e outro para fechar o jogo

**Tela do jogo ->**
+ Irá ter botões para recomeçar, pausar/continuar.
+ O jogador deve acertar as toupeiras e incrementar os pontos enquanto o tempo não acaba, ao fim do tempo o jogador será redirecionado para a tela de fim de jogo.

**Tela de fim de jogo ->**
+ Irá ter um botão para recomeçar.
+ Um placar com a lista dos 5 ultimos **highscores** em ordem decrescente

## API
API para utilização no highscore, o score é salvo em **memória** se a api resetar os valores irão ser perdidos.
> [API](https://github.com/SENAI-SD/prova-programador-multimidia-junior/tree/main/Api)