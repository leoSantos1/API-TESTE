# API-TESTE
Descreva/Desenhe a arquitetura utilizada na solução.
ApiRestful para cadastro das informações, OO para, forma separados por projetos para deixa mais facil a manutenção/desacoplamento
Descreve como a modelagem de domínio foi implementada de uma maneira que deixa a aplicação flexível.
Bom, tentei criar de uma forma que ficasse facil interpretar o que cada classe/método fazia
Como você resolveu/resolveria problemas de resiliência na aplicação?
Pesquisa, pesquisa e mais pesquisa a fim de encontrar uma forma ideal de implementar tal rotina
Como você resolveu/resolveria problemas de escalabilidade na aplicação?
Da mesma forma que a questão acima, esta me parece uma pergunta vaga pois tudo depende do contexto em que a aplicação está necessitando 
Como você resolveu/resolveria problemas de rastreabilidade na aplicação?
Neste teste não consegui me aprofundar neste ponto, mas resolveria buscando entender o problema realizar um diagrama verificar ideias de outras pessoas e então começar a desenvolver
Como você garantiu a qualidade da sua aplicação?
Neste ponto não pude ser muito criterioso, precisava entregar algo rsrs


Utilização

Iniciar um site no iis apontando para a pasta da API => Api-Teste
Iniciar um site no iis apontando para a pasta do site => Configuration

O site de configuração de algumas funcionalidades da API
A api em sí para os inserts e consultas

Segue junto uma base de dados .mdf com a estrutura
No arquivo web.config adicionara a tag DBConnection com o valor da connection string

No arquivo web.config existem configurações para o envio do email email, senha etc...
